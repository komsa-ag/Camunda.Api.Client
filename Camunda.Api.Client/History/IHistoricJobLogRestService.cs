using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.History
{
    internal interface IHistoricJobLogRestService
    {
        [Get("/history/job-log/{id}")]
        Task<HistoricJobLog> Get(string id, CancellationToken cancellationToken = default);

        [Post("/history/job-log")]
        Task<List<HistoricJobLog>> GetList([Body] HistoricJobLogQuery query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Post("/history/job-log/count")]
        Task<CountResult> GetListCount([Body] HistoricJobLogQuery query, CancellationToken cancellationToken = default);

        [Get("/history/job-log/{id}/stacktrace")]
        Task<HttpResponseMessage> GetStacktrace(string id, CancellationToken cancellationToken = default);
    }
}
