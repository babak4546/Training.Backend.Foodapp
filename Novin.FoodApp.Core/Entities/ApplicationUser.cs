using Novin.FoodApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.FoodApp.Core.Entities
{
    public class ApplicationUser  
    {
  
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public ApplicationUserType Type { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }


    }
}
