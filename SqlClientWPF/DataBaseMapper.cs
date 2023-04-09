using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlClientWPF
{
    internal class DataBaseMapper
    {
        private string constr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        public List<Vegetable> MapVegetableTable()
        {
            SqlConnection con = null;
            try
            {
                List<Vegetable> vegetableList = new List<Vegetable>();
                con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from vegetables_t", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader[0]);
                    string name = Convert.ToString(reader[1]);
                    decimal price = Convert.ToDecimal(reader[2]);
                    vegetableList.Add(new Vegetable(id,name,price));
                }
                con.Close();
                return vegetableList;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"DataBaseMapper: exseption {ex.Message}");
                throw ex;
            }
            finally
            {
                if(con != null)
                {
                    con.Close();
                }
            }

        }
        public List<Vegetable> AddVegetable(Vegetable vegetable)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(constr);
                con.Open();
                SqlParameter _name = new SqlParameter("@p1", vegetable.Name);
                SqlParameter _price = new SqlParameter("@p2", vegetable.Price);
                SqlCommand cmd = new SqlCommand($"INSERT INTO Vegetables_t VALUES(@p1,@p2)", con);
                cmd.Parameters.Add(_name);
                cmd.Parameters.Add(_price);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return MapVegetableTable();
        }
        public List<Vegetable> RemoveVegetable(Vegetable vegetable)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(constr);
                con.Open();
                SqlParameter _id = new SqlParameter("@p1", vegetable.Id);
                SqlCommand cmd = new SqlCommand($"DELETE Vegetables_t WHERE id = @p1", con);
                cmd.Parameters.Add(_id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return MapVegetableTable();
        }
        public List<Vegetable> UpdateVegetable(Vegetable vegetable)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(constr);
                con.Open();
                SqlParameter _name = new SqlParameter("@p1", vegetable.Name);
                SqlParameter _price = new SqlParameter("@p2", vegetable.Price);
                SqlParameter _id = new SqlParameter("@p3", vegetable.Id);
                SqlCommand cmd = new SqlCommand($"UPDATE Vegetables_t SET Name_f = @p1, Price_f = @p2 WHERE Id = @p3", con);
                cmd.Parameters.Add(_name);
                cmd.Parameters.Add(_price);
                cmd.Parameters.Add(_id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return MapVegetableTable();
        }
    }
}
