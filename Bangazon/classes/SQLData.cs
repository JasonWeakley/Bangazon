using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon.classes
{
    public class SQLData
    {
        private SqlConnection _SQLconnector = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
           "\"C:\\Users\\Jason\\Documents\\Visual Studio 2015\\Projects\\Bangazon\\Bangazon\\Bangazon.mdf\"; Integrated Security=True");

        public void CreateCustomer(Customer customer)
        {
            string sqlCommand = string.Format("INSERT INTO Customer (FirstName, LastName, StreetAddress, City, StateProvince, PostalCode, PhoneNumber) " +
               "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", customer.FirstName, customer.LastName, customer.StreetAddress,
               customer.City, customer.StateProvince, customer.PostalCode, customer.PhoneNumber);
            // pass in string to send to database
            UpdateDatabase(sqlCommand);
        }

        public void UpdateDatabase(string sqlCommand)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sqlCommand; // this is the string created in CreateCustomer method above
            cmd.Connection = _SQLconnector;

            _SQLconnector.Open();
            cmd.ExecuteNonQuery();
            _SQLconnector.Close();
        }
    }
}
