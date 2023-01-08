using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


using Camunda.Api.Client;

using Iana;
using Newtonsoft.Json;

namespace Philips.BTR.Maestro.ImagingClassic.Camunda
{
    /// <summary>
    /// See ErrorMessageHandler.cs
    /// This variant doesn't set InnerHandler so that Microsoft and Refit can do dependency injection
    /// with it, and handles fewer errors so Poly can handle them instead.
    /// </summary>
    public class HttpClientFactoryMessageHandler : DelegatingHandler
    {
        public HttpClientFactoryMessageHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {
        }

        public HttpClientFactoryMessageHandler()
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode &&
                response.Content?.Headers?.ContentType?.MediaType?.Equals(MediaTypes.Application.Json) == true)
            {
                RestError err;
                string json;
                try
                {
                    json = await response.Content.ReadAsStringAsync();
                    err = JsonConvert.DeserializeObject<RestError>(json);
                }
                catch (Exception e)
                {
                    return response;
                    // we are currently handling exception, don't throw another one during deserialization
                }

                if (err?.Type != null)
                {
                    ApiException ex = ApiException.FromRestError(err, response);
                    if (ex.GetType() != typeof(ApiException))
                    {
                        // fill additional exception properties
                        JsonConvert.PopulateObject(json, ex);
                        throw ex;
                    }
                }
            }

            return response;
        }
    }
}
