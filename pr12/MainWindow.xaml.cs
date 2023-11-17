using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace pr12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        DispatcherTimer timer;

        private void btnResult1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double value1 = Convert.ToDouble(tbValue1.Text),
                    value2 = Convert.ToDouble(tbValue2.Text);

                double result = Work12.GetGeometricalAvearge(value1, value2);

                btnResult1.Content = result;

                tbValue1.Focus();
            }
            catch (ArgumentException ex)
            {
                tbValue1.Focus();
                tbWarning1.Text = ex.Message;
            }
            catch (FormatException)
            {
                tbValue1.Focus();
                tbWarning1.Text = "Вводить нужно только числа!";
            }
        }

        private void btnResult2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(tbValue3.Text),
                    result = Work12.ChangeDigits(value);

                btnResult2.Content = result;
                tbValue3.Focus();
            }
            catch (ArgumentException ex)
            {
                tbWarning2.Text = ex.Message;
                tbValue3.Focus();
            }
            catch (FormatException)
            {
                tbValue3.Focus();
                tbWarning2.Text = "Вводить нужно только числа!";
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("О программе");
        }

        private void tbValue1_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetDefaultButton(btnResult1, tbWarning1);
        }

        private void tbValue2_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetDefaultButton(btnResult1, tbWarning1);
        }

        private void tbValue3_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetDefaultButton(btnResult2, tbWarning2);
        }

        /// <summary>
        /// Задает стандартное представление кнопке
        /// </summary>
        /// <param name="button">кнопка</param>
        /// <param name="textBlock">текст блок с предупреждением</param>
        private void SetDefaultButton(object button, object textBlock)
        {
            ((Button)button).Content = "Посмотреть результат";
            ((TextBlock)textBlock).Text = "";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new();
            timer.Tick += Timer_Tick;
            timer.Interval = new(0, 0, 0, 1, 0);
            timer.IsEnabled = true;

            tbNumber.Text = "Задание 1";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            tbTime.Text = date.ToString("HH:mm");
            tbDate.Text = date.ToString("dd.MM.yyyy");
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = mainTabControl.SelectedIndex;
            
            switch (index)
            {
                case 0:
                    tbNumber.Text = "Задание 1";
                    break;
                case 1:
                    tbNumber.Text = "Задание 2";
                    break;
                case 2:
                    tbNumber.Text = "Основное";
                    break;
            }
        }
    }
}
