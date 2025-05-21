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
        public TelOperationsWindow()
        {
            InitializeComponent();
            myButton.Content = "Insert item";
        }
        public TelOperationsWindow(int index,string firma, string model, int? baterie, DateTime? releaseDate, decimal price)
        {
            InitializeComponent();
            InitializeTextBoxes( firma, model, baterie, releaseDate,price);
            id = index;

            myButton.Content = "Modify item";
        }



        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            if (id != null)
            {

            }
            else
            {

            }
        }



        private void InitializeTextBoxes(string firma, string model, int? baterie, DateTime? releaseDate, decimal price)
        {
            firmaBox.Text = model;
            modelBox.Text=model;
            baterieBox.Text = (baterie!=null)?baterie.ToString():0.ToString();
            dateBox.SelectedDate = (releaseDate!=null)?releaseDate:DateTime.Now;
            priceBox.Text = price.ToString();

        }
    }
}
