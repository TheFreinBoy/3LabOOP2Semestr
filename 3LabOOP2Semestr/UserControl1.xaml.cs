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
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        Random rnd = new Random();
        public UserControl1()
        {
            InitializeComponent();
        }
        private void EscButton_MouseEnter(object sender, MouseEventArgs e)
        {
            double maxX = MainCanvas.ActualWidth - NoButton.ActualWidth;
            double maxY = MainCanvas.ActualHeight - NoButton.ActualHeight;
            if (maxX <= 0 || maxY <= 0) return;

            Point mousePos = e.GetPosition(MainCanvas);
            double safeDistance = Math.Max(NoButton.ActualWidth, NoButton.ActualHeight);
            double newX, newY;
            int attempts = 0;

            do
            {
                newX = rnd.NextDouble() * maxX;
                newY = rnd.NextDouble() * maxY;
                attempts++;
            }
            while (Math.Sqrt(
                       Math.Pow(newX + NoButton.ActualWidth / 2 - mousePos.X, 2) +
                       Math.Pow(newY + NoButton.ActualHeight / 2 - mousePos.Y, 2)
                   ) < safeDistance
                   && attempts < 100);

            Canvas.SetLeft(NoButton, newX);
            Canvas.SetTop(NoButton, newY);
        }
        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дякую!");
        }
    }
}
