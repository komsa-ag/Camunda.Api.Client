using Camunda.Api.Client.CaseInstance;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.CaseDefinition
{
    public abstract class CaseDefinitionResource
    {
        /// <summary>
        /// Retrieves a case definition according to the CaseDefinition interface in the engine.
        /// </summary>
        public abstract Task<CaseDefinitionInfo> Get(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the CMMN XML of a case definition.
        /// </summary>
        public abstract Task<CaseDefinitionDiagram> GetXml(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the diagram of a case definition.
        /// </summary>
        /// <returns></returns>
        public abstract Task<HttpContent> GetDiagram(CancellationToken cancellationToken = default);

        /// <summary>
        /// Instantiates a given case definition. Case variables and business key may be supplied in the request body.
        /// </summary>
        public abstract Task<CaseInstanceInfo> CreateCaseInstance(CreateCaseInstance parameters, CancellationToken cancellationToken = default);

        // TODO: Update history time to live
    }
}