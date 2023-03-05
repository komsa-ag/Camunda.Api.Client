#region Usings

using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Refit;

#endregion

namespace Camunda.Api.Client.CaseInstance
{
    internal interface ICaseInstanceRestService
    {
        [Get("/case-instance/{id}/variables")]
        Task<Dictionary<string, VariableValue>> GetVariables(string id, bool? deserializeValues, CancellationToken cancellationToken = default);

        [Get("/case-instance/{id}/variables/{varName}")]
        Task<VariableValue> GetVariableValue(string id, string varName, bool? deserializeValue, CancellationToken cancellationToken = default);

        // TODO: check if HttpWebResponse is indeed the correct return type
        [Get("/case-instance/{id}/variables/{varName}/data")]
        Task<HttpResponseMessage> GetBinaryVariable(string id, string varName, CancellationToken cancellationToken = default);

        [Post("/case-instance/{id}/variables")]
        Task ModifyVariables(string id, [Body] PatchVariables patch, CancellationToken cancellationToken = default);

        [Put("/case-instance/{id}/variables/{varName}")]
        Task UpdateVariable(string id, string varName, [Body] VariableValue value, CancellationToken cancellationToken = default);

        [Post("/case-instance/{id}/variables/{varName}/data")]
        Task SetBinaryVariable(string id, string varName, BinaryDataContent data, ValueTypeContent valueType, CancellationToken cancellationToken = default);

        [Delete("/case-instance/{id}/variables/{varName}")]
        Task DeleteVariable(string id, string varName, CancellationToken cancellationToken = default);

        [Get("/case-instance/{id}")]
        Task<CaseInstanceInfo> Get(string id, CancellationToken cancellationToken = default);

        [Post("/case-instance")]
        Task<List<CaseInstanceInfo>> GetList([Body] CaseInstanceQuery query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Post("/case-instance/count")]
        Task<CountResult> GetListCount([Body] CaseInstanceQuery query, CancellationToken cancellationToken = default);

        [Post("/case-instance/{id}/complete")]
        Task Complete(string id, [Body] ChangeCaseInstanceState completeCaseInstance, CancellationToken cancellationToken = default);

        [Post("/case-instance/{id}/close")]
        Task Close(string id, [Body] ChangeCaseInstanceState closeCaseInstance, CancellationToken cancellationToken = default);

        [Post("/case-instance/{id}/terminate")]
        Task Terminate(string id, [Body] ChangeCaseInstanceState terminateCaseInstance, CancellationToken cancellationToken = default);
    }
}
