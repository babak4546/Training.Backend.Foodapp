using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novin.Food.Data.Models
{
    public class Restaurant : Entity
    {
        public string RestaurantName { get; set; }
        public string RestaurantOwner { get; set; }
        public string Type { get; set; }
        public string RestaurantAddress { get; set; }
        public string RestaurantPhoneNumber { get; set; }
        public string OwnerPhonenumber { get; set; }
        public void Read()
        {
            Console.Write("RestaurantName: ");
            RestaurantName = Console.ReadLine();
            Console.Write("RestaurantOwner: ");
            RestaurantOwner = Console.ReadLine();
            Console.Write("Type: ");
            Type = Console.ReadLine();
            Console.Write("RestaurantAddress: ");
            RestaurantAddress = Console.ReadLine();
            Console.Write("RestaurantPhoneNumber: ");
            RestaurantPhoneNumber = Console.ReadLine();
            Console.Write("OwnerPhonenumber: ");
            OwnerPhonenumber = Console.ReadLine();
        }
        public override string ToString()
        {
            return $"{Id} {RestaurantName} {RestaurantOwner} {Type} {RestaurantAddress} {RestaurantPhoneNumber} {OwnerPhonenumber}";
        }


    }
}
    
