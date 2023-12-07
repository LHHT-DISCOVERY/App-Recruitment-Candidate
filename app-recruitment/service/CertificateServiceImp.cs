using app_recruitment.model;
using app_recruitment.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.service
{
    internal class CertificateServiceImp : ICertificateService
    {
        ICertificateRepository certificateRepository = new CertificateRepositoryImp();

        public void addCertificate(int candidateID, Certificate certificate)
        {
            certificateRepository.addCertificate(candidateID, certificate);
        }

        public List<Certificate> getAll()
        {
           return certificateRepository.getAll();
        }
    }
}
