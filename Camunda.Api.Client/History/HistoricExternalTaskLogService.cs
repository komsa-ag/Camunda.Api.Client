using System.Collections.Generic;
using System.Threading.Tasks;

namespace Camunda.Api.Client.History;

public class HistoricExternalTaskLogService
{
    private IHistoricExternalTaskLogRestService _api;

    internal HistoricExternalTaskLogService(IHistoricExternalTaskLogRestService api)
    {
        _api = api;
    }

    public QueryResource<HistoricExternalTaskLogQuery, HistoricExternalTaskLog> Query(HistoricExternalTaskLogQuery query = null) =>
        new(query, _api.GetList, _api.GetListCount);

    public HistoricExternalTaskLogResource this[string logId] => new(_api, logId);
}
