﻿using Camunda.Api.Client.Batch;
using Refit;
using System.Threading.Tasks;

namespace Camunda.Api.Client.Migration;

internal interface IMigrationRestService
{
  [Post("/migration/generate")]
  Task<MigrationPlan> Generate([Body] MigrationPlanGeneration request);

  [Post("/migration/validate")]
  Task<MigrationPlanReport> Validate([Body] MigrationPlan plan);

  [Post("/migration/execute")]
  Task Execute([Body] MigrationExecution request);

  [Post("/migration/executeAsync")]
  Task<BatchInfo> ExecuteAsync([Body] MigrationExecution request);
}
