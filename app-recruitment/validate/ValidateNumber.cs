using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.validate
{
    internal class ValidateNumber
    {
        public static int validateNumber()
        {
            int choice;
            while (true)
            {
                Console.Write("Enter choice : ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Enter Choice Is Number ");
                }

            }
        }
    }
}
