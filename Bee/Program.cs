using System;
using System.Collections.Generic;
using System.Threading;

namespace Bee
{
    class Program
    {
        public object _lock = new object();
        public Random _random = new Random();
        public Queue<int> _nectarHolder = new Queue<int>();
        //public Queue<int> _honneyHolder = new Queue<int>();
        //public int _honney;
        public int nectar = 0;

        static void Main()
        {
            ProducerBee pb = new ProducerBee();
            CollectorBee cb = new CollectorBee();

            Thread producerThread = new Thread(pb.ConsumeNectar);
            Thread collectorThread = new Thread(cb.CollectNectar);
            
            producerThread.Start();
            collectorThread.Start();
        }
    }
}