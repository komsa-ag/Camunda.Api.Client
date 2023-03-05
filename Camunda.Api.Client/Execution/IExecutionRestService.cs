using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.Execution
{
    internal interface IExecutionRestService
    {
        [Post("/execution")]
        Task<List<ExecutionInfo>> GetList([Body] ExecutionQuery query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Post("/execution/count")]
        Task<CountResult> GetListCount([Body] ExecutionQuery query, CancellationToken cancellationToken = default);

        [Get("/execution/{id}")]
        Task<ExecutionInfo> Get(string id, CancellationToken cancellationToken = default);

        [Get("/execution/{id}/messageSubscriptions/{messageName}")]
        Task<EventSubscription> GetMessageEventSubscription(string id, string messageName, CancellationToken cancellationToken = default);

        [Post("/execution/{id}/messageSubscriptions/{messageName}/trigger")]
        Task TriggerMessageEventSubscription(string id, string messageName, [Body] ExecutionTrigger trigger, CancellationToken cancellationToken = default);

        [Post("/execution/{id}/signal")]
        Task TriggerExecution(string id, [Body] ExecutionTrigger trigger, CancellationToken cancellationToken = default);

        #region Local Variables

        [Delete("/execution/{id}/localVariables/{varName}")]
        Task DeleteLocalVariable(string id, string varName, CancellationToken cancellationToken = default);

        [Get("/execution/{id}/localVariables/{varName}")]
        Task<VariableValue> GetLocalVariable(string id, string varName, bool deserializeValue = true, CancellationToken cancellationToken = default);

        [Get("/execution/{id}/localVariables")]
        Task<Dictionary<string, VariableValue>> GetLocalVariables(string id, bool deserializeValues = true, CancellationToken cancellationToken = default);

        [Get("/execution/{id}/localVariables/{varName}/data")]
        Task<HttpResponseMessage> GetBinaryLocalVariable(string id, string varName, CancellationToken cancellationToken = default);

        [Post("/execution/{id}/localVariables/{varName}/data"), Multipart]
        Task SetBinaryLocalVariable(string id, string varName, BinaryDataContent data, ValueTypeContent valueType, CancellationToken cancellationToken = default);

        [Post("/execution/{id}/localVariables")]
        Task ModifyLocalVariables(string id, PatchVariables patch, CancellationToken cancellationToken = default);

        [Put("/execution/{id}/localVariables/{varName}")]
        Task PutLocalVariable(string id, string varName, [Body] VariableValue variable, CancellationToken cancellationToken = default);

        #endregion

    }
}
