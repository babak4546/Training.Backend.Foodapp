using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novin.Food.Data.Models
{
    public class Drink : Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public void Read()
        {
            Console.Write("Name: ");
            Name = Console.ReadLine();
            Console.Write("Type: ");
            Type = Console.ReadLine();
            Console.Write("Price: ");
            Price = int.Parse(Console.ReadLine());
        }
        public override string ToString()
        {
            return $"{Id} {Name} {Type} {Count} ${Price}";
        }

    }
}