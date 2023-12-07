using app_recruitment.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.repository
{
    internal interface ICandidateRepository
    {
        List<T> getAll<T>() where T : Candidate;
        void enterCandidate();
        void deleteCanidate(int id);
        void updateCandidate(int id);

        Candidate findCandidateById(int id);

        void viewFullNameCandidate();

        List<Candidate> sortByTypeAndBirthDayService(List<Candidate>  candidates);
    }

}
