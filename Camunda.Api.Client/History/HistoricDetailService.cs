namespace Camunda.Api.Client.History
{
    public class HistoricDetailService
    {
        private IHistoricDetailRestService _api;

        internal HistoricDetailService(IHistoricDetailRestService api)
        {
            _api = api;
        }

        public QueryResource<HistoricDetailQuery, HistoricDetail> Query(HistoricDetailQuery query = null) =>
            new QueryResource<HistoricDetailQuery, HistoricDetail>(
                query, 
                (q, f, m, c) => _api.GetList(q, f, m, c),
                (q, c) => _api.GetListCount(q, c));

        /// <param name="historicJobLogId">The id of the detail entry.</param>
        public HistoricDetailResource this[string historicJobLogId] => new HistoricDetailResource(_api, historicJobLogId);
    }
}
