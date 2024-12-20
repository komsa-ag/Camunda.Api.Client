﻿namespace Camunda.Api.Client.History;

public class HistoricActivityInstanceService
{
  private readonly IHistoricActivityInstanceRestService _api;

  internal HistoricActivityInstanceService(IHistoricActivityInstanceRestService api) => _api = api;

  public QueryResource<HistoricActivityInstanceQuery, HistoricActivityInstance> Query(
    HistoricActivityInstanceQuery query = null)
    => new(query, _api.GetList, _api.GetListCount);

  /// <param name="activityInstanceId">The id of the historic activity instance to be retrieved.</param>
  public HistoricActivityInstanceResource this[string activityInstanceId] => new(_api, activityInstanceId);
}