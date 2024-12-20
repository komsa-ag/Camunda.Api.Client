﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Camunda.Api.Client.UserTask;

public class VariableResource : IVariableResource
{
  private readonly string _taskId;
  private readonly IUserTaskRestService _api;

  internal VariableResource(IUserTaskRestService api, string taskId)
  {
    _api = api;
    _taskId = taskId;
  }

  /// <summary>
  /// Retrieves all variables of a given task.
  /// </summary>
  /// <param name="deserializeValues">Determines whether serializable variable values (typically variables that store custom Java objects) should be deserialized on server side.</param>
  public Task<Dictionary<string, VariableValue>> GetAll(bool deserializeValues = true) 
    => _api.GetVariables(_taskId, deserializeValues);
  
  /// <summary>
  /// Retrieves a variable from the context of a given task.
  /// </summary>
  public Task<VariableValue> Get(string variableName, bool deserializeValue = true) 
    => _api.GetVariable(_taskId, variableName, deserializeValue);
  
  /// <summary>
  /// Retrieves a binary variable from the context of a given task. Applicable for byte array and file variables.
  /// </summary>
  public async Task<HttpContent> GetBinary(string variableName) 
    => (await _api.GetBinaryVariable(_taskId, variableName)).Content;
  
  /// <summary>
  /// Sets a variable in the context of a given task.
  /// </summary>
  public Task Set(string variableName, VariableValue variable) 
    => _api.PutVariable(_taskId, variableName, variable);
  
  /// <summary>
  /// Sets the serialized value for a binary variable or the binary value for a file variable.
  /// </summary>
  public Task SetBinary(string variableName, BinaryDataContent data, BinaryVariableType valueType) 
    => _api.SetBinaryVariable(_taskId, variableName, data, new ValueTypeContent(valueType.ToString()));

  /// <summary>
  /// Removes a variable from a task.
  /// </summary>
  public Task Delete(string variableName) => _api.DeleteVariable(_taskId, variableName);

  /// <summary>
  /// Updates or deletes the variables in the context of a task. Updates precede deletions. So, if a variable is updated AND deleted, the deletion overrides the update.
  /// </summary>
  public Task Modify(PatchVariables patch) => _api.ModifyVariables(_taskId, patch);

  public override string ToString() => _taskId;
}