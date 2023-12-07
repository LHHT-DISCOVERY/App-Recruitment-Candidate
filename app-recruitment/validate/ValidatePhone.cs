using app_recruitment.exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace app_recruitment.validate
{
    internal class ValidatePhone
    {
        public static String validatePhone()
        {
            Console.Write("Entern Candidate Phone : ");
            String phone = Console.ReadLine();
            phone = phone.Trim();
            String regexPhone = "^(0)+([3-9][0-9]{8})$";
            Regex regex = new Regex(regexPhone);
            if (!regex.IsMatch(phone))
            {
                throw new PhoneException(Message.PHONE_FORMAT);
            }
            else if (phone == "")
            {
                throw new PhoneException(Message.PHONE_REQUIRE);
            }

            return phone;
        }

        public static String checkPhone()
        {
            while (true)
            {
                try
                {
                    String phone = validatePhone();
                    return phone;
                }
                catch (PhoneException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("The system has encountered an unexpected problem, sincerely sorry !!!”");
                }


            }
        }
    }
}
