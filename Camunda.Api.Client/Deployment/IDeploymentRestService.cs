﻿using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Camunda.Api.Client.Deployment
{
    public interface IDeploymentRestService
    {
        [Get("/deployment")]
        Task<List<DeploymentInfo>> GetList(QueryDictionary query, int? firstResult, int? maxResults);

        [Get("/deployment/count")]
        Task<CountResult> GetListCount(QueryDictionary query);

        [Get("/deployment/{id}")]
        Task<DeploymentInfo> Get(string id);

        [Post("/deployment/{id}/redeploy")]
        Task<DeploymentInfo> Redeploy(string id, [Body] RedeploymentInfo redeployment);

        [Delete("/deployment/{id}")]
        Task Delete(string id, bool cascade, bool skipCustomListeners, bool skipIoMappings);

        [Get("/deployment/{deploymentId}/resources")]
        Task<List<DeploymentResourceInfo>> GetDeploymentResources(string deploymentId);

        [Get("/deployment/{deploymentId}/resources/{resourceId}")]
        Task<DeploymentResourceInfo> GetDeploymentResource(string deploymentId, string resourceId);

        [Get("/deployment/{deploymentId}/resources/{resourceId}/data")]
        Task<HttpResponseMessage> GetDeploymentResourceData(string deploymentId, string resourceId);

        [Post("/deployment/create"), Multipart]
        Task<DeploymentInfo> Create(HttpContentMultipartItem<PlainTextContent> deploymentName, HttpContentMultipartItem<PlainTextContent> enableDuplicateFiltering,
            HttpContentMultipartItem<PlainTextContent> deployChangedOnly, HttpContentMultipartItem<PlainTextContent> deploymentSource,
            HttpContentMultipartItem<PlainTextContent> tenantId, params HttpContentMultipartItem<ResourceDataContent>[] resources);


    }
}
