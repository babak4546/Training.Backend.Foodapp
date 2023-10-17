using Novin.FoodApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.FoodApp.Core.Exceptions
{
    public class DuplicateUsernameException : Exception,IDataException
    {
        public DuplicateUsernameException()
            :base("Duplicate Username(phonenumber) ")
        {
            
        }
    }
}
