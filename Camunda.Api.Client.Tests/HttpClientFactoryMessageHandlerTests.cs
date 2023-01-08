using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Iana;
using RichardSzalay.MockHttp;

using Xunit;

namespace Camunda.Api.Client.Tests
{
    public class HttpClientFactoryMessageHandlerTests
    {
        [Fact]
        public async void NonSpecificErrorsReturned()
        {
            // setup
            MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
            mockHttp.Expect(HttpMethod.Get, "http://invalid.bad")
                .Respond(HttpStatusCode.GatewayTimeout, "text/html", "OK");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://invalid.bad");
            HttpClientFactoryMessageHandler handler = new HttpClientFactoryMessageHandler(mockHttp);
            HttpMessageInvoker invoker = new HttpMessageInvoker(handler);

            // test
            // fails if this throws ApiException
            HttpResponseMessage result = await invoker.SendAsync(request, new CancellationToken());

            // assert
            Assert.Equal(HttpStatusCode.GatewayTimeout, result.StatusCode);
        }

        [Fact]
        public async void SpecificErrorsRaised()
        {
            // setup
            MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
            RestError error = new RestError() { Message = "{}", Type = "BpmnParseException" };
            mockHttp.Expect(HttpMethod.Get, "http://invalid.bad")
                .Respond(HttpStatusCode.BadRequest, MediaTypes.Application.Json, JsonSerializer.Serialize(error));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://invalid.bad");
            HttpClientFactoryMessageHandler handler = new HttpClientFactoryMessageHandler(mockHttp);
            HttpMessageInvoker invoker = new HttpMessageInvoker(handler);

            // test & assert
            await Assert.ThrowsAsync<BpmnParseException>(
            async () => await invoker.SendAsync(request, new CancellationToken()));
        }
    }
}
