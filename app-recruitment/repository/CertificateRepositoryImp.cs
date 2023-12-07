using app_recruitment.model;
using app_recruitment.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.repository
{
    internal class CertificateRepositoryImp : ICertificateRepository
    {
        public const string ADD_CERTIFICATE = "insert into certificate (certificateID, cerName,cerRank,cerDate,candidateID) values (@certificateID , @cerName , @cerRank  ,@cerDate ,@candidateID ) ";
        public void addCertificate(int candidateID, Certificate certificate)
        {
            using (SqlConnection connection = AccessDB.GetConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(ADD_CERTIFICATE, connection))
                    {
                        command.Parameters.AddWithValue("@certificateID", certificate.CerID);
                        command.Parameters.AddWithValue("@cerName", certificate.CerName);
                        command.Parameters.AddWithValue("@cerRank", certificate.CerRank);
                        command.Parameters.AddWithValue("@cerDate", certificate.CerDate);
                        command.Parameters.AddWithValue("@candidateID", candidateID);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void enterCertificate(int candidateID, int numberOfCertificate)
        {
            int count = 0;
            while (true)
            {
                Console.WriteLine("---- Enter Certificate " + count + " ---- ");
                Console.Write("Enter Certificate ID : ");
                int cerID = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Certificate Name : ");
                String cerName = Console.ReadLine();
                Console.Write("Enter Certificate Rank : ");
                String cerRank = Console.ReadLine();
                Console.Write("Enter Certificate Date : ");
                DateTime cerDate = DateTime.Parse(Console.ReadLine());
                Certificate certificate = new Certificate(cerID, cerName, cerRank, cerDate);
                addCertificate(candidateID, certificate);
                ++count;
                if (count == numberOfCertificate)
                {
                    break;
                }
            }
        }

        public List<Certificate> getAll()
        {
            throw new NotImplementedException();
        }
    }
}
