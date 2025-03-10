using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botofan_W1_2
{
    internal class Persoana
    {
        private string nume;
        private string prenume;
        private int cnp;
        private int phone_number;
        private List<Cont> conturi;


        public int CNP { get { return cnp; } set { cnp = value; } }
        public string Nume { get { return nume; } set { nume = value; } }
        public string Prenume { get { return prenume; } set { prenume = value; } }
        public int Phone { get { return phone_number; } set { phone_number = value; } }

        public override string ToString()
        {
            return $"{nume} {prenume}";
        }
        public Persoana(string nume, string prenume, int cnp, int phone_number)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.cnp = cnp;
            this.phone_number = phone_number;
            this.conturi = new List<Cont>();
        }
    }
}
