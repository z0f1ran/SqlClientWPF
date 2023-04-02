using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace SqlClientWPF
{
    internal class DataBaseContstoller
    {
        public DataBaseContstoller(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public DataBaseContstoller()
        {
            ConnectionString = null;
        }

        private string ConnectionString { get; set; }
        public string ExecuteSql(string query)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                string p = query.Split(' ')[0];
                if (p.ToLower() == "select")
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        sb.Append(reader.GetName(i));
                        sb.Append('-');
                    }
                    sb.Append("\n");
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            sb.Append(reader[i]);
                            sb.Append(' ');
                        }
                        sb.Append('\n');
                    }
                    return sb.ToString();
                }
                else if(p.ToLower() == "update" &&
                    p.ToLower() == "insert" &&
                    p.ToLower() == "delete")
                {
                    cmd.ExecuteNonQuery();
                    return "Операция выполнена";
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public void SetConnectinon(string str) => ConnectionString = str; 
    }
}