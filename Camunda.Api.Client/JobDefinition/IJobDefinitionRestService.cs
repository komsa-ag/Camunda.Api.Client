﻿using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Camunda.Api.Client.JobDefinition
{
    public interface IJobDefinitionRestService
    {
        [Get("/job-definition/{jobDefinitionId}")]
        Task<JobDefinitionInfo> Get(string jobDefinitionId);

        [Post("/job-definition")]
        Task<List<JobDefinitionInfo>> GetList([Body] JobDefinitionQuery query, int? firstResult, int? maxResults);

        [Post("/job-definition/count")]
        Task<CountResult> GetListCount([Body] JobDefinitionQuery query);

        [Put("/job-definition/suspended")]
        Task UpdateSuspensionState([Body]JobDefinitionSuspensionState state);

        [Put("/job-definition/{jobDefinitionId}/suspended")]
        Task UpdateSuspensionStateForId(string jobDefinitionId, [Body] SuspensionState suspensionState);

        [Put("/job-definition/{jobDefinitionId}/retries")]
        Task SetJobRetries(string jobDefinitionId, [Body] RetriesInfo retries);

        [Put("/job-definition/{jobDefinitionId}/jobPriority")]
        Task SetJobPriority(string jobDefinitionId, [Body] JobDefinitionPriority priority);
    }
}
