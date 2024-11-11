namespace Camunda.Api.Client.History;

public class HistoricDecisionInstanceService
{
  private readonly IHistoricDecisionInstanceRestService _api;

  internal HistoricDecisionInstanceService(IHistoricDecisionInstanceRestService api) => _api = api;

  public QueryResource<HistoricDecisionInstanceQuery, HistoricDecisionInstance> Query(
    HistoricDecisionInstanceQuery query = null)
    => new(query, (q, f, m) => _api.GetList(q, f, m), q => _api.GetListCount(q));

  /// <param name="decisionInstanceId">The id of the historic decision instance to be retrieved.</param>
  public HistoricDecisionInstanceResource this[string decisionInstanceId] 
    => new(_api, decisionInstanceId);
}