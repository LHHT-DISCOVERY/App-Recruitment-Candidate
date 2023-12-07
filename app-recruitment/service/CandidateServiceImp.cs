using app_recruitment.model;
using app_recruitment.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.service
{
    internal class CandidateServiceImp : ICandidateService
    {
        ICandidateRepository candidateRepository = new CandidateRepositoryImp();

        public void deleteCandidade(int id)
        {
            candidateRepository.deleteCanidate(id);
        }

        public void enterCanidate()
        {
            candidateRepository.enterCandidate();

        }

        public Candidate findCandidateById(int id)
        {
           return candidateRepository.findCandidateById(id);
        }

        public List<T> getAll<T>() where T : Candidate
        {
            return candidateRepository.getAll<T>();
        }

        public List<Candidate> sortByTypeAndBirthDayService(List<Candidate> candidates)
        {
            return candidateRepository.sortByTypeAndBirthDayService(candidates);
            throw new NotImplementedException();
        }

        public void updateCandidate(int id)
        {
            candidateRepository.updateCandidate(id);
        }

        public void viewFullNameCandidate()
        {
            candidateRepository.viewFullNameCandidate();
        }
    }
}
