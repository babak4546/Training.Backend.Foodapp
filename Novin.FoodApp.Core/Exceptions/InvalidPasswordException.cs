using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.FoodApp.Core.Exceptions
{
    public class InvalidPasswordException:Exception
    {
        public InvalidPasswordException()
            :base("password is not complex enough!")
        {
            
        }
    }
}
