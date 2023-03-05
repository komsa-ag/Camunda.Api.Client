using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.Deployment
{
    internal interface IDeploymentRestService
    {
        [Get("/deployment")]
        Task<List<DeploymentInfo>> GetList(QueryDictionary query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Get("/deployment/count")]
        Task<CountResult> GetListCount(QueryDictionary query, CancellationToken cancellationToken = default);

        [Get("/deployment/{id}")]
        Task<DeploymentInfo> Get(string id, CancellationToken cancellationToken = default);

        [Post("/deployment/{id}/redeploy")]
        Task<DeploymentInfo> Redeploy(string id, [Body] RedeploymentInfo redeployment, CancellationToken cancellationToken = default);

        [Delete("/deployment/{id}")]
        Task Delete(string id, bool cascade, bool skipCustomListeners, bool skipIoMappings, CancellationToken cancellationToken = default);

        [Get("/deployment/{deploymentId}/resources")]
        Task<List<DeploymentResourceInfo>> GetDeploymentResources(string deploymentId, CancellationToken cancellationToken = default);

        [Get("/deployment/{deploymentId}/resources/{resourceId}")]
        Task<DeploymentResourceInfo> GetDeploymentResource(string deploymentId, string resourceId, CancellationToken cancellationToken = default);

        [Get("/deployment/{deploymentId}/resources/{resourceId}/data")]
        Task<HttpResponseMessage> GetDeploymentResourceData(string deploymentId, string resourceId, CancellationToken cancellationToken = default);

        [Post("/deployment/create"), Multipart]
        Task<DeploymentInfo> Create(HttpContentMultipartItem<PlainTextContent> deploymentName, HttpContentMultipartItem<PlainTextContent> enableDuplicateFiltering,
            HttpContentMultipartItem<PlainTextContent> deployChangedOnly, HttpContentMultipartItem<PlainTextContent> deploymentSource,
            HttpContentMultipartItem<PlainTextContent> tenantId, CancellationToken cancellationToken = default, params HttpContentMultipartItem<ResourceDataContent>[] resources);


    }
}
