using System.Collections.Generic;

namespace Camunda.Api.Client.Job;

public class JobRetries
{
  /// <summary>
  /// A list of job ids to set retries for.
  /// </summary>
  public List<string> JobIds = [];
  /// <summary>
  /// A job query like the request body for <see cref="JobService.Query(JobQuery)"/>.
  /// </summary>
  public JobQuery JobQuery = new();
  /// <summary>
  /// An integer representing the number of retries.
  /// </summary>
  public int Retries;
}
