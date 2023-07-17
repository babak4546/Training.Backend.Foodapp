using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.FoodApp.Core.Entities
{
    public class FoodName :BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public Restaurant? Restaurant { get; set; }
        public string? RestaurantType { get; set; }



    }
}
