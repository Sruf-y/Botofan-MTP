// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

//Console.WriteLine("Hello, World!");

namespace Botofan_W1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {



            //Autor autor = new Autor("Eminescu", "Mihai");
            //Carte carte = new Carte("Luceafarul", autor, 1920);
            //Carte carte2 = new Carte("Maia", autor, 1987);

            //autor.AdaugaCarte(carte);
            //autor.AdaugaCarte(carte2);

            //autor.Afisare();


            //Persoana pers1=new Persoana("Botofan","Andrei",4820489,0735233135);
            //Cont contbancar=new Cont(pers1,"andreibotofan@gmail.com","Bobo2");
            //Card card_nou = new Credit(pers1,contbancar);
            //Card card_2=new Debit(pers1,contbancar,250);

            //contbancar.AddCard(card_nou);
            //contbancar.AddCard(card_2);



            //Console.WriteLine(pers1.ToString()); Console.WriteLine("\n");
            //Console.WriteLine(contbancar.ToString()); Console.WriteLine("\n");


            //card_nou.doTransaction(-53);
            //Console.WriteLine(card_nou.ToString());Console.WriteLine("\n");


            exercitiul6();







        }
        static void exercitiul1()
        {
            ArrayList aray = new ArrayList();

            aray.Add(new { id = 45, nume = "Botofan", nota = 7 });
            aray.Add(new { id = 24, nume = "Andrei", nota = 8 });
            aray.Add(new { id = 65, nume = "Nicolae", nota = 10 });
            aray.Add(new { id = 83, nume = "Alex", nota = 9.5 });

            foreach (dynamic i in aray)
            {
                Console.Write(i.id + " "); Console.Write(i.nume + " "); Console.WriteLine(i.nota);
            }
        }

        static void exercitiul2()
        {
            ArrayList aray = new ArrayList();

            aray.Add(new { id = 45, nume = "Botofan", nota = 7.0 });
            aray.Add(new { id = 24, nume = "Andrei", nota = 8.0 });
            aray.Add(new { id = 65, nume = "Nicolae", nota = 10.0 });
            aray.Add(new { id = 83, nume = "Alex", nota = 9.5 });


            student[] students=new student[4];

            int i = 0;
            foreach (dynamic s in aray)
            {
                students[i]=new student((int)s.id, (string)s.nume, (float)s.nota);
                i++;
            }
            

            var studentipremiants = from n in students where n.nota > 8 select n;

            foreach (student s in studentipremiants)
                Console.WriteLine(s.nume);
        }

        internal class student
        {
            public int id;
            public string nume;
            public float nota;

            public student(int id, string nume, float nota)
            {
                this.id = id;
                this.nume = nume;
                this.nota = nota;
            }
            public student(int id, string nume, int nota)
            {
                this.id = id;
                this.nume = nume;
                this.nota = (float)nota;
            }

        }




        static void exercitiul3()
        {
            

            try
            {
                short a = short.MaxValue;
                short b = 50;

                short sum = checked((short)(a + b));
            }
            catch(OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Overflown");
            }
        }

        static void exercitiul4() {
            int a, b, c;
            String line;
            DateTime today= DateTime.Now;

            Console.WriteLine("Zi: ");
            line = Console.ReadLine();
            a=int.Parse(line);
            Console.WriteLine("Luna: ");
            line = Console.ReadLine();
            b = int.Parse(line);
            Console.WriteLine("An: ");
            line = Console.ReadLine();
            c = int.Parse(line);

            DateTime target = new DateTime(c, b, a);

            Console.WriteLine("\nAni trecuti: "+(today.Subtract(target).Days/365));



        }
        static void exercitiul5() {
            StringBuilder a =new StringBuilder( "Buna ziua doamnelor si domnilor! Si buna sa va fie inima!");

            a.Replace("buna", "rea");
            a.Replace("Buna", "Rea");
            a.Replace("BUNA", "REA");

            Console.WriteLine(a);
        }



        public delegate int SumaDelegat(int a, int b);
        static void exercitiul6() {

            SumaDelegat delegat = AfisareSume;

            Console.WriteLine(delegat(5, 7));
           
        }
        static int AfisareSume(int a, int b)
        {
            return a + b;
        }
        
        

    }


}


