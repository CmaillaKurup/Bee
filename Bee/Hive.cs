using System.Collections.Generic;

namespace Bee
{
    public class Hive
    {
        private Queue<CollectorBee> _collectorBees = new Queue<CollectorBee>(750);
        private Queue<ProducerBee> _producerBees = new Queue<ProducerBee>(250);

        //this is suppose to check if any producerbee is free
        //it might be the case that my producerbee can check this it self I'll check up on that at some point
        public void ProducerBeeIsFree()
        {
            
        }
    }
}