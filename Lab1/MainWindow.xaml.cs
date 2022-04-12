using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Lab1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static readonly Regex _regex = new Regex("[^0-9-]+");
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void TextBA_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void ButEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = 0;
                int a = Convert.ToInt32(TextBA.Text);
                int b = Convert.ToInt32(TextBB.Text);
                int c = Convert.ToInt32(TextBC.Text);
                double D = 0;
                D = (b * b) - (4 * a * c);
                Output.Clear();

                if(D<0)
                    Output.Text = "D = " +D+ " \nКорней нет";
                if (D == 0)
                {
                    x = -((b) / (2 * a));
                    Output.Text = "D = " + D + " \n x = " + x;
                }
                if(D>0)
                {
                    x = (-b + Math.Sqrt(D)) / (2 * a);
                    Output.Text = "D = " + D + " \nx1 = " + x;
                    x = (-b - Math.Sqrt(D)) / (2 * a);
                    Output.Text += "\nx2 = " + x;
                }

            }
            catch
            {
                MessageBox.Show("Проверьте введённые числа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
