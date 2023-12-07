using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.validate
{
    internal class RegexProperties
    {
        public const string EMAIL = "^[a-zA-Z]\\w+@[a-zA-Z]+(\\.[a-zA-Z]+)$";
        public const string DATE = @"^\d{4}-\d{2}-\d{2}$";
    }
}
