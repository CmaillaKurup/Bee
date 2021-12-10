using System;
using System.Threading;

namespace Bee
{
    public class CollectorBee
    {
        private Program pg = new Program();
        public void CollectNectar()
        {
            while (true)
            {
                Monitor.Enter(pg._lock);
                try
                {
                    //This one get stock at 5(the current number the queue comparing against
                    //seems like the lock doesn't exit from here
                    if (pg._nectarHolder.Count < 5)
                    {
                        pg._nectarHolder.Enqueue(pg.nectar);
                        Console.WriteLine("Collected " + pg._nectarHolder.Count + " of nectar");

                        Monitor.PulseAll(pg._lock);
                    }
                    else
                    {
                        Monitor.Wait(pg._lock);
                    }
                    
                    Thread.Sleep(pg._random.Next(100,500));
                }
                finally
                {
                    Monitor.Exit(pg._lock);
                }
            }
        }
    }
}