using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botofan_W1_2
{
    internal class Cont
    {
        private Persoana owner;
        private string gmail;
        private string password;
        private List<Card> cards;


        public Cont(Persoana owner, string gmail, string password)
        {
            this.owner = owner;
            this.gmail = gmail;
            this.password = password;
            this.cards = new List<Card>();
        }
        
        public void AddCard(Card card) { cards.Add(card); }

        public void RemoveCard(Card card) 
        {
            if (card.Balance == 0)
                cards.Remove(card);
            else
                Console.WriteLine("Impossible operation, cannot remove non-0 balance cards.");
        }

        public string Gmail{ get { return gmail; } set { gmail = value; } }
        public string Password { get { return password; } set { password = value; } }


        public override string ToString()
        {
            string str=$"{owner.ToString()}";
            for (int i = 0; i < cards.Count; i++)
            {
                str =str+$"\n{cards[i].ToString()}";
            }
            return str;
        }
    }
}
