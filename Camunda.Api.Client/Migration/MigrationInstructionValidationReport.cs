﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Camunda.Api.Client.Migration;

public class MigrationInstructionValidationReport
{
  /// <summary>
  /// A migration instruction object.
  /// </summary>
  [JsonProperty("instruction")]
  public MigrationInstruction Instruction;

  /// <summary>
  /// A list of instruction validation report messages.
  /// </summary>
  [JsonProperty("failures")]
  public List<string> Failures;
}
