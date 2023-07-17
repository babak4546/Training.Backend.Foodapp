using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novin.Food.Data.Models
{
    public class Admin : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public void Read()
        {
            Console.Write("Username: ");
            Username = Console.ReadLine();
            Console.Write("Password: ");
            Password = Console.ReadLine();
        }
        
    }
}