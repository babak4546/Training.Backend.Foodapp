using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novin.Food.Infrastructure.DB;

namespace Novin.Food.App.Managers
{
    public class Admins
    {
        public string Check(string username, string password)
        {
            using (var db = new FoodiDB())
            {
                var admin = db.Admins.ToList().FirstOrDefault();

                if (admin.Password == password && admin.Username == username)
                {
                    return "Ok";
                }
                else
                {
                    return "wrong";
                }
            }
        }
    }
}