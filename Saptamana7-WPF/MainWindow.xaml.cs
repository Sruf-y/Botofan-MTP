using Microsoft.Win32;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Saptamana7_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        private List<string> files = new List<String>();
        private List<string> items_list = new List<String>();
        private List<string> items_content = new List<String>();
        public MainWindow()
        {
            InitializeComponent();
            //string line;
            //List<Intrebare> list_intrebari = new List<Intrebare>();
            //StreamReader sr = new StreamReader("text.txt");


            string folderPath = "C:/Users/student/source/repos/Botofan-MTP/Saptamana7-WPF/File/";
            

           
            foreach (string file in Directory.EnumerateFiles(folderPath, "*txt"))
            {
                files.Add(file);
                string nume = file.Split("/").Last();
                items_list.Add(nume);
                choose_file.Items.Add(nume);
                items_content.Add(File.ReadAllText(file));
            }

            if(items_list.Count > 0 && items_content.Count>0)
            {
                choose_file.SelectedIndex = 0;
                Display_content_and_get_content.Text = items_content[choose_file.SelectedIndex];
            }

            





        }

        private void scriere(string file,string content)
        {
            File.WriteAllText(file, content);
            string aux = File.ReadAllText(file);

            items_content[choose_file.SelectedIndex] = aux;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            

            scriere(files[choose_file.SelectedIndex], Display_content_and_get_content.Text);
        }

        private void choose_file_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Display_content_and_get_content.Text = items_content[choose_file.SelectedIndex];
            File_head_name.Text = items_list[choose_file.SelectedIndex];
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog open_file = new OpenFileDialog();
            if (open_file.ShowDialog() == true)
            {
                try
                {
                    MessageBox.Show(open_file.FileName);
                    files.Add(open_file.FileName);
                    items_list.Add(open_file.FileName.Split("\\").Last());
                    items_content.Add(File.ReadAllText(open_file.FileName));
                    choose_file.Items.Add(items_list.Last());
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }

        private void Display_content_and_get_content_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(mycheckbox.IsChecked == true)
            {
                scriere(files[choose_file.SelectedIndex], Display_content_and_get_content.Text);
            }
        }
    }
}