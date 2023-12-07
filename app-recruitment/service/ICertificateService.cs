using app_recruitment.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.service
{
    internal interface ICertificateService
    {
        List<Certificate> getAll();
        void addCertificate(int candidateID, Certificate certificate);
    }
}
