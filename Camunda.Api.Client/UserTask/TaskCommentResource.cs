using System.Collections.Generic;
using System.Threading.Tasks;

namespace Camunda.Api.Client.UserTask;

public class TaskCommentResource
{
  private readonly string _taskId;
  private readonly IUserTaskRestService _api;

  internal TaskCommentResource(IUserTaskRestService api, string taskId)
  {
    _api = api;
    _taskId = taskId;
  }

  /// <summary>
  /// Gets the comments for a task.
  /// </summary>
  public Task<List<CommentInfo>> GetAll() => _api.GetComments(_taskId);
  /// <summary>
  /// Retrieves a single task comment by task id and comment id.
  /// </summary>
  public Task<CommentInfo> Get(string commentId) => _api.GetComment(_taskId, commentId);
  /// <summary>
  /// Create a comment for a task.
  /// </summary>
  /// <param name="message">The message of the task comment to create.</param>
  public Task<CommentInfo> Create(string message) => _api.CreateComment(_taskId, new() { Message = message });

  public override string ToString() => _taskId;
}