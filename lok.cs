using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BlankApp3
{
    public abstract class ProCon<T> where T : class
    {

        public Queue<T> _goodQueue;

        private int cap;

        protected int _queueCount { get { return _goodQueue.Count; } }
        protected T _queuePeek { get { return _goodQueue.Count > 0 ? _goodQueue.Peek() : null; } }

        private Semaphore _queueFull;
        private Semaphore _queueEmpty;
        private ManualResetEvent _releaseSignal;

        protected bool _hasDisposed;

        private Thread _thread;

        public ProCon(int capacity)
        {
            _releaseSignal = new ManualResetEvent(false);
            _goodQueue = new Queue<T>(capacity);
            _queueFull = new Semaphore(0, capacity);
            _queueEmpty = new Semaphore(capacity, capacity);

            _hasDisposed = false;
            cap = capacity;

            _thread = new Thread(new ThreadStart(Deliver));
            _thread.IsBackground = true;
            _thread.Priority = ThreadPriority.Highest;
            _thread.Start();
        }

        protected virtual void Deliver()
        {
            WaitHandle[] signals = new WaitHandle[] { _queueFull, _releaseSignal };

            while (!_hasDisposed)
            {
                T good;

                WaitHandle.WaitAny(signals);
                if (_hasDisposed)
                    break;

                lock (_goodQueue)
                    good = _goodQueue.Dequeue();
                _queueEmpty.Release();

                Consume(good);
            }
        }

        public virtual void Product(T good)
        {
            _queueEmpty.WaitOne();
            lock (_goodQueue)
                _goodQueue.Enqueue(good);
            _queueFull.Release();
        }

        public abstract void Consume(T good);
    }
}
