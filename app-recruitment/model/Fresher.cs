using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.model
{
    internal class Fresher : Candidate
    {
        private DateTime graduationDate;
        private String graduationRank;
        private String education;
        public Fresher()
        {

        }

        public Fresher(int candidateID, string candidateFullName, DateTime birthday, string phone, string email, int candidateType, DateTime graduationDate, string graduationRank, string education) : base(candidateID, candidateFullName, birthday, phone, email, candidateType)
        {
            this.graduationDate = graduationDate;
            this.graduationRank = graduationRank;
            this.education = education;
        }

        public Fresher(int candidateID, string candidateFullName, DateTime birthday, string phone, string email, int candidateType , List<Certificate> certificate, DateTime graduationDate, string graduationRank, string education) : base( candidateID , candidateFullName , birthday , phone , email ,candidateType , certificate)
        {
            this.graduationDate = graduationDate;
            this.graduationRank = graduationRank;
            this.education = education;
        }

        public DateTime GraduationDate { get => graduationDate; set => graduationDate = value; }
        public string GraduationRank { get => graduationRank; set => graduationRank = value; }
        public string Education { get => education; set => education = value; }

        public override string ToString()
        {
            return base.ToString() + "-|- GraduationDate : " + GraduationDate.ToString("dd/MM/yyyy") + "-|- GraduationRank : " + GraduationRank + "-|- Education : " + Education;
        }
    }



    
}
