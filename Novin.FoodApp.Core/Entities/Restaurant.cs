using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.FoodApp.Core.Entities
{
    public class Restaurant : BaseEntity
    {
        public string Title { get; set; }
        public  ApplicationUser Owner { get; set; }
        public string OwnerUsername { get; set; }
        public bool IsApproved { get; set; }
        public string Type { get; set; }
        public ApplicationUser? Approver { get; set; }
        public string? ApproverUsername { get; set; }
        public DateTime? ApprovedTime { get; set; }
        public bool IsActive { get; set; }
    }   
}
