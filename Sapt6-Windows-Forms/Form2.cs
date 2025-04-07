using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sapt6_Windows_Forms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string NUME;
        int TEST;
        public Form2(string nume,int test)
        {
            NUME = nume;
            TEST = test;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = NUME;

            string line;
            List<Intrebare> list_intrebari = new List<Intrebare>();
            StreamReader sr = new StreamReader("text.txt");

            while ((line = sr.ReadLine()) != null)
            {

                list_intrebari.Add(new Intrebare(line));

            }
            sr.Close();

            

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;

            Intrebare intrebare_aleasa = list_intrebari[TEST];

            Label nume_intrebare = new Label();
            nume_intrebare.Text = intrebare_aleasa.question_text;


            Label questiontext = new Label();
            questiontext.Text= intrebare_aleasa.question_text;
            questiontext.Width = 500;

            flowLayoutPanel1.Controls.Add(questiontext);


        }

        
    }
}
