﻿using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Camunda.Api.Client.History
{
    internal interface IHistoricDecisionInstanceRestService
    {
        [Get("/history/decision-instance/{id}")]
        Task<HistoricDecisionInstance> Get(string id, CancellationToken cancellationToken = default);

        [Get("/history/decision-instance")]
        Task<List<HistoricDecisionInstance>> GetList(QueryDictionary query, int? firstResult, int? maxResults, CancellationToken cancellationToken = default);

        [Get("/history/decision-instance/count")]
        Task<CountResult> GetListCount(QueryDictionary query, CancellationToken cancellationToken = default);
    }
}