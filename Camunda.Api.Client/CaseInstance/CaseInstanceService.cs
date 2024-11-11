namespace Camunda.Api.Client.CaseInstance;

public class CaseInstanceService
{
  private readonly ICaseInstanceRestService _api;

  internal CaseInstanceService(ICaseInstanceRestService api) => _api = api;

  public QueryResource<CaseInstanceQuery, CaseInstanceInfo> Query(CaseInstanceQuery query = null)
    => new(query, _api.GetList, _api.GetListCount);

  /// <param name="caseInstanceId">Id of specific case instance</param>
  public CaseInstanceResource this[string caseInstanceId] => new(_api, caseInstanceId);
}
