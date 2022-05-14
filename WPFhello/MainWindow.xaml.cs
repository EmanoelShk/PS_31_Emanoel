using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            peopleListBox.Items.Add(james);

            ListBoxItem david = new ListBoxItem();
            david.Content = "David";
            peopleListBox.Items.Add(david);

            peopleListBox.SelectedItem = james;
        }

        private void bntHello_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            bool IsValidNameFound = false;

            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    if (((TextBox)item).Text.Length >= 2)
                    {
                        builder.AppendLine(((TextBox)item).Text);
                        IsValidNameFound = true;
                    }
                }
            }

            if (IsValidNameFound)
            {
                MessageBox.Show("Здравейте " + builder.ToString().Trim() + "!!! \nТова е твоята първа програма на VisualStudio 2012!");
            }
            else
            {
                MessageBox.Show("Не са намерени валидни имена");
            }
        }

        private void Calc1_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(txtN.Text, out int n))
            {
                int result = 1;
                while (n != 1)
                {
                    result = result * n;
                    n = n - 1;
                }
                MessageBox.Show(result.ToString());
            }
            else
            {
                MessageBox.Show("Въведени са невалидни данни");
            }
        }

        private void Calc2_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(txtN.Text, out int n) && Int32.TryParse(txtY.Text, out int y))
            {
                int result = 1;
                for (int i = 0; i < y; i++)
                {
                    result = result * n;
                }
                MessageBox.Show(result.ToString());
            }
            else
            {
                MessageBox.Show("Въведени са невалидни данни");
            }
        }

        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            string msg = "Сигурнили сте, че искате да затворите програмата?";
            MessageBoxResult result =
              MessageBox.Show(
                msg,
                "Data App",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void greet_btn_Click(object sender, RoutedEventArgs e)
        {
            //string greetingMsg;
            //greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            //MessageBox.Show("Hi " + greetingMsg);

            MyMessage anotherWindow = new MyMessage();
            anotherWindow.Show();
        }
    }
}
