using Novin.FoodApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Novin.FoodApp.Core.Entities
{
    public class ApplicationUser
    {

        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string Fullname { get; set; }

        [JsonIgnore]
        public ApplicationUserType Type { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool Verifide { get; set; } = false;

        [JsonIgnore]
        public string VerificationCode { get; set; }

        public string UserType
        {
            get
            {
                switch (this.Type)
                {
                    case ApplicationUserType.SystemAdmin:
                        return "System Admin";
                        break;
                    case ApplicationUserType.RestaurantOwner:
                        return "Restaurant Owner";
                        break;
                    case ApplicationUserType.Customer:
                        return "Customer";
                        break;
                    default:

                        break;
                }
                return "unknown";
            }



        }
    }

}
