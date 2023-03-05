using Camunda.Api.Client.UserTask;
using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.Filter
{
    internal interface IFilterRestService
    {
        [Get("/filter")]
        Task<List<FilterInfo.Response>> GetList(QueryDictionary query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Get("/filter/count")]
        Task<CountResult> GetListCount(QueryDictionary query, CancellationToken cancellationToken = default);

        [Get("/filter/{id}")]
        Task<FilterInfo.Response> Get(string id, CancellationToken cancellationToken = default);

        [Post("/filter/create")]
        Task<FilterInfo.Response> Create([Body] FilterInfo.Request filterInfo, CancellationToken cancellationToken = default);

        [Delete("/filter/{id}")]
        Task Delete(string id, CancellationToken cancellationToken = default);

        [Put("/filter/{id}")]
        Task Update(string id, [Body] FilterInfo.Request filterInfo, CancellationToken cancellationToken = default);

        [Get("/filter/{id}/singleResult")]
        Task<UserTaskInfo> Execute(string id, CancellationToken cancellationToken = default);

        [Post("/filter/{id}/list")]
        Task<List<UserTaskInfo>> ExecuteList(string id, int firstResult, int maxResults, [Body] TaskQuery query, CancellationToken cancellationToken = default);

        [Post("/filter/{id}/count")]
        Task<CountResult> ExecuteCount(string id, [Body] TaskQuery query, CancellationToken cancellationToken = default);
    }
}
