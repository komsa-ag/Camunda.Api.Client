using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.History
{
    internal interface IHistoricCaseInstanceRestService
    {
        [Get("/history/case-instance/{id}")]
        Task<HistoricCaseInstance> Get(string id, CancellationToken cancellationToken = default);

        [Post("/history/case-instance")]
        Task<List<HistoricCaseInstance>> GetList([Body]HistoricCaseInstanceQuery query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Post("/history/case-instance/count")]
        Task<CountResult> GetListCount([Body] HistoricCaseInstanceQuery query, CancellationToken cancellationToken = default);
    }
}