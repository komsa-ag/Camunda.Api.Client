namespace Camunda.Api.Client.History;

public class HistoricJobLogService
{
  private readonly IHistoricJobLogRestService _api;

  internal HistoricJobLogService(IHistoricJobLogRestService api) => _api = api;

  public QueryResource<HistoricJobLogQuery, HistoricJobLog> Query(HistoricJobLogQuery query = null)
    => new(query, _api.GetList, _api.GetListCount);

  /// <param name="historicJobLogId">The id of the log entry.</param>
  public HistoricJobLogResource this[string historicJobLogId] => new(_api, historicJobLogId);
}