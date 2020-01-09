using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab5
{
    class MyThreadPool
    {
        private Queue<IAction> tasks;
        private object locker;
        private List<Thread> threads;

        public int CountOfThreads { get; private set; }

        public MyThreadPool(int countOfThreads)
        {
            if (countOfThreads > 0)
            {
                CountOfThreads = countOfThreads;
            }
            else
            {
                throw new ArgumentException("Wrong threads quantity: ");
            }

            locker = new object();
            tasks = new Queue<IAction>();
            threads = new List<Thread>();

            for (int i = 0; i <= this.CountOfThreads; i++)
            {
                Thread thread = new Thread(new ThreadStart(ProcessThread));
                thread.IsBackground = true;
                threads.Add(thread);
                thread.Start();
            }
        }


        private void ProcessThread()
        {
            IAction task = null;

            while (true)
            {
                if (tasks.Count != 0)
                {
                    lock (locker)
                    {
                        if (tasks.Count != 0)
                        {
                            task = tasks.Dequeue();
                        }
                    }

                    if (task != null)
                    {
                        task.Action();
                        task = null;
                    }
                }

            }
        }

        public void Queue(IAction task)
        {
            lock (locker)
            {
                tasks.Enqueue(task);
            }
        }
    }
}
