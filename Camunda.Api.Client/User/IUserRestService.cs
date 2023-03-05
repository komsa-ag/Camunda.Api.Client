using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.User
{
    internal interface IUserRestService
    {
        [Get("/user")]
        Task<List<UserProfileInfo>> GetList(QueryDictionary query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Get("/user/count")]
        Task<CountResult> GetListCount(QueryDictionary query, CancellationToken cancellationToken = default);

        [Get("/user/{id}/profile")]
        Task<UserProfileInfo> GetProfile(string id, CancellationToken cancellationToken = default);

        [Put("/user/{id}/profile")]
        Task UpdateProfile(string id, [Body] UserProfileInfo profile, CancellationToken cancellationToken = default);

        [Put("/user/{id}/credentials")]
        Task UpdateCredentials(string id, [Body] UserCredentialsInfo credentials, CancellationToken cancellationToken = default);

        [Delete("/user/{id}")]
        Task Delete(string id, CancellationToken cancellationToken = default);

        [Post("/user/create")]
        Task Create([Body] CreateUser createUser, CancellationToken cancellationToken = default);
    }
}
