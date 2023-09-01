using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kura
{
    public class takim
    {
        private string takimIsmi;
        private string takimUlke;
        public int puan;
        public int oynananMac;

        public takim(string Ismi, string Ulke)
        {
            this.takimIsmi = Ismi;
            this.takimUlke = Ulke;
            this.puan = 0;
            this.oynananMac = 0;
        }

        public string TeamName
        {
            get { return takimIsmi; }
            set { takimIsmi = value; }
        }

        public string TeamCountry
        {
            get { return takimUlke; }
            set { takimUlke = value; }
        }

        public int TeamPoint
        {
            get { return puan; }
            set { puan = value; }
        }

        public int TeamMatch
        {
            get { return oynananMac; }
            set { oynananMac = value; }
        }

        public override string ToString()
        {
            return takimIsmi + " (" + takimUlke + ")";
        }

       
    }
}
