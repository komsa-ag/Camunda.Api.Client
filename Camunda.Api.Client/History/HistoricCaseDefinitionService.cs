namespace Camunda.Api.Client.History;

public class HistoricCaseDefinitionService
{
  private readonly IHistoricCaseDefinitionRestService _api;

  internal HistoricCaseDefinitionService(IHistoricCaseDefinitionRestService api) 
    => _api = api;

  public HistoricCaseDefinitionResource this[string caseDefinitionId] 
    => new(_api, caseDefinitionId);
}