using Camunda.Api.Client.CaseInstance;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.CaseDefinition
{
    public class CaseDefinitionResourceById : CaseDefinitionResource
    {
        private ICaseDefinitionRestService _api;
        private string _caseDefinitionId;

        internal CaseDefinitionResourceById(ICaseDefinitionRestService api, string caseDefinitionId)
        {
            _api = api;
            _caseDefinitionId = caseDefinitionId;
        }

        public override Task<CaseDefinitionInfo> Get(CancellationToken cancellationToken = default) => _api.GetById(_caseDefinitionId, cancellationToken);

        public override Task<CaseDefinitionDiagram> GetXml(CancellationToken cancellationToken = default) => _api.GetXmlById(_caseDefinitionId, cancellationToken);

        public override async Task<HttpContent> GetDiagram(CancellationToken cancellationToken = default) => (await _api.GetDiagramById(_caseDefinitionId, cancellationToken)).Content;

        public override Task<CaseInstanceInfo> CreateCaseInstance(CreateCaseInstance parameters, CancellationToken cancellationToken = default) => _api.CreateCaseInstanceById(_caseDefinitionId, parameters, cancellationToken);

        public override string ToString() => _caseDefinitionId;
    }
}