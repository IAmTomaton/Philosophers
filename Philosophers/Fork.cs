using System.Threading;

namespace Philosophers
{
    class Fork
    {
        private readonly Mutex mutex = new Mutex();

        public bool TryLock()
        {
            return mutex.WaitOne(1);
        }

        public void Release()
        {
            mutex.ReleaseMutex();
        }
    }
}
