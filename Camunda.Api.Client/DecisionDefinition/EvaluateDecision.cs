﻿using System.Collections.Generic;

namespace Camunda.Api.Client.DecisionDefinition;

public class EvaluateDecision
{
  /// <summary>
  /// Object containing the variables the decision is to be evaluated with. Each key corresponds to a variable name and each value to a variable value.
  /// </summary>
  public Dictionary<string, VariableValue> Variables = [];

  public EvaluateDecision SetVariable(string name, object value)
  {
    Variables = (Variables ?? []).Set(name, value);
    return this;
  }
}