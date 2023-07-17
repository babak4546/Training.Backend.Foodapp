using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novin.Food.Data.Models
{
    public class Customer : Entity
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int? Balance { get; set; }
        public void Read()
        {
            Console.Write("Fullname: ");
            Fullname=Console.ReadLine();
            Console.Write("Address: ");
            Address=Console.ReadLine();
            Console.Write("PhoneNumber: ");
            PhoneNumber=Console.ReadLine();
            Console.Write("Balance: ");
            Balance=int.Parse(Console.ReadLine());      
        }
        public override string ToString()
        {
            return $"{Id} {Fullname} {Address} {PhoneNumber} ${Balance}";
        }
    }
}