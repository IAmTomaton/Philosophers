using System.Threading;

namespace Philosophers
{
    class Table
    {
        private readonly Mutex mutex = new Mutex();

        public void Lock()
        {
            mutex.WaitOne();
        }

        public void Release()
        {
            mutex.ReleaseMutex();
        }
    }
}
