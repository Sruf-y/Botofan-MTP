namespace Saptamana5_Windows_Forms
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            checkedListBox1 = new CheckedListBox();
            label2 = new Label();
            label3 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Items.AddRange(new object[] { "Timisoara", "Cluj", "Mosnita noua", "Sighisoara", "Muntele mic", "Craiova", "Bucuresti", "Croatia", "Pitesti" });
            listBox1.Location = new Point(101, 363);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(137, 139);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(101, 78);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(253, 178);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "DatePersonale";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 135);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "Varsta";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(87, 133);
            numericUpDown1.Maximum = new decimal(new int[] { 110, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 2;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(39, 86);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Prenume";
            textBox2.Size = new Size(168, 23);
            textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(39, 40);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nume";
            textBox1.Size = new Size(168, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "C", "C++", "C#", "Java", "Kotlin", "Rust", "Python", "Javascript", "Arduino", "Verilog", "Assembly" });
            checkedListBox1.Location = new Point(351, 327);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(120, 202);
            checkedListBox1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 345);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 6;
            label2.Text = "Provenienta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(326, 294);
            label3.Name = "label3";
            label3.Size = new Size(188, 15);
            label3.TabIndex = 7;
            label3.Text = "Limbaje de programare cunoscute";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 569);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(checkedListBox1);
            Controls.Add(groupBox1);
            Controls.Add(listBox1);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form2";
            Load += Form2_Load;
            Click += Form2_Click;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        private ListBox listBox1;
        private GroupBox groupBox1;
        private NumericUpDown numericUpDown1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label1;
        private CheckedListBox checkedListBox1;
        private Label label2;
        private Label label3;
    }
}