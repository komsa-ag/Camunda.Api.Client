using Camunda.Api.Client.CaseInstance;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.CaseDefinition
{
    public class CaseDefinitionResourceByKeyAndTenantId : CaseDefinitionResource
    {
        private ICaseDefinitionRestService _api;
        private string _caseDefinitionKey, _tenantId;

        internal CaseDefinitionResourceByKeyAndTenantId(ICaseDefinitionRestService api, string caseDefinitionKey, string tenantId)
        {
            _api = api;
            _caseDefinitionKey = caseDefinitionKey;
            _tenantId = tenantId;
        }

        public override Task<CaseDefinitionInfo> Get(CancellationToken cancellationToken = default) => _api.GetByKeyAndTenantId(_caseDefinitionKey, _tenantId, cancellationToken);

        public override Task<CaseDefinitionDiagram> GetXml(CancellationToken cancellationToken = default) => _api.GetXmlByKeyAndTenantId(_caseDefinitionKey, _tenantId, cancellationToken);

        public override async Task<HttpContent> GetDiagram(CancellationToken cancellationToken = default) => (await _api.GetDiagramByKeyAndTenantId(_caseDefinitionKey, _tenantId, cancellationToken)).Content;

        public override Task<CaseInstanceInfo> CreateCaseInstance(CreateCaseInstance parameters, CancellationToken cancellationToken = default) => _api.CreateCaseInstanceByKeyAndTenantId(_caseDefinitionKey, _tenantId, parameters, cancellationToken);

        public override string ToString() => _caseDefinitionKey;
    }
}