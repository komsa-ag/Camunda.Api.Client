using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.JobDefinition
{
    internal interface IJobDefinitionRestService
    {
        [Get("/job-definition/{jobDefinitionId}")]
        Task<JobDefinitionInfo> Get(string jobDefinitionId, CancellationToken cancellationToken = default);

        [Post("/job-definition")]
        Task<List<JobDefinitionInfo>> GetList([Body] JobDefinitionQuery query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Post("/job-definition/count")]
        Task<CountResult> GetListCount([Body] JobDefinitionQuery query, CancellationToken cancellationToken = default);

        [Put("/job-definition/suspended")]
        Task UpdateSuspensionState([Body]JobDefinitionSuspensionState state, CancellationToken cancellationToken = default);

        [Put("/job-definition/{jobDefinitionId}/suspended")]
        Task UpdateSuspensionStateForId(string jobDefinitionId, [Body] SuspensionState suspensionState, CancellationToken cancellationToken = default);

        [Put("/job-definition/{jobDefinitionId}/retries")]
        Task SetJobRetries(string jobDefinitionId, [Body] RetriesInfo retries, CancellationToken cancellationToken = default);

        [Put("/job-definition/{jobDefinitionId}/jobPriority")]
        Task SetJobPriority(string jobDefinitionId, [Body] JobDefinitionPriority priority, CancellationToken cancellationToken = default);
    }
}
