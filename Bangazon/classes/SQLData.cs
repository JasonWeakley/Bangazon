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

        public List<Customer> getAllCustomers()
        {
            // the only thing this entore method does is collect the information
            // this information needs to be set equal to a variable elsewhere
            List<Customer> listOfAllCustomers = new List<Customer>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM Customer";
            cmd.Connection = _SQLconnector;

            _SQLconnector.Open();
            using (SqlDataReader DataReader = cmd.ExecuteReader())
            {
                while (DataReader.Read()) // while there is data to read in the database
                {
                    Customer customer = new Customer();
                    customer.IdCustomer = DataReader.GetInt32(0);
                    customer.FirstName = DataReader.GetString(1);
                    customer.LastName = DataReader.GetString(2);
                    customer.StreetAddress = DataReader.GetString(3);
                    customer.City = DataReader.GetString(4);
                    customer.StateProvince = DataReader.GetString(5);
                    customer.PostalCode = DataReader.GetString(6);
                    customer.PhoneNumber = DataReader.GetString(7);
                    listOfAllCustomers.Add(customer);
                }
            }
            _SQLconnector.Close();
            return listOfAllCustomers;
        }
    }
}
