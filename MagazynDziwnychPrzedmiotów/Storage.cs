using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynDziwnychPrzedmiotów
{
    internal class Storage
    {
        public string Name;
        private int Capacity;
        private int ItemCount;
        private float MaxContentWeight;
        private List<Item> Content = new List<Item>();

        public Storage(int capacity, float maxContentWeight)
        {
            Capacity = capacity;
            MaxContentWeight = maxContentWeight;
        }

        public Storage(string name, int capacity, float maxContentWeight)
        {
            Name = name;
            Capacity = capacity;
            MaxContentWeight = maxContentWeight;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetItemCount()
        {
            return ItemCount;
        }

        public float GetMaxContentWeight()
        {
            return MaxContentWeight;
        }

        public int GetCapacity()
        {
            return Capacity;
        }

        public void Add(Item item)
        {
            Content.Add(item);
        }

        public void ListContent()
        {
            foreach (var item in Content)
            {
                Console.WriteLine(item.Description());
            }

            if (Content.Count == 0)
            {
                Console.WriteLine("Magazyn jest pusty");
            }
        }
    }
}
