using app_recruitment.exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace app_recruitment.validate
{
    internal class ValidateEmail
    {
        public static string validateEmail()
        {
            Console.Write("Enter Candidate Email : ");
            string email = Console.ReadLine();
            Regex regex = new Regex(RegexProperties.EMAIL);
            if (email == "")
            {
                throw new EmailException(Message.EMAIL_REQUIRE);
            }
            else if (regex.IsMatch(email))
            {
                return email.Trim();
            }
            else
            {
                throw new EmailException(Message.EMAIL_FORMAT);
            }
        }


        public static string checkEmail()
        {
            while (true)
            {
                try
                {
                    string email = validateEmail();
                    return email;
                }
                catch (EmailException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The system has encountered an unexpected problem, sincerely sorry !!!”");
                }
            }
        }
    }
}
