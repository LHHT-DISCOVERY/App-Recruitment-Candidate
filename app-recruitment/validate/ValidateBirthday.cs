using app_recruitment.exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.validate
{
    internal class ValidateBirthday
    {
        public static DateTime validateBirthday()
        {
            DateTime birthday;
            DateTime currentDate = DateTime.Now;

            Console.Write("Enter Candidate Birthday : ");
            birthday = DateTime.Parse(Console.ReadLine());
            if (birthday.Year <= 1900 || birthday.Year >= currentDate.Year)
            {
                throw new BirthdayException(Message.BIRTHDAY_ERROR_YEAR);
            }
            else
            {
                // Nếu trả về được kiểu DateTime ko lỗi thì dùng toString("yyyy-MM-dd") chuyển sang String  để lưu xg DB 
                // kiểu DateTime có dạng (yyyy-MM-dd or dd/MM/yyyy or yyyy/MM/dd ,...)
                return birthday;
            }

        }

        public static DateTime checkBirthday()
        {
            while (true)
            {
                try
                {
                    DateTime birthday = validateBirthday();
                    return birthday;
                }
                catch (BirthdayException e)
                {
                    Console.WriteLine(e.Message);
                }
                // khi khai báo kiểu DateTime thì mặc định dùng  FormatException để kiểm tra
                // nó sẽ tự động check kiểu ngày tháng nếu phát hiện ngày, tháng, năm ko hợp lệ
                catch (FormatException ex)
                {
                    Console.WriteLine(Message.BIRTHDAY_ERROR_MONTH_OR_DAY);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The system has encountered an unexpected problem, sincerely sorry !!!”");
                }
            }
        }

    }
}
