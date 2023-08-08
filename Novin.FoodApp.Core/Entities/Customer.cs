using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.FoodApp.Core.Entities
{
    public  class Customer : BaseEntity
    {
        public ApplicationUser? Client { get; set; }
        public string? ClientUsername { get; set; }
        public string? ClientPassword { get; set; }
        public string? ClientFullname { get; set; }
        public string? ClientEmail { get; set; }
        public string? ClientPhoneNumber { get; set; }
        public string? Address { get; set;}




    }
}
