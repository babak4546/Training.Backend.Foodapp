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
    public static class Restaurants
    {
        public static async void Show()
        {
            var restaurantsMenu = new Menu();
            restaurantsMenu.Items.Add("1-Add");
            restaurantsMenu.Items.Add("2-Show");
            restaurantsMenu.Items.Add("3-Delete");
            restaurantsMenu.Items.Add("4-Edit");
            restaurantsMenu.Items.Add("0-Back");
            while (true)
            {
                var selected = restaurantsMenu.Show();
                if (selected == 0)
                {
                    break;
                }
                else if (selected == 1)
                {
                    var d = new Restaurant();
                    d.Read();
                    using (var db = new FoodiDB())
                    {
                        await db.Restaurants.AddAsync(d);
                        await db.SaveChangesAsync();
                        Console.WriteLine("done!....");
                    }
                }
                else if (selected == 2)
                {
                    using (var db = new FoodiDB())
                    {
                        Console.WriteLine(".................................");
                        (await db.Restaurants.ToListAsync()).ForEach(c => Console.WriteLine(c));
                        Console.WriteLine(".................................");
                    }
                }
                else if (selected == 3)
                {
                    Console.WriteLine("Id Of Restaurant: ");
                    var id = int.Parse(Console.ReadLine());
                    using (var db = new FoodiDB())
                    {
                        var restaurant = db.Restaurants.Where(c => c.Id == id).FirstOrDefault();
                        if (restaurant != null)
                        {
                            db.Restaurants.Remove(restaurant);
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
                        var restaurant = await db.Restaurants.FirstOrDefaultAsync(m => m.Id == id);
                        if (restaurant != null)
                        {
                            Console.WriteLine(restaurant);
                            restaurant.Read();
                            db.Restaurants.Update(restaurant);
                            await db.SaveChangesAsync();
                            Console.WriteLine("done!.....");
                        }
                    }
                }
            }
        }
    }
}