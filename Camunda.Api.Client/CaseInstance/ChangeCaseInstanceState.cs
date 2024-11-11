#region Usings

using Newtonsoft.Json;
using System.Collections.Generic;

#endregion

namespace Camunda.Api.Client.CaseInstance;

public class ChangeCaseInstanceState
{
  [JsonProperty("variables")]
  public Dictionary<string, CaseInstanceVariableValue> Variables;

  [JsonProperty("deletions")]
  public List<CaseInstanceDeleteVariable> Deletions;
}
