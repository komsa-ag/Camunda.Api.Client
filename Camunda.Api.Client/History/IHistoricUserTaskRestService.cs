using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.History
{
    internal interface IHistoricUserTaskRestService
    {
        [Post("/history/task")]
        Task<List<HistoricTask>> GetList([Body] HistoricTaskQuery query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Post("/history/task/count")]
        Task<CountResult> GetListCount([Body] HistoricTaskQuery query, CancellationToken cancellationToken = default);

        [Get("/history/task/report")]
        Task<List<DurationReportResult>> GetDurationReport(QueryDictionary query, CancellationToken cancellationToken = default);

        [Get("/history/task/report")]
        Task<List<CountReportResult>> GetCountReport(QueryDictionary query, CancellationToken cancellationToken = default);
    }
}
