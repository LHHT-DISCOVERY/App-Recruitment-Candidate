using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace app_recruitment.model
{
    internal  class Candidate
    {
        private int candidateID;
        private String candidateFullName;
        private DateTime birthday;
        private String phone;
        private String email;
        private int candidateType;
        private List<Certificate> certificate;

        public Candidate()
        {
        }

        public Candidate(int candidateID, string candidateFullName, DateTime birthday, string phone, string email, int candidateType)
        {
            this.candidateID = candidateID;
            this.candidateFullName = candidateFullName;
            this.birthday = birthday;
            this.phone = phone;
            this.email = email;
            this.CandidateType = candidateType;
        }

        protected Candidate(int candidateID, string candidateFullName, DateTime birthday, string phone, string email, int candidateType, List<Certificate> certificate)
        {
            this.candidateID = candidateID;
            this.candidateFullName = candidateFullName;
            this.birthday = birthday;
            this.phone = phone;
            this.email = email;
            this.CandidateType = candidateType;
            this.Certificate = certificate;
        }



        public int CandidateID { get => candidateID; set => candidateID = value; }
        public string CandidateFullName { get => candidateFullName; set => candidateFullName = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }

        internal List<Certificate> Certificate { get => certificate; set => certificate = value; }
        public int CandidateType { get => candidateType; set => candidateType = value; }

        private String CertificateListToString(List<Certificate> Certificate)
        {
            String result = "";

            foreach (Certificate cert in certificate)
            {
                result += cert.ToString();
            }
            if (Certificate.Count == 0)
            {
                result = "Cadidate Hasn't Certificate";
            }
            return result;
        }

        public override string ToString()
        {
            return "Candidate:   " + CandidateID + " -|- FullName : " + CandidateFullName + "-|- BirthDay : " + Birthday.ToString("dd/MM/yyyy") + "-|- Phone : " + Phone + "-|- Email : " + Email + "-|- Certificate : " + CertificateListToString(Certificate);
        }
    }
}