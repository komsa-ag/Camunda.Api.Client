using System.Threading.Tasks;

namespace Camunda.Api.Client.History;

public class HistoricCaseActivityInstanceResource
{
  private readonly IHistoricCaseActivityInstanceRestService _api;
  private readonly string _caseActivityInstanceId;

  internal HistoricCaseActivityInstanceResource(IHistoricCaseActivityInstanceRestService api, string caseActivityInstanceId)
  {
    _api = api;
    _caseActivityInstanceId = caseActivityInstanceId;
  }

  /// <summary>
  /// Retrieves a historic case activity instance by id, according to the <see cref="HistoricCaseActivityInstance"/> interface in the engine.
  /// </summary>
  public Task<HistoricCaseActivityInstance> Get() => _api.Get(_caseActivityInstanceId);
}