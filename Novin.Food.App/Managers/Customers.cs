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
    public static class Customers
    {
        public static async void Show()
        {
            var customersMenu = new Menu();
            customersMenu.Items.Add("1-Add");
            customersMenu.Items.Add("2-Show");
            customersMenu.Items.Add("3-Delete");
            customersMenu.Items.Add("4-Edit");
            customersMenu.Items.Add("0-Back");
            while (true)
            {
                var selected = customersMenu.Show();
                if (selected == 0)
                {
                    break;
                }
                else if (selected == 1)
                {
                    var c = new Customer();
                    c.Read();
                    using (var db = new FoodiDB())
                    {
                        await db.Customers.AddAsync(c);
                        await db.SaveChangesAsync();
                        Console.WriteLine("done!....");
                    }
                }
                else if (selected == 2)
                {
                    using (var db = new FoodiDB())
                    {
                        Console.WriteLine(".................................");
                        (await db.Customers.ToListAsync()).ForEach(c => Console.WriteLine(c));
                        Console.WriteLine(".................................");
                    }
                }
                else if (selected == 3)
                {
                    Console.WriteLine("Id Of Customer: ");
                    var id = int.Parse(Console.ReadLine());
                    using (var db = new FoodiDB())
                    {
                        var customer =await db.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
                        if (customer != null)
                        {
                            db.Customers.Remove(customer);
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
                        var customer = await db.Customers.FirstOrDefaultAsync(m => m.Id == id);
                        if (customer != null)
                        {
                            Console.WriteLine(customer);
                            customer.Read();
                            db.Customers.Update(customer);
                            db.SaveChanges();
                            Console.WriteLine("done!.....");
                        }
                    }
                }
            }
        }
    }
}