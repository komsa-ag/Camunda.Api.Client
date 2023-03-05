using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.CaseExecution
{
    internal interface ICaseExecutionRestService
    {
        [Get("/case-execution")]
        Task<List<CaseExecutionInfo>> GetList(QueryDictionary query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);
        [Get("/case-execution/count")]
        Task<CountResult> GetListCount(QueryDictionary query, CancellationToken cancellationToken = default);

        [Get("/case-execution/{id}")]
        Task<CaseExecutionInfo> Get(string id, CancellationToken cancellationToken = default);

        [Post("/case-execution/{id}/manual-start")]
        Task StartExecution(string id, [Body]CaseExecutionStart start, CancellationToken cancellationToken = default);

        [Post("/case-execution/{id}/complete")]
        Task CompleteExecution(string id, [Body]CaseExecutionComplete complete, CancellationToken cancellationToken = default);

        [Post("/case-execution/{id}/disable")]
        Task DisableExecution(string id, [Body]CaseExecutionDisable disable, CancellationToken cancellationToken = default);

        [Post("/case-execution/{id}/reenable")]
        Task ReEnableExecution(string id, [Body]CaseExecutionReEnable reenable, CancellationToken cancellationToken = default);

        [Post("/case-execution/{id}/terminate")]
        Task TerminateExecution(string id, [Body]CaseExecutionTerminate terminate, CancellationToken cancellationToken = default);
    }
}