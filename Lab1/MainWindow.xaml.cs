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
                LabD.Content = "D = " + D;

                if (D<0)
                    LabD.Content = "D < 0";
                if (D == 0)
                {
                    x = -((b) / (2 * a));
                    Labx2.Content = "x2 = " + x;
                    Labx1.Content = "x1 = " + x;
                }
                if(D>0)
                {
                    x = (-b + Math.Sqrt(D)) / (2 * a);
                    Labx1.Content = "x1 = " + x;
                    x = (-b - Math.Sqrt(D)) / (2 * a);
                    Labx2.Content = "x2 = " + x;
                }

            }
            catch
            {
                MessageBox.Show("Проверьте введённые числа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
