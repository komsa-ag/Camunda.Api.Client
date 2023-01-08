using Refit;
using System.Threading.Tasks;

namespace Camunda.Api.Client.Identity
{
    public interface IIdentityRestService
	{
		[Get("/identity/groups")]
		Task<IdentityGroupMembership> GetMembership(QueryDictionary query);

		[Post("/identity/verify")]
		Task<IdentityVerifiedUser> Verify([Body]IdentityUserCredentials credentials);
	}
}
