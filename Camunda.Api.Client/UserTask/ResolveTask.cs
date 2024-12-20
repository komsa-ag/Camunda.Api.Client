﻿using System.Collections.Generic;

namespace Camunda.Api.Client.UserTask;

public class ResolveTask
{
  /// <summary>
  /// Object containing variable key-value pairs.
  /// </summary>
  public Dictionary<string, VariableValue> Variables = [];

  public ResolveTask SetVariable(string name, object value)
  {
    Variables = (Variables ?? []).Set(name, value);
    return this;
  }
}