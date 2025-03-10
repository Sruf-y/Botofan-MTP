using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Botofan_W1_2
{
    internal abstract class Card
    {
        private Persoana owner;
        private Cont cont;
        private string iban;
        private int suma;

        public Card(Persoana owner,Cont cont)
        {
            this.cont = cont;
            this.owner = owner;
            this.iban = $"{owner.Nume}{DateAndTime.Now.ToString()}";
            this.suma = 0;
        }

        public Card(Persoana owner,Cont cont,int suma)
        {
            this.cont= cont;
            this.owner = owner;
            this.iban = $"{owner.Nume}{DateAndTime.Now.ToString()}";
            this.suma = suma;
        }

        public void setsum(int suma) {  this.suma = suma; }
        public Persoana Owner { get { return owner; } set { owner = value; } }

        public string Iban { get { return iban; } set { iban = value; } }

        public Cont Cont { get { return cont; } set { cont = value; } }

        public int Balance { get { return suma; } set { suma = value; } }
        public override string ToString() { return $"{iban} {suma}"; }

        public abstract void doTransaction(int val);

    }
}
