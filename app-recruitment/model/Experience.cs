using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.model
{
    internal class Experience : Candidate
    {
        private int experienceYear;
        private String proSkill;


        public Experience() { }
        public Experience(int candidateID, string candidateFullName, DateTime birthday, string phone, string email, int candidateType , List<Certificate> certificate, int experienceYear, String proSkill) : base(candidateID , candidateFullName , birthday , phone , email , candidateType , certificate)
        {
            this.ExperienceYear = experienceYear;
            this.ProSkill = proSkill;
        }

        public Experience(int candidateID, string candidateFullName, DateTime birthday, string phone, string email, int candidateType,  int experienceYear, String proSkill) : base(candidateID, candidateFullName, birthday, phone, email, candidateType)
        {
            this.ExperienceYear = experienceYear;
            this.ProSkill = proSkill;
        }

        public int ExperienceYear { get => experienceYear; set => experienceYear = value; }
        public string ProSkill { get => proSkill; set => proSkill = value; }

        public override string ToString()
        {
            return base.ToString() + "-|- ExperienceYear : " + ExperienceYear + " Year " +  "-|- ProSkill : " + ProSkill;
        }
    }
}
