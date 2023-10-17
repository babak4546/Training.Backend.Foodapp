using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.FoodApp.Core.Exceptions
{
    public class UnknownException : Exception
    {
        public UnknownException()
            : base("unknown exception")
        {
            
        }
    }
}
