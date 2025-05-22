using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.IdentityModel.Tokens;

namespace Saptamana8_WPF
{
    /// <summary>
    /// Interaction logic for CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        Action action = null;
        public CreateUserWindow(Action action)
        {
            InitializeComponent();
            this.action = action;
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;

            if (!username.IsNullOrEmpty() && !password.IsNullOrEmpty())
            {
                if (DataBase.UserController.Insert(username, password))
                {
                    MessageBox.Show("User inserted succesfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    action?.Invoke();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Fill in username and password.","Incomplete",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
