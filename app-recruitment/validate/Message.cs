using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.validate
{
    internal class Message
    {
        public const string PHONE_FORMAT = "PHONE IS CORRECT FORMAT";
        public const string DATE_ERROR = "DATE IS INCORRECT YEAR";
        public const string PHONE_REQUIRE = "PLEASE ! ENTER PHONE BEFORE STEP NEXT";
        public const string EMAIL_FORMAT = "EMAIL IS CORRECT FORMAT";
        public const string EMAIL_REQUIRE = "PLEASE ! ENTER EMAIL BEFORE STEP NEXT";
        public const string BIRTHDAY_ERROR_YEAR = " YEAR BIRTHDAY BETWEEN 1900 AND CURRENT YEAR";
        public const string BIRTHDAY_ERROR_MONTH_OR_DAY = " YEAR OR MONTH OR DAY INCORRECT";
    }
}
