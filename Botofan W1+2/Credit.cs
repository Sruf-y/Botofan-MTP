using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botofan_W1_2
{
    internal class Credit : Card
    {
        public Credit(Persoana owner, Cont cont) : base(owner, cont)
        {
            Owner = owner;
            Cont = cont;
            Iban = $"{owner.Nume}{DateAndTime.Now.ToString()}";
            setsum(0); 


        }
        public Credit(Persoana owner, Cont cont, int suma) : base(owner, cont, suma)
        {
            Owner = owner;
            Cont = cont;
            Iban = $"{owner.Nume}{DateAndTime.Now.ToString()}";
            setsum(suma);
        }
        

        public override void doTransaction(int value) { this.setsum(Balance + value); }
    }
}
