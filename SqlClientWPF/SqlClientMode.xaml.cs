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

namespace SqlClientWPF
{
    /// <summary>
    /// Логика взаимодействия для SqlClientMode.xaml
    /// </summary>
    public partial class SqlClientMode : Window
    {
        private DataBaseContstoller db = null;
        public SqlClientMode()
        {
            InitializeComponent();
            db = new DataBaseContstoller();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getResponseTextBox.Text = db.ExecuteSql(inputRequestTextBox.Text);
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