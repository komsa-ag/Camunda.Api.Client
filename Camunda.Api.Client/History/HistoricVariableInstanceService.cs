namespace Camunda.Api.Client.History;

public class HistoricVariableInstanceService
{
  private readonly IHistoricVariableInstanceRestService _api;

  internal HistoricVariableInstanceService(IHistoricVariableInstanceRestService api) => _api = api;

  public HistoricVariableInstanceQueryResource Query(HistoricVariableInstanceQuery query = null)
    => new(_api, query ?? new());

  /// <param name="variableId">The id of the variable instance.</param>
  public HistoricVariableInstanceResource this[string variableId] => new(_api, variableId);
}