using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botofan_W1_2
{
    internal class Carte
    {
        private string titlu;
        private Autor autor;
        private int an;

        public string Titlu { get { return titlu; } set { titlu = value; } }


        public Carte(string titlu, Autor autor, int an)
        {
            this.titlu = titlu;
            this.autor = autor;
            this.an = an;
        }

        
    }
}
