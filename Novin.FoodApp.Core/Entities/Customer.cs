using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.FoodApp.Core.Entities
{
    public  class Customer : BaseEntity
    {
        public ApplicationUser Fullname { get; set; }
        public ApplicationUser Username { get; set;}



    }
}
