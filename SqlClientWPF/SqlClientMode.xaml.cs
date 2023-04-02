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
            db.SetConnectinon(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Vegetables; Integrated Security=SSPI;");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getResponseTextBox.Text = db.ExecuteSql(inputRequestTextBox.Text);
        }
    }
}