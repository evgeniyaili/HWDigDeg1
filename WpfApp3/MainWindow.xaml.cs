using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp3.ServiceReference1;
using static System.Net.WebRequestMethods;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        private const string sortedFile = "D:\\ДигДесПроект\\Result\\Done4.txt";
        //Service1Client service1;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Do ()
        {
            var myService = new ServiceReference1.Service1Client();

            var result = myService.TextInput(tb.Text);

            StreamWriter streamwriter = new StreamWriter(sortedFile);
            foreach (var word in result)
            {
                streamwriter.WriteLineAsync(String.Format("{0} : {1}", word.Key, word.Value));
            }
            streamwriter.Close();
        }
        public void button_Click(object sender, RoutedEventArgs e)
        {
            string myFile = tb.Text;

            if (myFile != null)
            {
                MessageBox.Show("Готово! Результат расположен в D:\\ДигДесПроект\\Result\\Done4.txt");
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }
    }
}
