using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Novin.Food.Data.Models;
using Novin.Food.Infrastructure.DB;
using Novin.Food.UI;

namespace Novin.Food.App.Managers
{
    public class Drinks
    {
        public static async void Show()
        {
            var drinksMenu = new Menu();
            drinksMenu.Items.Add("1-Add");
            drinksMenu.Items.Add("2-Show");
            drinksMenu.Items.Add("3-Delete");
            drinksMenu.Items.Add("4-Edit");
            drinksMenu.Items.Add("0-Back");
            while (true)
            {
                var selected = drinksMenu.Show();
                if (selected == 0)
                {
                    break;
                }
                else if (selected == 1)
                {
                    var d = new Drink();
                    d.Read();
                    using (var db = new FoodiDB())
                    {
                        await db.Drinks.AddAsync(d);
                        await db.SaveChangesAsync();
                        Console.WriteLine("done!....");

                    }
                }
                else if (selected == 2)
                {
                    using (var db = new FoodiDB())
                    {
                        Console.WriteLine(".................................");
                        (await db.Drinks.ToListAsync()).ForEach(d => Console.WriteLine(d));
                        Console.WriteLine(".................................");
                    }
                }
                else if (selected == 3)
                {
                    Console.WriteLine("Id Of Drink: ");
                    var id = int.Parse(Console.ReadLine());
                    using (var db = new FoodiDB())
                    {
                        var drink = await db.Drinks.Where(d => d.Id == id).FirstOrDefaultAsync();
                        if (drink != null)
                        {
                            db.Drinks.Remove(drink);
                            await db.SaveChangesAsync();
                            Console.WriteLine("done !.....");
                        }
                        else
                        {
                            Console.WriteLine("Not Found");
                        }
                    }
                }
                else if (selected == 4)
                {
                    Console.Write(" Id for edit: ");
                    var id = int.Parse(Console.ReadLine());
                    using (var db = new FoodiDB())
                    {
                        var drink = await db.Drinks.FirstOrDefaultAsync(d => d.Id == id);
                        if (drink != null)
                        {
                            Console.WriteLine(drink);
                            drink.Read();
                            db.Drinks.Update(drink);
                            await db.SaveChangesAsync();
                            Console.WriteLine("done!.....");
                        }
                    }
                }
            }
        }
    }
}