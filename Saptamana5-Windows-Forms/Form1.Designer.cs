namespace Saptamana5_Windows_Forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Confirm_Buton = new Button();
            username = new TextBox();
            password = new TextBox();
            SuspendLayout();
            // 
            // Confirm_Buton
            // 
            Confirm_Buton.Location = new Point(346, 235);
            Confirm_Buton.Name = "Confirm_Buton";
            Confirm_Buton.Size = new Size(75, 23);
            Confirm_Buton.TabIndex = 0;
            Confirm_Buton.Text = "Confirm";
            Confirm_Buton.UseVisualStyleBackColor = true;
            Confirm_Buton.Click += confirm_buton_click;
            // 
            // username
            // 
            username.Location = new Point(313, 92);
            username.Name = "username";
            username.PlaceholderText = "Username";
            username.Size = new Size(200, 23);
            username.TabIndex = 2;
            username.KeyPress += username_KeyPress;
            // 
            // password
            // 
            password.Location = new Point(313, 162);
            password.Name = "password";
            password.PasswordChar = '*';
            password.PlaceholderText = "Password";
            password.Size = new Size(200, 23);
            password.TabIndex = 3;
            password.KeyPress += password_KeyPress;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(692, 461);
            Controls.Add(password);
            Controls.Add(username);
            Controls.Add(Confirm_Buton);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Confirm_Buton;
        private TextBox username;
        private TextBox password;
    }
}
