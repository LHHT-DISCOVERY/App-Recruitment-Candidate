using app_recruitment.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.service
{
    internal interface ICandidateService
    {
        List<T> getAll<T>() where T : Candidate;
        void enterCanidate();
        void deleteCandidade(int id);

        void updateCandidate(int id);

        Candidate findCandidateById(int  id);

        void viewFullNameCandidate();
    }
}
