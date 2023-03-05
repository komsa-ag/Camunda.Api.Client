using Camunda.Api.Client.CaseInstance;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.CaseDefinition
{
    public class CaseDefinitionResourceByKey : CaseDefinitionResource
    {
        private ICaseDefinitionRestService _api;
        private string _caseDefinitionKey;

        internal CaseDefinitionResourceByKey(ICaseDefinitionRestService api, string caseDefinitionKey)
        {
            _api = api;
            _caseDefinitionKey = caseDefinitionKey;
        }

        public override Task<CaseDefinitionInfo> Get(CancellationToken cancellationToken = default) => _api.GetByKey(_caseDefinitionKey, cancellationToken);

        public override Task<CaseDefinitionDiagram> GetXml(CancellationToken cancellationToken = default) => _api.GetXmlByKey(_caseDefinitionKey, cancellationToken);

        public override async Task<HttpContent> GetDiagram(CancellationToken cancellationToken = default) => (await _api.GetDiagramByKey(_caseDefinitionKey, cancellationToken)).Content;

        public override Task<CaseInstanceInfo> CreateCaseInstance(CreateCaseInstance parameters, CancellationToken cancellationToken = default) => _api.CreateCaseInstanceByKey(_caseDefinitionKey, parameters, cancellationToken);

        public override string ToString() => _caseDefinitionKey;
    }
}