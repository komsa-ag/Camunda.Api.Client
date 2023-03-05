using Camunda.Api.Client.Batch;
using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.History
{
    internal interface IHistoricProcessInstanceRestService
    {
        [Get("/history/process-instance/{id}")]
        Task<HistoricProcessInstance> Get(string id, CancellationToken cancellationToken = default);

        [Post("/history/process-instance")]
        Task<List<HistoricProcessInstance>> GetList([Body] HistoricProcessInstanceQuery query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Post("/history/process-instance/count")]
        Task<CountResult> GetListCount([Body] HistoricProcessInstanceQuery query, CancellationToken cancellationToken = default);

        [Delete("/history/process-instance/{id}")]
        Task Delete(string id, CancellationToken cancellationToken = default);

        [Get("/history/process-instance/report")]
        Task<List<DurationReportResult>> GetDurationReport(QueryDictionary query, CancellationToken cancellationToken = default);

        [Post("/history/process-instance/delete")]
        Task<BatchInfo> DeleteAsync([Body] DeleteHistoricProcessInstances deleteHistoricProcessInstances, CancellationToken cancellationToken = default);
    }
}
