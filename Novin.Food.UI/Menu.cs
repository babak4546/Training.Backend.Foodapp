using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novin.Food.UI
{
    public class Menu
    {
        public List<string> Items { get; set; }
        public Menu()
        {
            Items=new List<string>();
        }
        public int Show()
        {
            Items.ForEach(m=>Console.WriteLine(m));
            Console.Write("Your Choice: ");
            var choice=int.Parse(Console.ReadLine());
            return choice;
        }
    
    
    
    
    }
}