using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.History
{
    internal interface IHistoricUserOperationLogRestService
    {
        [Get("/history/user-operation/{id}")]
        Task<HistoricUserOperationLog> Get(string id, CancellationToken cancellationToken = default);

        [Get("/history/user-operation?processInstanceId={processInstanceId}&property=assignee")]
        Task<List<HistoricUserOperationLog>> GetHistoricAssignmentsOfProcess(string processInstanceId, CancellationToken cancellationToken = default);

        [Get("/history/user-operation?taskId={taskInstanceId}&property=assignee")]
        Task<List<HistoricUserOperationLog>> GetHistoricAssignmentsOfTask(string taskInstanceId, CancellationToken cancellationToken = default);

        [Get("/history/user-operation")]
        Task<List<HistoricUserOperationLog>> GetList(HistoricUserOperationLogQuery query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Get("/history/user-operation/count")]
        Task<CountResult> GetListCount(HistoricUserOperationLogQuery query, CancellationToken cancellationToken = default);

        [Put("/history/user-operation/{operationId}/set-annotation")]
        Task SetAnnotation(string operationId, [Body] HistoricUserOperationLogAnnotation historicUserOperationLogAnnotation, CancellationToken cancellationToken = default);

        [Put("/history/user-operation/{operationId}/clear-annotation")]
        Task ClearAnnotation(string operationId, CancellationToken cancellationToken = default);

    }
}
