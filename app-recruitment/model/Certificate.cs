using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.model
{
    internal class Certificate
    {
        private int cerID;
        private String cerName;
        private String cerRank;
        private DateTime cerDate;

        public Certificate() { }

        public Certificate(int cerID, string cerName, string cerRank, DateTime cerDate)
        {
            this.cerID = cerID;
            this.cerName = cerName;
            this.cerRank = cerRank;
            this.cerDate = cerDate;
        }

        public int CerID { get => cerID; set => cerID = value; }
        public string CerName { get => cerName; set => cerName = value; }
        public string CerRank { get => cerRank; set => cerRank = value; }
        public DateTime CerDate { get => cerDate; set => cerDate = value; }

        public override string ToString()
        {
            return CerID + " -|- cerName : " + CerName + " -|- cerRank : " + CerRank + " -|- cerDate : " + CerDate.ToString("dd/MM/yyyy");
        }
    }
}
