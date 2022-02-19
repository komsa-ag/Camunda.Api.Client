namespace Camunda.Api.Client.CaseExecution;

public class CaseExecutionService
{
    private ICaseExecutionRestService _api;

    internal CaseExecutionService(ICaseExecutionRestService api)
    {
        _api = api;
    }

    public CaseExecutionResource this[string caseExecutionId] => new(_api, caseExecutionId);

    public QueryResource<CaseExecutionQuery, CaseExecutionInfo> Query(CaseExecutionQuery query = null) =>
        new(
            query,
            (q, f, m) => _api.GetList(q, f, m),
            q => _api.GetListCount(q));
}
