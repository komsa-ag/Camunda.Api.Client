using Camunda.Api.Client.Batch;
using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.Job
{
    internal interface IJobRestService
    {
        [Get("/job/{jobId}")]
        Task<JobInfo> Get(string jobId, CancellationToken cancellationToken = default);

        [Post("/job")]
        Task<List<JobInfo>> GetList([Body] JobQuery query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Post("/job/count")]
        Task<CountResult> GetListCount([Body] JobQuery query, CancellationToken cancellationToken = default);

        [Get("/job/{jobId}/stacktrace")]
        Task<HttpResponseMessage> GetStacktrace(string jobId, CancellationToken cancellationToken = default);

        [Post("/job/{jobId}/execute")]
        Task ExecuteJob(string jobId, CancellationToken cancellationToken = default);

        [Put("/job/{jobId}/duedate")]
        Task SetJobDuedate(string jobId, [Body] JobDuedateInfo duedate, CancellationToken cancellationToken = default);

        [Put("/job/{jobId}/suspended")]
        Task UpdateSuspensionStateForId(string jobId, [Body] SuspensionState state, CancellationToken cancellationToken = default);

        [Put("/job/suspended")]
        Task UpdateSuspensionState([Body] JobSuspensionState state, CancellationToken cancellationToken = default);

        [Put("/job/{jobId}/priority")]
        Task SetJobPriority(string jobId, [Body] PriorityInfo priority, CancellationToken cancellationToken = default);

        [Put("/job/{jobId}/retries")]
        Task SetJobRetries(string jobId, [Body] RetriesInfo retries, CancellationToken cancellationToken = default);

        [Delete("/job/{jobId}")]
        Task DeleteJob(string jobId, CancellationToken cancellationToken = default);

        [Post("/job/retries")]
        Task<BatchInfo> SetJobRetriesAsync([Body] JobRetries retries, CancellationToken cancellationToken = default);
    }
}
