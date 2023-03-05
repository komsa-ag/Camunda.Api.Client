using Camunda.Api.Client.Batch;
using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.ProcessInstance
{
    internal interface IProcessInstanceRestService
    {
        [Get("/process-instance/{processInstanceId}")]
        Task<ProcessInstanceInfo> Get(string processInstanceId, CancellationToken cancellationToken = default);

        [Post("/process-instance")]
        Task<List<ProcessInstanceInfo>> GetList([Body] ProcessInstanceQuery query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Post("/process-instance/count")]
        Task<CountResult> GetListCount([Body] ProcessInstanceQuery query, CancellationToken cancellationToken = default);

        [Get("/process-instance/{processInstanceId}/activity-instances")]
        Task<ActivityInstanceInfo> GetActivityInstanceTree(string processInstanceId, CancellationToken cancellationToken = default);

        [Delete("/process-instance/{processInstanceId}")]
        Task DeleteProcessInstance(string processInstanceId, bool skipCustomListeners, bool skipIoMappings, bool skipSubprocesses, CancellationToken cancellationToken = default);

        [Put("/process-instance/suspended")]
        Task UpdateSuspensionState([Body] ProcessInstanceSuspensionState state, CancellationToken cancellationToken = default);

        [Put("/process-instance/{processInstanceId}/suspended")]
        Task UpdateSuspensionStateForId(string processInstanceId, [Body] SuspensionState state, CancellationToken cancellationToken = default);

        [Post("/process-instance/{processInstanceId}/modification")]
        Task ModifyProcessInstance(string processInstanceId, [Body] ProcessInstanceModification modification, CancellationToken cancellationToken = default);

        [Post("/process-instance/job-retries")]
        Task<BatchInfo> SetRetriesByProcess([Body] JobRetriesByProcess retries, CancellationToken cancellationToken = default);

        [Post("/process-instance/delete")]
        Task<BatchInfo> DeleteProcessInstanceAsync([Body] DeleteProcessInstances deleteProcessInstances, CancellationToken cancellationToken = default);

        #region Variables

        [Delete("/process-instance/{id}/variables/{varName}")]
        Task DeleteVariable(string id, string varName, CancellationToken cancellationToken = default);

        [Get("/process-instance/{id}/variables/{varName}")]
        Task<VariableValue> GetVariable(string id, string varName, bool deserializeValue = true, CancellationToken cancellationToken = default);

        [Get("/process-instance/{id}/variables")]
        Task<Dictionary<string, VariableValue>> GetVariables(string id, bool deserializeValues = true, CancellationToken cancellationToken = default);

        [Get("/process-instance/{id}/variables/{varName}/data")]
        Task<HttpResponseMessage> GetBinaryVariable(string id, string varName, CancellationToken cancellationToken = default);

        [Post("/process-instance/{id}/variables/{varName}/data"), Multipart]
        Task SetBinaryVariable(string id, string varName, BinaryDataContent data, ValueTypeContent valueType, CancellationToken cancellationToken = default);

        [Post("/process-instance/{id}/variables")]
        Task ModifyVariables(string id, PatchVariables patch, CancellationToken cancellationToken = default);

        [Put("/process-instance/{id}/variables/{varName}")]
        Task PutVariable(string id, string varName, [Body] VariableValue variable, CancellationToken cancellationToken = default);

        #endregion

    }
}
