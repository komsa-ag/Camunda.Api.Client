using System.Threading.Tasks;

namespace Camunda.Api.Client.History;

public class HistoricUserOperationLogResource
{
  private readonly IHistoricUserOperationLogRestService _api;

  private readonly string _operationId;

  internal HistoricUserOperationLogResource(IHistoricUserOperationLogRestService api, string operationId)
  {
    _api = api;
    _operationId = operationId;
  }

  /// <summary>
  /// Retrieves a single task by its id.
  /// </summary>
  public Task<HistoricUserOperationLog> Get() => _api.Get(_operationId);

  /// <summary>
  /// Set an annotation for auditing reasons.
  /// </summary>
  /// <param name="historicUserOperationLogAnnotation"></param>
  /// <returns></returns>
  public Task SetAnnotation(HistoricUserOperationLogAnnotation historicUserOperationLogAnnotation) 
    => _api.SetAnnotation(_operationId, historicUserOperationLogAnnotation);


  /// <summary>
  /// Clear the annotation which was previously set for auditing reasons.
  /// </summary>
  /// <returns></returns>
  public Task ClearAnnotation() => _api.ClearAnnotation(_operationId);
}