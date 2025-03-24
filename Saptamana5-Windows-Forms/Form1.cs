namespace Saptamana5_Windows_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void confirm_buton_click(object sender, EventArgs e)
        {
            if (username.Text == "Andrei" && password.Text == "Botofan")
            {
                Form form2 = new Form2();
                MessageBox.Show("Authentificated");
                form2.ShowDialog();
            }
        }


        private void username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                password.Select();
                password.Focus();
            }
        }
        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (username.Text == "Andrei" && password.Text == "Botofan")
                {
                    Form form2 = new Form2();
                    MessageBox.Show("Authentificated");
                    form2.ShowDialog();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            username.Text = "Andrei";
            password.Text = "Botofan";
        }
    }
}
