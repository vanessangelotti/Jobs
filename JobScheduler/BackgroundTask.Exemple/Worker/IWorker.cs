using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTask.Exemple.Worker
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancelationToken);
    }
}