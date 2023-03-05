using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.DecisionDefinition
{
    internal interface IDecisionDefinitionRestService
    {
        [Get("/decision-definition")]
        Task<List<DecisionDefinitionInfo>> GetList(QueryDictionary query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Get("/decision-definition/count")]
        Task<CountResult> GetListCount(QueryDictionary query, CancellationToken cancellationToken = default);


        [Get("/decision-definition/{id}")]
        Task<DecisionDefinitionInfo> GetById(string id, CancellationToken cancellationToken = default);
        [Get("/decision-definition/key/{key}")]
        Task<DecisionDefinitionInfo> GetByKey(string key, CancellationToken cancellationToken = default);
        [Get("/decision-definition/key/{key}/tenant-id/{tenantId}")]
        Task<DecisionDefinitionInfo> GetByKeyAndTenantId(string key, string tenantId, CancellationToken cancellationToken = default);


        [Get("/decision-definition/{id}/xml")]
        Task<DecisionDefinitionDiagram> GetXmlById(string id, CancellationToken cancellationToken = default);
        [Get("/decision-definition/key/{key}/xml")]
        Task<DecisionDefinitionDiagram> GetXmlByKey(string key, CancellationToken cancellationToken = default);
        [Get("/decision-definition/key/{key}/tenant-id/{tenantId}/xml")]
        Task<DecisionDefinitionDiagram> GetXmlByKeyAndTenantId(string key, string tenantId, CancellationToken cancellationToken = default);


        [Get("/decision-definition/{id}/diagram")]
        Task<HttpResponseMessage> GetDiagramById(string id, CancellationToken cancellationToken = default);
        [Get("/decision-definition/key/{key}/diagram")]
        Task<HttpResponseMessage> GetDiagramByKey(string key, CancellationToken cancellationToken = default);
        [Get("/decision-definition/key/{key}/tenant-id/{tenantId}/diagram")]
        Task<HttpResponseMessage> GetDiagramByKeyAndTenantId(string key, string tenantId, CancellationToken cancellationToken = default);


        [Post("/decision-definition/{id}/evaluate")]
        Task<List<Dictionary<string, VariableValue>>> EvaluateById(string id, [Body] EvaluateDecision parameters, CancellationToken cancellationToken = default);
        [Post("/decision-definition/key/{key}/evaluate")]
        Task<List<Dictionary<string, VariableValue>>> EvaluateByKey(string key, [Body] EvaluateDecision parameters, CancellationToken cancellationToken = default);
        [Post("/decision-definition/key/{key}/tenant-id/{tenantId}/evaluate")]
        Task<List<Dictionary<string, VariableValue>>> EvaluateByKeyAndTenantId(string key, string tenantId, [Body] EvaluateDecision parameters, CancellationToken cancellationToken = default);
    }
}
