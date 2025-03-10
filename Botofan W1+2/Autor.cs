using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Botofan_W1_2
{
    internal class Autor
    {
        private string name;
        private string prenume;

        List<Carte> carti_scrise;

        public Autor(string name, string prenume)
        {
            this.name = name;
            this.prenume = prenume;
            carti_scrise = new List<Carte>();
        }

        public object get { get; private set; }

        public void AdaugaCarte(Carte cartea)
        {
            carti_scrise.Add(cartea);
        }

        public List<Carte> Carti { get { return carti_scrise; } set { carti_scrise = value; } }

        public void Afisare()
        {
            Console.WriteLine($"Nume: {this.ToString()} \nNr carti scrise:   {carti_scrise.Count}");
            for(int i=0;i<carti_scrise.Count;i++)
            {
                Console.WriteLine($"{carti_scrise[i].Titlu}");
            }
        }

        public override string ToString()
        {
            return $"{name} {prenume}";
        }
    }
}
