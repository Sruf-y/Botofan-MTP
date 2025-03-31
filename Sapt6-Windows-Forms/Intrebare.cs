using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapt6_Windows_Forms
{
    public enum Tip_Intrebare
    {
        SINGLE,
        MULTIPLE
    }


    internal class Intrebare
    {
        public int numar{get; set;}
        public Tip_Intrebare Tip_Intrebare { get; set;}=Tip_Intrebare.SINGLE;
        public string question_text { get; set; } = "";
        public int nr_answers { get; set;}
        public List<String> answer_list { get; set; } = new List<string>();
        public string has_picture { get; set; } = "";
        public List<int> correct_responses { get; set; } = new List<int>();

        public Intrebare() { }
        public Intrebare(int numar, Tip_Intrebare Tip_Intrebare, string question_text, int nr_answers, List<string> answer_list, string has_picture, List<int> correct_responses)
        {
            this.numar = numar;
            this.Tip_Intrebare = Tip_Intrebare;
            this.question_text = question_text;
            this.nr_answers = nr_answers;
            this.answer_list = answer_list;
            this.has_picture = has_picture;
            this.correct_responses = correct_responses;
        }

        public Intrebare(string item)
        {
            string[] pieces=item.Split('/');
            this.numar = int.Parse(pieces[0]);
            this.Tip_Intrebare = Tip_Intrebare.Parse<Tip_Intrebare>(pieces[1].ToUpper());
            this.question_text = pieces[2];
            this.nr_answers = int.Parse(pieces[3]);
            int i;
            for(i=4; i < 3+nr_answers; i++)
            {
                this.answer_list.Add(pieces[i]);
            }

            this.has_picture = pieces[i];
            i++;
            string[] numbers = pieces[i].Split(',');

            for (int j = 0; j < numbers.Length; j++)
            {
                this.correct_responses.Add(int.Parse(numbers[j]));
            }
            this.correct_responses = correct_responses;
        }

        public override string ToString()
        {
            return numar.ToString()+"\n"+Tip_Intrebare.ToString()+ "\n" + question_text+ "\n";
        }
    }
}
