using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace SqlClientWPF
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

        private void OpenClient(object sender, RoutedEventArgs e)
        {
            SqlClientMode scm = new SqlClientMode();
            this.Visibility = Visibility.Hidden;
            scm.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void tableSqlMode_Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("not done yet");
        }

        private void workWithDataMode_Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("not done yet");
        }

        private void exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("You are sure?", "quest", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
