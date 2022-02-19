namespace Camunda.Api.Client.Execution;

public class ExecutionService
{
    private IExecutionRestService _api;

    internal ExecutionService(IExecutionRestService api)
    {
        _api = api;
    }

    public ExecutionResource this[string executionId] => new(_api, executionId);

    public QueryResource<ExecutionQuery, ExecutionInfo> Query(ExecutionQuery query = null) =>
        new(query, _api.GetList, _api.GetListCount);

}
