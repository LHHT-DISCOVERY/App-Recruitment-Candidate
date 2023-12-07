using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.exception
{
    internal class PhoneException : Exception
    {
        public PhoneException(String message): base(message) { }
    }
}
