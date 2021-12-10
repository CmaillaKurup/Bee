using System;
using System.Collections.Generic;
using System.Threading;

namespace Bee
{
    public class ProducerBee
    {
        private Program pg = new Program();

        //Consuming the nectar from the collectorBee and removing it from the nectar Queue
        public void ConsumeNectar()
        {
            while (true)
            {
                Monitor.Enter(pg._lock);
                {
                    try
                    {
                        if (pg._nectarHolder.Count > 1)
                        {
                            pg._nectarHolder.Dequeue();
                            Console.WriteLine(pg._nectarHolder.Count + " left to produce");
                            Monitor.PulseAll(pg._lock);
                        }
                        else
                        {
                            Monitor.Wait(pg._lock);
                        }
                    }
                    finally
                    {
                        Monitor.Exit(pg._lock);
                    }
                    Thread.Sleep(pg._random.Next(100,700));
                }
            }
        }
        
        //Tqaken the produced nectar and creating one jar of honey with every 2000 piece of nectar
        public int ProduceHoney()
        {
            int honey = 0;
            Queue<int> glassesOfHoney = new Queue<int>();
            
            //for testing purpose this is for the time being set low
            //but when the code is done and tested it will be set to 2000
            if (pg._nectarHolder.Count == 2000)
            {
                glassesOfHoney.Enqueue(honey);
                Console.WriteLine("Collected " + glassesOfHoney.Count + " glasses of honey");
            }
            return glassesOfHoney.Count;
        }
    }
}