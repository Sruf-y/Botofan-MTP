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

namespace Saptamana8_WPF.Operations
{
    


    /// <summary>
    /// Interaction logic for TelOperationsWindow.xaml
    /// </summary>
    public partial class TelOperationsWindow : Window
    {
        int? id = null;
        Action action = null;

        public TelOperationsWindow(Action a=null)
        {
            InitializeComponent();
            myButton.Content = "Insert item";

            myButton.Click += tryOperation;

            action = a;
        }
        public TelOperationsWindow(int index,string firma, string model, int? baterie, DateTime? releaseDate, decimal price,Action a = null)
        {
            InitializeComponent();
            InitializeTextBoxes( firma, model, baterie, releaseDate,price);
            id = index;

            myButton.Content = "Modify item";

            myButton.Click += tryOperation;

            action = a;
        }

        

        private void tryOperation(object sender, RoutedEventArgs e)
        {
            string firma = firmaBox.Text;
            string model = modelBox.Text;
            int? baterie = (baterieBox.Text != "") ? int.Parse(baterieBox.Text) : null;
            DateTime? releaseDate = dateBox.SelectedDate;
            decimal price = decimal.Parse(priceBox.Text);
            if (id == null)
            {
                DataBase.TelController.Insert(firma, model, baterie, releaseDate, price);
                MessageBox.Show("Inserted succesfully!", "Sql Insert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                DataBase.TelController.Update((int)id, firma, model, baterie, releaseDate, price);
                MessageBox.Show("Updated succesfully!", "Sql Update", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            action?.Invoke();
            this.Close();
        }
        



        private void InitializeTextBoxes(string firma, string model, int? baterie, DateTime? releaseDate, decimal price)
        {
            firmaBox.Text = firma;
            modelBox.Text=model;
            baterieBox.Text = (baterie!=null)?baterie.ToString():0.ToString();
            dateBox.SelectedDate = (releaseDate!=null)?releaseDate:DateTime.Now;
            priceBox.Text = price.ToString();

        }

        private void modelBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
