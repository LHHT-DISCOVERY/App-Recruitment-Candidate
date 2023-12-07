using app_recruitment.model;
using app_recruitment.service;
using app_recruitment.Utils;
using app_recruitment.validate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.repository
{
    internal class CandidateRepositoryImp : ICandidateRepository
    {
        public static String SELECT_ALL_FRESHER = "select * from fresher";
        public static String SELECT_ALL_INTERN = "select * from intern";
        public static String SELECT_ALL_EXPERIENCE = "select * from experience";
        public static String ADD_CANDIDATE = "insert into candidate (candidateID, fullName , birthday , phone , email , candidateType) values (@value1, @value2, @value3 , @value4 , @value5 , @value6)";
        public static String ADD_CANDIDATE_FRESHER = "insert into fresher (graduationRank,graduationDate,education,candidateID) values(@value1, @value2, @value3 ,@value4 )";
        public static String ADD_CANDIDATE_INTERN = "insert into intern (semester,universityName,candidateID , majors) values(@value1 , @value2 , @value3,@value4 )";
        public static String ADD_CANDIDATE_EXPERIENCE = "insert into experience(expYear,proSkill,candidateID) values (@value1 , @value2 , @value3)";
        public static String FIND_CANDIDATE_BY_ID = "select * from candidate where  candidateID = @candidateID";
        public static String UPDATE_CANDIDATE = "update";
        public static String DELETE_CANDIDATE = "delete from candidate where candidateID = @candidateID ";
        public static String DELETE_FRESHER = "delete from fresher where candidateID = @candidateID";
        public static String DELETE_INTERN = "delete from intern where candidateID = @candidateID";
        public static String DELETE_CER = "delete from certificate where candidateID = @candidateID";
        public static String DELETE_EXPERIENCE = "delete from experience where candidateID = @candidateID ";


        public List<T> getAll<T>() where T : Candidate
        {
            List<T> list = new List<T>();
            using (SqlConnection connection = AccessDB.GetConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(SELECT_ALL_FRESHER, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Fresher fresher = new Fresher();
                                fresher.GraduationRank = reader.GetString(reader.GetOrdinal("graduationRank"));
                                fresher.GraduationDate = reader.GetDateTime(reader.GetOrdinal("graduationDate"));
                                fresher.Education = reader.GetString(reader.GetOrdinal("education"));
                                fresher.CandidateID = reader.GetInt32(reader.GetOrdinal("candidateID"));
                                setAtributeCandidate(fresher);
                                list.Add((T)(object)fresher);
                                //Console.WriteLine(fresher.ToString());
                            }
                        }
                    }

                    using (SqlCommand command = new SqlCommand(SELECT_ALL_INTERN, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Intern intern = new Intern();
                                intern.Semester = reader.GetInt32(reader.GetOrdinal("semester"));
                                intern.UniversityName = reader.GetString(reader.GetOrdinal("universityName"));
                                intern.CandidateID = reader.GetInt32(reader.GetOrdinal("candidateID"));
                                intern.Majors = reader.GetString(reader.GetOrdinal("majors"));
                                setAtributeCandidate(intern);
                                list.Add((T)(object)intern);
                                //Console.WriteLine(intern.ToString());
                            }
                        }
                    }

                    using (SqlCommand command = new SqlCommand(SELECT_ALL_EXPERIENCE, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Experience experience = new Experience();
                                experience.ExperienceYear = reader.GetInt32(reader.GetOrdinal("expYear"));
                                experience.ProSkill = reader.GetString(reader.GetOrdinal("proSkill"));
                                experience.CandidateID = reader.GetInt32(reader.GetOrdinal("candidateID"));
                                setAtributeCandidate(experience);
                                list.Add((T)(object)experience);
                                //Console.WriteLine(experience.ToString());
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }

            }
            return list;
        }



        private void setAtributeCandidate<T>(T t) where T : Candidate
        {
            using (SqlConnection connection = AccessDB.GetConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("Select * from candidate where candidateID = @candidateID", connection))
                    {
                        command.Parameters.AddWithValue("@candidateID", t.CandidateID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                t.CandidateID = t.CandidateID;
                                t.CandidateFullName = reader.GetString(reader.GetOrdinal("fullName"));
                                t.Birthday = reader.GetDateTime(reader.GetOrdinal("birthday"));
                                t.Phone = reader.GetString(reader.GetOrdinal("phone"));
                                t.Email = reader.GetString(reader.GetOrdinal("email"));
                                t.Certificate = getListCertificate(t.CandidateID);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { connection.Close(); }
            }

        }

        private List<Certificate> getListCertificate(int id)
        {
            List<Certificate> certificates = new List<Certificate>();
            using (SqlConnection connection = AccessDB.GetConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("Select * from certificate where candidateID = @candidateID", connection))
                    {
                        command.Parameters.AddWithValue("@candidateID", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Certificate certificate = new Certificate();
                                certificate.CerID = reader.GetInt32(reader.GetOrdinal("certificateID"));
                                certificate.CerName = reader.GetString(reader.GetOrdinal("cerName"));
                                certificate.CerRank = reader.GetString(reader.GetOrdinal("cerRank"));
                                certificate.CerDate = reader.GetDateTime(reader.GetOrdinal("cerDate"));
                                certificates.Add(certificate);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                }
                finally { connection.Close(); }
            }
            return certificates;
        }

        public void enterCandidate()
        {
            Candidate candidate = null;
            Console.Write("Entern ID Candidate : ");
            int candidateID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Entern Candidate Name : ");
            string candidateName = Console.ReadLine();
            DateTime birthday = ValidateBirthday.checkBirthday();
            string phone = ValidatePhone.checkPhone();
            string email = ValidateEmail.checkEmail();
            while (true)
            {
                Console.WriteLine("--- Entern Candidate Position ---");
                Console.WriteLine("1. Intern Position");
                Console.WriteLine("2. Fresher Position");
                Console.WriteLine("3. Experience Positon");
                Console.Write("Entern Canidate Position : ");
                int candidateType = Convert.ToInt32(Console.ReadLine());

                if (candidateType == 1)
                {
                    Console.Write("Entern Semester : ");
                    int semester = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Majors : ");
                    string majors = Console.ReadLine();
                    Console.Write("Entern UniversityName : ");
                    string universityName = Console.ReadLine();
                    candidate = new Intern(candidateID, candidateName, birthday, phone, email, candidateType, majors, semester, universityName);
                    addCandidate(candidate);
                    Console.Write("Enter Number Of Certificate : ");
                    int numberOfCertificate = Convert.ToInt32(Console.ReadLine());
                    new CertificateRepositoryImp().enterCertificate(candidate.CandidateID, numberOfCertificate);
                    break;
                }
                else if (candidateType == 2)
                {
                    Console.Write("Enter GraduationRank : ");
                    string graduationRank = Console.ReadLine();
                    Console.Write("Enter GraduationDate : ");
                    DateTime graduationDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter Education : ");
                    string education = Console.ReadLine();
                    candidate = new Fresher(candidateID, candidateName, birthday, phone, email, candidateType, graduationDate, graduationRank, education);
                    addCandidate(candidate);
                    Console.Write("Enter Number Of Certificate : ");
                    int numberOfCertificate = Convert.ToInt32(Console.ReadLine());
                    new CertificateRepositoryImp().enterCertificate(candidate.CandidateID, numberOfCertificate);
                    break;
                }
                else if (candidateType == 3)
                {
                    Console.Write("Enter ExpYear : ");
                    int expYear = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter ProSkill : ");
                    string proSkill = Console.ReadLine();
                    candidate = new Experience(candidateID, candidateName, birthday, phone, email, candidateType, expYear, proSkill);
                    addCandidate(candidate);
                    Console.Write("Enter Number Of Certificate : ");
                    int numberOfCertificate = Convert.ToInt32(Console.ReadLine());
                    new CertificateRepositoryImp().enterCertificate(candidate.CandidateID, numberOfCertificate);
                    break;
                }
                else
                {
                    Console.WriteLine("Choice Number Wanring ! Please Again");
                }
            }
            Console.WriteLine("Add Candidate Successfull");
            return;
        }

        public void addCandidate<T>(T candidate) where T : Candidate
        {
            using (SqlConnection connection = AccessDB.GetConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(ADD_CANDIDATE, connection))
                    {
                        command.Parameters.AddWithValue("@value1", candidate.CandidateID);
                        command.Parameters.AddWithValue("@value2", candidate.CandidateFullName);
                        command.Parameters.AddWithValue("@value3", candidate.Birthday.ToString("yyyy-MM-dd"));// Chuyển DateTime sang String để save DB
                        command.Parameters.AddWithValue("@value4", candidate.Phone);
                        command.Parameters.AddWithValue("@value5", candidate.Email);
                        command.Parameters.AddWithValue("@value6", candidate.CandidateType);
                        command.ExecuteNonQuery();
                    }

                    if (candidate is Intern)
                    {
                        Intern intern = (Intern)(object)candidate;
                        using (SqlCommand command = new SqlCommand(ADD_CANDIDATE_INTERN, connection))
                        {
                            command.Parameters.AddWithValue("@value1", intern.Semester);
                            command.Parameters.AddWithValue("@value2", intern.UniversityName);
                            command.Parameters.AddWithValue("@value3", intern.CandidateID);
                            command.Parameters.AddWithValue("@value4", intern.Majors);
                            command.ExecuteNonQuery();
                        }
                    }

                    if (candidate is Fresher)
                    {
                        Fresher fresher = (Fresher)(object)candidate;
                        using (SqlCommand command = new SqlCommand(ADD_CANDIDATE_FRESHER, connection))
                        {
                            command.Parameters.AddWithValue("@value1", fresher.GraduationRank);
                            command.Parameters.AddWithValue("@value2", fresher.GraduationDate.ToString("yyyy-MM-dd"));
                            command.Parameters.AddWithValue("@value3", fresher.Education);
                            command.Parameters.AddWithValue("@value4", fresher.CandidateID);
                            command.ExecuteNonQuery();
                        }
                    }

                    if (candidate is Experience)
                    {
                        Experience experience = (Experience)(object)candidate;
                        using (SqlCommand command = new SqlCommand(ADD_CANDIDATE_EXPERIENCE, connection))
                        {
                            command.Parameters.AddWithValue("@value1", experience.ExperienceYear);
                            command.Parameters.AddWithValue("@value2", experience.ProSkill);
                            command.Parameters.AddWithValue("@value3", experience.CandidateID);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally { connection.Close(); }
            }
        }

        public void deleteCanidate(int id)
        {
            Candidate candidate = findCandidateById(id);
            using (SqlConnection connection = AccessDB.GetConnection())
            {
                try
                {
                    if (candidate.CandidateType == 1)
                    {
                        using (SqlCommand command = new SqlCommand(DELETE_INTERN, connection))
                        {
                            command.Parameters.AddWithValue("@candidateID", candidate.CandidateID);
                            command.ExecuteNonQuery();
                        }
                    }
                    else if (candidate.CandidateType == 2)
                    {
                        using (SqlCommand command = new SqlCommand(DELETE_FRESHER, connection))
                        {
                            command.Parameters.AddWithValue("@candidateID", candidate.CandidateID);
                            command.ExecuteNonQuery();
                        }

                    }
                    else
                    {
                        using (SqlCommand command = new SqlCommand(DELETE_EXPERIENCE, connection))
                        {
                            command.Parameters.AddWithValue("@candidateID", candidate.CandidateID);
                            command.ExecuteNonQuery();
                        }
                    }

                    using (SqlCommand command = new SqlCommand(DELETE_CER, connection))
                    {
                        command.Parameters.AddWithValue("@candidateID", candidate.CandidateID);
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(DELETE_CANDIDATE, connection))
                    {
                        command.Parameters.AddWithValue("@candidateID", candidate.CandidateID);
                        command.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void viewFullNameCandidate()
        {
            List<Candidate> candidates = getAll<Candidate>();
            StringBuilder sb = new StringBuilder();
            foreach (Candidate candidate in candidates)
            {
                sb.Append(candidate.CandidateFullName + " - ");
            }
            sb.Remove(sb.Length - 3, 3);
            Console.WriteLine(sb.ToString());
        }

        public void updateCandidate(int id)
        {
            using (SqlConnection connection = AccessDB.GetConnection())
            {
                try
                {
                    using (var dataAdapter = new SqlDataAdapter("Select * from candidate", connection))
                    {
                        var commandBuilder = new SqlCommandBuilder(dataAdapter);

                        // Tạo bảng 
                        var datatable = new DataTable();

                        //  Đổ dữ liệu từ cơ sở dữ liệu vào DataTable
                        dataAdapter.Fill(datatable);

                        // Tìm dòng có candidateID cần cập nhật
                        DataRow rowToUpdate = datatable.Rows.Cast<DataRow>().FirstOrDefault(row => (int)row["candidateID"] == id);
                        if (rowToUpdate != null)
                        {
                            while (true)
                            {
                                Console.WriteLine("--- Entern Candidate Position ---");
                                Console.WriteLine("1. Enter new name candidate");
                                Console.WriteLine("2. Enter new Birthday candidate ");
                                Console.WriteLine("3. Enter new phone candidate");
                                Console.WriteLine("4. Enter new Email candidate");
                                Console.WriteLine("0. Exist");
                                Console.Write("Enter Selection You Want to Update : ");
                                int chose = Convert.ToInt32(Console.ReadLine());
                                switch (chose)
                                {
                                    case 1:
                                        Console.WriteLine("--- Enter new name candidate ---  ");
                                        Console.Write("Enter New Name candidate: ");
                                        String newName = Console.ReadLine();
                                        rowToUpdate["fullName"] = newName;
                                        dataAdapter.Update(datatable);
                                        break;
                                    case 2:
                                        Console.Write("--- Enter new Birthday candidate --- ");
                                        DateTime birthday = ValidateBirthday.checkBirthday();
                                        rowToUpdate["birthday"] = birthday.ToString("yyyy-MM-dd");
                                        dataAdapter.Update(datatable);
                                        break;
                                    case 3:
                                        Console.Write("--- Enter new phone candidate --- ");
                                        String phone = ValidatePhone.checkPhone();
                                        rowToUpdate["phone"] = phone;
                                        dataAdapter.Update(datatable);
                                        break;
                                    case 4:
                                        Console.Write("--- Enter new Email candidate ---  ");
                                        String email = ValidateEmail.checkEmail();
                                        rowToUpdate["email"] = email;
                                        dataAdapter.Update(datatable);
                                        break;
                                    case 0:
                                        return;
                                    default:
                                        Console.WriteLine("Please! Enter chose 1 -> 6");
                                        break;
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("CANDIDATE ID NOT EXIST IN DATABASE");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public Candidate findCandidateById(int id)
        {
            Candidate candidate;
            using (SqlConnection connection = AccessDB.GetConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(FIND_CANDIDATE_BY_ID, connection))
                    {
                        command.Parameters.AddWithValue("@candidateID", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int candidateID = id;
                                String candidateFullName = reader.GetString(reader.GetOrdinal("fullName"));
                                DateTime birthday = reader.GetDateTime(reader.GetOrdinal("birthday"));
                                String phone = reader.GetString(reader.GetOrdinal("phone"));
                                String email = reader.GetString(reader.GetOrdinal("email"));
                                int candidateType = reader.GetInt32(reader.GetOrdinal("candidateType"));
                                return new Candidate(candidateID, candidateFullName, birthday, phone, email, candidateType);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return null;
        }
    }
}
