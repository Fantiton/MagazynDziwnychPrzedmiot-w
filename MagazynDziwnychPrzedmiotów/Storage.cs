using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynDziwnychPrzedmiotów
{
    internal class Storage
    {
        private int Capacity;
        private int ItemCount;
        private float MaxLoadWeight;

        public Storage(int capacity, int maxLoadWeight)
        {
            Capacity = capacity;
            MaxLoadWeight = maxLoadWeight;
        }
    }
}
