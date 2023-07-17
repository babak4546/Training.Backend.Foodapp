using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novin.Food.Data.Models
{
    public class TheFood : Entity
    {
        public string FoodName { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string RestaurantName { get; set; }
        public void Read()
        {
            Console.Write("FoodName: ");
            FoodName = Console.ReadLine();
            Console.Write("Type: ");
            Type = Console.ReadLine();
            Console.Write("Price: ");
            Price = double.Parse(Console.ReadLine());
            Console.Write("Restaurant Name: ");
            RestaurantName = Console.ReadLine();
        }
        public override string ToString()
        {
            return $"{Id} {FoodName}  {Type} {Price} {Count} {RestaurantName}";
        }

    }
}