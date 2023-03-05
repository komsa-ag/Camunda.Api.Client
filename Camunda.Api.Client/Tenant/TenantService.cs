﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camunda.Api.Client.Tenant
{
    public class TenantService
    {
        private ITenantRestService _api;

        internal TenantService(ITenantRestService api) { _api = api; }

        public QueryResource<TenantQuery, TenantInfo> Query(TenantQuery query = null) =>
            new QueryResource<TenantQuery, TenantInfo>(
                query, 
                (q, f, m, c) => _api.GetList(q, f, m, c),
                (q, c) => _api.GetListCount(q, c));

        public Task Create(TenantInfo tenant) =>
            _api.Create(tenant);
    }
}
