using Refit;
using System.Threading.Tasks;

namespace Camunda.Api.Client.Signal
{
    public interface ISignalRestService
    {
        [Post("/signal")]
        Task ThrowSignal([Body] Signal signal);
    }
}