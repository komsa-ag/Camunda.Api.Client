using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.History
{
    internal interface IHistoricActivityInstanceRestService
    {
        [Get("/history/activity-instance/{id}")]
        Task<HistoricActivityInstance> Get(string id, CancellationToken cancellationToken = default);

        [Post("/history/activity-instance")]
        Task<List<HistoricActivityInstance>> GetList([Body] HistoricActivityInstanceQuery query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Post("/history/activity-instance/count")]
        Task<CountResult> GetListCount([Body] HistoricActivityInstanceQuery query, CancellationToken cancellationToken = default);
    }
}
