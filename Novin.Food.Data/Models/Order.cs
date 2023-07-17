using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novin.Food.Data.Models
{
    public class Order : Entity
    {
        public DateTime? OrderTime { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public TheFood Food { get; set; }
        public int FoodId { get; set; }
        public Drink Drink { get; set; }
        public int DrinkId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }
        public void Read()
        {
            Console.Write("FoodId: ");
            FoodId = int.Parse(Console.ReadLine());
            Console.Write("DrinkId: ");
            DrinkId = int.Parse(Console.ReadLine());
            Console.Write("CustomerId: ");
            CustomerId =int.Parse(Console.ReadLine());
            Console.Write("RestaurantId: ");
            RestaurantId =int.Parse(Console.ReadLine());
        }
        public override string ToString()
        {
            return $" Id {Id} {OrderTime} {Customer} {Restaurant}  {Food} {Drink} DeliveryTime {DeliveryTime}";
        }
    }
}
