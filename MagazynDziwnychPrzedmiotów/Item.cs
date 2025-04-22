using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace MagazynDziwnychPrzedmiotów
{
    internal class Item
    {
        private string Name;
        private float Weight;
        private int StrangenessLevel;
        private Boolean IsFragile;

        public Item(string name, float weight, int strangenessLevel, bool isFragile)
        {
            Name = name;
            Weight = weight;
            StrangenessLevel = strangenessLevel;
            IsFragile = isFragile;
        }

        public string Description()
        {
            var descriptionObject = new
            {
                Name,
                Weight,
                StrangenessLevel,
                IsFragile,
            };
            string descriptionJSON = JsonSerializer.Serialize(descriptionObject);
            return descriptionJSON;
        }
    }
}
