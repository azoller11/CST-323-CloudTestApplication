using CloudTestApplication.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTestApplication.Services
{
    public class DataServices : IDataServices
    {

        public string connectionString = "datasource=remotemysql.com;username=hHOQMOQDTD;password=f3HJJN4I3c;database=hHOQMOQDTD;";

        public bool addData(Data data)
        {
            bool success = false;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string sqlStatement = "INSERT INTO hHOQMOQDTD.Data(Name, Amount, Description) VALUES(?Name,?Amount,?Description)";
            MySqlCommand command = con.CreateCommand();
            command.CommandText = sqlStatement;
            command.Parameters.Add("?Name", MySqlDbType.Text).Value = data.Name;
            command.Parameters.Add("?Amount", MySqlDbType.Int32).Value = data.Amount;
            command.Parameters.Add("?Description", MySqlDbType.Text).Value = data.Description;
            success = (command.ExecuteNonQuery() == 1);
            con.Close();
            return success;
        }

        public void deleteData(Data data)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string sqlStatement = "DELETE FROM hHOQMOQDTD.Data WHERE ID = @ID";
            MySqlCommand command = con.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sqlStatement;
            command.Parameters.AddWithValue("@ID", data.ID);
            command.ExecuteNonQuery();
            con.Close();

        }

        public void editData(Data data)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string sqlStatement = "UPDATE hHOQMOQDTD.Data SET Description = @Description WHERE ID = @ID";
            MySqlCommand command = con.CreateCommand();
            command.CommandText = sqlStatement;
            command.Parameters.AddWithValue("@ID", data.ID);
            command.Parameters.AddWithValue("@Description", data.Description);
            command.ExecuteScalar();
            con.Close();
        }

        public List<Data> findAllData()
        {
            List<Data> foundData = new List<Data>();
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlCommand command = con.CreateCommand();
            string sqlStatement = "SELECT * FROM hHOQMOQDTD.Data";
            command.CommandText = sqlStatement;
            MySqlDataReader rs = command.ExecuteReader();
            while (rs.Read())
            {
                foundData.Add(new Data { ID = (int)rs[0], Name = (string)rs[1], Amount = (int)rs[2], Description = (string)rs[3] });
            }
            con.Close();
            return foundData;
           
        }
    }
}
