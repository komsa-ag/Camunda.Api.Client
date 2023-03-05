using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.Tenant
{
    internal interface ITenantRestService
    {
        [Get("/tenant")]
        Task<List<TenantInfo>> GetList(QueryDictionary query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Get("/tenant/count")]
        Task<CountResult> GetListCount(QueryDictionary query, CancellationToken cancellationToken = default);

        [Post("/tenant/create")]
        Task Create([Body] TenantInfo tenant, CancellationToken cancellationToken = default);
    }
}