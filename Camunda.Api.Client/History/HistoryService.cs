namespace Camunda.Api.Client.History;

public class HistoryService
{
  private readonly CamundaClient.HistoricApi _api;

  internal HistoryService(CamundaClient.HistoricApi api) => _api = api;

  /// <summary>
  /// Case Definition
  /// </summary>
  public HistoricCaseDefinitionService CaseDefinitions
    => new(_api.CaseDefinitionApi.Value);

  /// <summary>
  /// Case Instance
  /// </summary>
  public HistoricCaseInstanceService CaseInstances
    => new(_api.CaseInstanceApi.Value);

  /// <summary>
  /// Case Activity Instance
  /// </summary>
  public HistoricCaseActivityInstanceService CaseActivityInstances
    => new(_api.CaseActivityInstanceApi.Value);

  /// <summary>
  /// Decision Instance
  /// </summary>
  public HistoricDecisionInstanceService DecisionInstances
    => new(_api.DecisionInstanceApi.Value);

  /// <summary>
  /// Process Instance
  /// </summary>
  public HistoricProcessInstanceService ProcessInstances
    => new(_api.ProcessInstanceApi.Value);

  /// <summary>
  /// Activity Instance
  /// </summary>
  public HistoricActivityInstanceService ActivityInstances
    => new(_api.ActivityInstanceApi.Value);

  /// <summary>
  /// Job Log
  /// </summary>
  public HistoricJobLogService JobLogs
    => new(_api.JobLogApi.Value);

  /// <summary>
  /// Incident
  /// </summary>
  public HistoricIncidentService Incidents
    => new(_api.IncidentApi.Value);

  /// <summary>
  /// Variable Instance
  /// </summary>
  public HistoricVariableInstanceService VariableInstances
    => new(_api.VariableInstanceApi.Value);

  /// <summary>
  /// Detail
  /// </summary>
  public HistoricDetailService Detail => new(_api.DetailApi.Value);

  /// <summary>
  /// User Task
  /// </summary>
  public HistoricUserTaskService UserTasks => new(_api.UserTaskApi.Value);

  /// <summary>
  /// Process Definition
  /// </summary>
  public HistoricProcessDefinitionService ProcessDefinitions
    => new(_api.ProcessDefinitionApi.Value);

  /// <summary>
  /// External Task Log
  /// </summary>
  public HistoricExternalTaskLogService ExternalTaskLogs
    => new(_api.ExternalTaskLogApi.Value);

  /// <summary>
  /// User Operation Logs
  /// </summary>
  public HistoricUserOperationLogService UserOperationLogs
    => new(_api.UserOperationLogApi.Value);
}