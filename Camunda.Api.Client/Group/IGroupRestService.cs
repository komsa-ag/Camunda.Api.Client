using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.Group
{
	internal interface IGroupRestService
	{
		[Get("/group")]
		Task<List<GroupInfo>> GetList(QueryDictionary query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

		[Get("/group/count")]
		Task<CountResult> GetListCount(QueryDictionary query, CancellationToken cancellationToken = default);

		[Get("/group/{id}")]
		Task<GroupInfo> Get(string id, CancellationToken cancellationToken = default);

		[Post("/group/create")]
		Task Create([Body] GroupInfo group, CancellationToken cancellationToken = default);

		[Put("/group/{id}")]
		Task Update(string id, [Body] GroupInfo group, CancellationToken cancellationToken = default);

		[Delete("/group/{id}")]
		Task Delete(string id);

        [Put("/group/{id}/members/{userId}")]
        Task AddMember(string id, string userId, CancellationToken cancellationToken = default);

        [Delete("/group/{id}/members/{userId}")]
        Task RemoveMember(string id, string userId, CancellationToken cancellationToken = default);
    }
}
