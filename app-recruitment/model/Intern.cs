using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.model
{
    internal class Intern : Candidate
    {
        private String majors;
        private int semester;
        private String universityName;

        public Intern() { }
        public Intern(int candidateID, string candidateFullName, DateTime birthday, string phone, string email, int candidateType, string majors, int semester, string universityName) : base(candidateID, candidateFullName, birthday, phone, email, candidateType)
        {
            this.majors = majors;
            this.semester = semester;
            this.universityName = universityName;
        }

        public Intern(int candidateID, string candidateFullName, DateTime birthday, string phone, string email, int candidateType, List<Certificate> certificate, string majors, int semester, string universityName) : base(candidateID, candidateFullName, birthday, phone, email, candidateType, certificate)
        {
            this.majors = majors;
            this.semester = semester;
            this.universityName = universityName;
        }

        public string Majors { get => majors; set => majors = value; }
        public int Semester { get => semester; set => semester = value; }
        public string UniversityName { get => universityName; set => universityName = value; }

        public override string ToString()
        {
            return base.ToString() + " -|- Majors : " + Majors + "-|- Semester  : " + Semester + "-|- universityName : " + universityName;
        }
    }
}
