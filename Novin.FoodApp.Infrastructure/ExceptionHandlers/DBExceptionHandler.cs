using Novin.FoodApp.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.FoodApp.Infrastructure.ExceptionHandlers
{
    public static class DBExceptionHandler
    {
        public static void HandleIt(Exception ex)
        {
            if (ex.InnerException?.Message.Contains("Violation of PRIMARY KEY constraint 'PK_ApplicationUsers'") == true)
            {
                throw new DuplicateUsernameException();
            }
            else
            {
                throw new UnknownException();
            }
        }

    }
}
