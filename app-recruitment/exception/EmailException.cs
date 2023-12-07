using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.exception
{
    internal class EmailException : Exception
    {
        public EmailException(String message): base(message) { 
            
        }
    }
}
