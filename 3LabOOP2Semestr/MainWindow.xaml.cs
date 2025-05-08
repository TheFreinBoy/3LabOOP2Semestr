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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3LabOOP2Semestr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void DAButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.MainContent.Content = new UserControl1();
        }

        private void GenerateButtons_Click(object sender, RoutedEventArgs e)
        {
            ButtonsPanel.Children.Clear();

            if (!int.TryParse(FromTextBox.Text, out int from) || !int.TryParse(ToTextBox.Text, out int to) ||!int.TryParse(StepTextBox.Text, out int step) || step <= 0 || from > to)
            {
                ButtonError.Visibility = Visibility.Visible;
                return;
            }
            ButtonError.Visibility = Visibility.Collapsed;
            for (int i = from; i <= to; i += step)
            {
                var btn = new Button
                {
                    Content = i.ToString(),
                    Margin = new Thickness(3),
                    Padding = new Thickness(5),
                    Foreground = new SolidColorBrush(Colors.Black),
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f6ff00")),
                    BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f6ff00")),
                    Tag = i 
                };

                btn.Click += NumberButton_Click;

                ButtonsPanel.Children.Add(btn);
            }
        }


        private void RemoveMultiples_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(DeleteTextBox.Text, out int multiple) || multiple == 0)
            {
                ValidationError.Visibility = Visibility.Visible;
                return;
            }
            ValidationError.Visibility = Visibility.Collapsed;
            int removedCount = 0;

            for (int i = ButtonsPanel.Children.Count - 1; i >= 0; i--)
            {
                if (ButtonsPanel.Children[i] is Button btn &&
                    int.TryParse(btn.Content.ToString(), out int value) &&
                    value % multiple == 0)
                {
                    ButtonsPanel.Children.RemoveAt(i);
                    removedCount++;
                }
            }

            if (removedCount == 0)
            {
                DeleteError.Visibility = Visibility.Visible;
                return;
            }
            DeleteError.Visibility = Visibility.Collapsed;
        }

        private bool IsPrime(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int i = 3; i * i <= n; i += 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && int.TryParse(btn.Content.ToString(), out int number))
            {
                if (IsPrime(number))
                {
                    MessageBox.Show($"{number} — це просте число.");
                }
                else
                {
                    MessageBox.Show($"{number} — це складене число.");
                }
            }
        }     
    }
}
