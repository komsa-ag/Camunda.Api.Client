using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.History
{
    internal interface IHistoricExternalTaskLogRestService
    {
        [Post("/history/external-task-log")]
        Task<List<HistoricExternalTaskLog>> GetList([Body] HistoricExternalTaskLogQuery query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Post("/history/external-task-log/count")]
        Task<CountResult> GetListCount([Body] HistoricExternalTaskLogQuery query, CancellationToken cancellationToken = default);

        [Get("/history/external-task-log/{id}")]
        Task<HistoricExternalTaskLog> Get(string id, CancellationToken cancellationToken = default);

        [Get("/history/external-task-log/{id}/error-details")]
        Task<string> GetErrorDetails(string id, CancellationToken cancellationToken = default);
    }
}
