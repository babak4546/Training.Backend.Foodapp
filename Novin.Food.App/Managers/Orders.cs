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
    public class Orders
    {
        public static async void Show()
        {
            var ordersMenu = new Menu();
            ordersMenu.Items.Add("1-Add");
            ordersMenu.Items.Add("2-Show");
            ordersMenu.Items.Add("3-Delete");
            ordersMenu.Items.Add("4-DeliveryTime");
            ordersMenu.Items.Add("0-Back");
            while (true)
            {
                var selected = ordersMenu.Show();
                if (selected == 0)
                {
                    break;
                }
                else if (selected == 1)
                {
                    var c = new Order();
                    c.Read();
                    using (var db = new FoodiDB())
                    {
                        c.OrderTime = DateTime.Now;
                        await db.Orders.AddAsync(c);
                        await db.SaveChangesAsync();
                        Console.WriteLine("done!....");
                    }
                }
                else if (selected == 2)
                {
                    using (var db = new FoodiDB())
                    {
                        Console.WriteLine(".................................");
                        (
                         await db
                        .Orders
                        .Include(c => c.Food)
                        .Include(c => c.Drink)
                        .Include(c => c.Customer)
                        .Include(c => c.Restaurant)
                        .Where(m => m.DeliveryTime == null)
                        .ToListAsync())
                        .ForEach(c => Console.WriteLine(c));
                        Console.WriteLine(".................................");
                    }
                }
                else if (selected == 3)
                {
                    Console.WriteLine("Id Of Order: ");
                    var id = int.Parse(Console.ReadLine());
                    using (var db = new FoodiDB())
                    {
                        var order = await db.Orders.Where(c => c.Id == id).FirstOrDefaultAsync();
                        if (order != null)
                        {
                            db.Orders.Remove(order);
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
                    Console.Write(" Id for return: ");
                    var id = int.Parse(Console.ReadLine());
                    using (var db = new FoodiDB())
                    {
                        var order = await db.Orders.FirstOrDefaultAsync(m => m.Id == id);
                        if (order != null)
                        {
                            Console.WriteLine(order);
                            order.DeliveryTime = DateTime.Now;
                            db.Orders.Update(order);
                            await db.SaveChangesAsync();
                            Console.WriteLine("done!.....");
                        }
                        else
                        {
                            Console.WriteLine("not found");
                        }
                    }
                }
            }
        }
    }
}