using Camunda.Api.Client.CaseInstance;
using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.CaseDefinition
{
    internal interface ICaseDefinitionRestService
    {
        [Get("/case-definition")]
        Task<List<CaseDefinitionInfo>> GetList(QueryDictionary query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);
        [Get("/case-definition/count")]
        Task<CountResult> GetListCount(QueryDictionary query, CancellationToken cancellationToken = default);


        [Get("/case-definition/{id}")]
        Task<CaseDefinitionInfo> GetById(string id, CancellationToken cancellationToken = default);
        [Get("/case-definition/key/{key}")]
        Task<CaseDefinitionInfo> GetByKey(string key, CancellationToken cancellationToken = default);
        [Get("/case-definition/key/{key}/tenant-id/{tenantId}")]
        Task<CaseDefinitionInfo> GetByKeyAndTenantId(string key, string tenantId, CancellationToken cancellationToken = default);


        [Get("/case-definition/{id}/xml")]
        Task<CaseDefinitionDiagram> GetXmlById(string id, CancellationToken cancellationToken = default);
        [Get("/case-definition/key/{key}/xml")]
        Task<CaseDefinitionDiagram> GetXmlByKey(string key, CancellationToken cancellationToken = default);
        [Get("/case-definition/key/{key}/tenant-id/{tenantId}/xml")]
        Task<CaseDefinitionDiagram> GetXmlByKeyAndTenantId(string key, string tenantId, CancellationToken cancellationToken = default);


        [Get("/case-definition/{id}/diagram")]
        Task<HttpResponseMessage> GetDiagramById(string id, CancellationToken cancellationToken = default);
        [Get("/case-definition/key/{key}/diagram")]
        Task<HttpResponseMessage> GetDiagramByKey(string key, CancellationToken cancellationToken = default);
        [Get("/case-definition/key/{key}/tenant-id/{tenantId}/diagram")]
        Task<HttpResponseMessage> GetDiagramByKeyAndTenantId(string key, string tenantId, CancellationToken cancellationToken = default);


        [Post("/case-definition/{id}/create")]
        Task<CaseInstanceInfo> CreateCaseInstanceById(string id, [Body] CreateCaseInstance parameters, CancellationToken cancellationToken = default);
        [Post("/case-definition/key/{key}/create")]
        Task<CaseInstanceInfo> CreateCaseInstanceByKey(string key, [Body] CreateCaseInstance parameters, CancellationToken cancellationToken = default);
        [Post("/case-definition/key/{key}/tenant-id/{tenantId}/create")]
        Task<CaseInstanceInfo> CreateCaseInstanceByKeyAndTenantId(string key, string tenantId, [Body] CreateCaseInstance parameters, CancellationToken cancellationToken = default);
    }
}
