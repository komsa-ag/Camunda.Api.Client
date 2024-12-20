﻿using System.Threading.Tasks;

namespace Camunda.Api.Client.Group;

public class GroupService
{
  private readonly IGroupRestService _api;

  internal GroupService(IGroupRestService api) => _api = api;

  public QueryResource<GroupQuery, GroupInfo> Query(GroupQuery query = null)
    => new(query, (q, f, m) => _api.GetList(q, f, m), q => _api.GetListCount(q));

  /// <param name="groupId">The id of the group to be retrieved.</param>
  public GroupResource this[string groupId] => new(_api, groupId);

  /// <summary>
  /// Create a new group.
  /// </summary>
  public Task Create(GroupInfo group) => _api.Create(group);
}