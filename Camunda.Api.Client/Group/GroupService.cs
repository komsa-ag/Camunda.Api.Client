﻿using System.Threading.Tasks;

namespace Camunda.Api.Client.Group
{
    public class GroupService
	{
		private IGroupRestService _api;

		internal GroupService(IGroupRestService api)
		{
			_api = api;
		}

        public QueryResource<GroupQuery, GroupInfo> Query(GroupQuery query = null) =>
            new QueryResource<GroupQuery, GroupInfo>(
                query, 
                (q, f, m, c) => _api.GetList(q, f, m, c),
                (q, c) => _api.GetListCount(q, c));

		/// <param name="groupId">The id of the group to be retrieved.</param>
		public GroupResource this[string groupId] => new GroupResource(_api, groupId);

		/// <summary>
		/// Create a new group.
		/// </summary>
		public Task Create(GroupInfo group) => _api.Create(group);
	}
}
