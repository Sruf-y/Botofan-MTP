﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saptamana5_Windows_Forms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void Form2_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 0;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataListView.Items.Clear();
            dataListView.Items.Add("Nume: "+textBox1.Text);
            dataListView.Items.Add("Prenume: " + textBox2.Text);
            dataListView.Items.Add("Varsta: "+numericUpDown1.Value.ToString());
            dataListView.Items.Add("Oras: "+listBox1.SelectedItem.ToString());

        }
    }
}
