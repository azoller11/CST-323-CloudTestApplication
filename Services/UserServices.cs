using CloudTestApplication.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTestApplication.Services
{
    public class UserServices : IUserServices
    {
        public string connectionString = "datasource=remotemysql.com;username=hHOQMOQDTD;password=f3HJJN4I3c;database=hHOQMOQDTD;";

        public bool isValid(User user)
        {
            bool success = false;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            MySqlCommand command = con.CreateCommand();
            string sqlStatement = "SELECT * FROM hHOQMOQDTD.User WHERE Username = @Username AND Password = @Password";
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sqlStatement;
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Password", user.Password);
            MySqlDataReader rs = command.ExecuteReader();
            if (rs.HasRows)
            {
                success = true;
            }
            con.Close();
            return success;
        }

        public bool registerUser(User user)
        {
            bool success = false;
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string sqlStatement = "INSERT INTO hHOQMOQDTD.User (Username, Password) SELECT ?Username, ?Password FROM DUAL WHERE NOT EXISTS (SELECT * FROM User WHERE Username= ?Username AND Password= ?Password LIMIT 1)";
            MySqlCommand command = con.CreateCommand();
            command.CommandText = sqlStatement;
            command.Parameters.Add("?Username", MySqlDbType.Text).Value = user.Username;
            command.Parameters.Add("?Password", MySqlDbType.Text).Value = user.Password;
            success = (command.ExecuteNonQuery() == 1);
            con.Close();
            return success;
        }
    }
}
