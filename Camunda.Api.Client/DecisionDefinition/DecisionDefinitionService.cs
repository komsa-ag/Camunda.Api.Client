﻿namespace Camunda.Api.Client.DecisionDefinition;

public class DecisionDefinitionService
{
  private readonly IDecisionDefinitionRestService _api;

  internal DecisionDefinitionService(IDecisionDefinitionRestService api) => _api = api;

  public DecisionDefinitionResource this[string decisionDefinitionId]
    => new DecisionDefinitionResourceById(_api, decisionDefinitionId);

  public DecisionDefinitionResource ByKey(string decisionDefinitionKey)
    => new DecisionDefinitionResourceByKey(_api, decisionDefinitionKey);

  public DecisionDefinitionResource ByKey(string decisionDefinitionKey, string tenantId)
    => new DecisionDefinitionResourceByKeyAndTenantId(_api, decisionDefinitionKey, tenantId);

  public QueryResource<DecisionDefinitionQuery, DecisionDefinitionInfo> Query(DecisionDefinitionQuery query = null)
    => new(query, (q, f, m) => _api.GetList(q, f, m), q => _api.GetListCount(q));
}