using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTask.Exemple.Worker
{
    public interface IWorkerFirst
    {
        Task DoWork(CancellationToken cancelationToken);
    }
}