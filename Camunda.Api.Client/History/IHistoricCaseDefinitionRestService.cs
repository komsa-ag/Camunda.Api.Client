using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Camunda.Api.Client.History
{
    public interface IHistoricCaseDefinitionRestService
    {
        [Get("/history/case-definition/{id}/statistics")]
        Task<List<HistoricCaseDefinitionStatisticsResult>> GetActivityStatistics(string id);
    }
}