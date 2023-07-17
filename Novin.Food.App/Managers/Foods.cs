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
    public class Foods
    {
        public static async void Show()
        {
            var foodsMenu = new Menu();
            foodsMenu.Items.Add("1-Add");
            foodsMenu.Items.Add("2-Show");
            foodsMenu.Items.Add("3-Delete");
            foodsMenu.Items.Add("4-Edit");
            foodsMenu.Items.Add("0-Back");
            while (true)
            {
                var selected = foodsMenu.Show();
                if (selected == 0)
                {
                    break;
                }
                else if (selected == 1)
                {
                    var f = new TheFood();
                    f.Read();
                    using (var db = new FoodiDB())
                    {
                        await db.FoodNames.AddAsync(f);
                        await db.SaveChangesAsync();
                        Console.WriteLine("done!....");
                    }
                }
                else if (selected == 2)
                {
                    using (var db = new FoodiDB())
                    {
                        Console.WriteLine(".................................");
                        (await db.FoodNames.ToListAsync()).ForEach(d => Console.WriteLine(d));
                        Console.WriteLine(".................................");

                    }
                }
                else if (selected == 3)
                {
                    Console.WriteLine("Id Of Food: ");
                    var id = int.Parse(Console.ReadLine());
                    using (var db = new FoodiDB())
                    {
                        var food =await db.FoodNames.Where(d => d.Id == id).FirstOrDefaultAsync();
                        if (food != null)
                        {
                            db.FoodNames.Remove(food);
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
                        var food =await db.FoodNames.FirstOrDefaultAsync(d => d.Id == id);
                        if (food != null)
                        {
                            Console.WriteLine(food);
                            food.Read();
                            db.FoodNames.Update(food);
                            await db.SaveChangesAsync();
                            Console.WriteLine("done!.....");
                        }
                    }
                }
            }
        }
    }
}