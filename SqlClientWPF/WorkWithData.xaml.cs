using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для WorkWithData.xaml
    /// </summary>
    public partial class WorkWithData : Window
    {
        private DataBaseContstoller db = null;
        public WorkWithData()
        {
            InitializeComponent();
            db = new DataBaseContstoller();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("You are sure?", "quest", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBaseMapper mapper = new DataBaseMapper();
                List<Vegetable> vegetables = mapper.MapVegetableTable();
                VegetablesListBox.ItemsSource = vegetables;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Close();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            if (NameTextBox.Text == "" || PriceTextBox.Text == "")
            {
                MessageBox.Show("Заполните все данные в форме");
            }
            else
            {
                DataBaseMapper mapper = new DataBaseMapper();
                Vegetable v = new Vegetable(0, NameTextBox.Text, Convert.ToDecimal(PriceTextBox.Text));
                VegetablesListBox.ItemsSource = mapper.AddVegetable(v);
            }

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (IdTextBox.Text == "" || NameTextBox.Text == "" || PriceTextBox.Text == "")
            {
                MessageBox.Show("Заполните все данные в форме");
            }
            else
            {
                DataBaseMapper mapper = new DataBaseMapper();
                Vegetable v = new Vegetable(Convert.ToInt32(IdTextBox.Text), NameTextBox.Text, Convert.ToDecimal(PriceTextBox.Text));
                VegetablesListBox.ItemsSource = mapper.RemoveVegetable(v);
            }

        }

        private void VegetablesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VegetablesListBox.SelectedIndex != -1)
            {
                Vegetable obj = (Vegetable)VegetablesListBox.SelectedItem;
                IdTextBox.Text = obj.Id.ToString();
                NameTextBox.Text = obj.Name;
                PriceTextBox.Text = obj.Price.ToString();
            } else
            {
                IdTextBox.Text = "";
                NameTextBox.Text = "";
                PriceTextBox.Text = "";
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (IdTextBox.Text == "" || NameTextBox.Text == "" || PriceTextBox.Text == "")
            {
                MessageBox.Show("Заполните все данные в форме");
            }
            else
            {
                DataBaseMapper mapper = new DataBaseMapper();
                Vegetable v = new Vegetable(Convert.ToInt32(IdTextBox.Text), NameTextBox.Text, Convert.ToDecimal(PriceTextBox.Text));
                VegetablesListBox.ItemsSource = mapper.UpdateVegetable(v);
            }
        }
    }
}
