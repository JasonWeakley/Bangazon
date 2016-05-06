using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon.classes
{
    public class OrderingSystem
    {
        private SQLData _newSQLdata = new SQLData();

        // constructor function
        // everytime this class is created it will run the code inside here
        public OrderingSystem()
        {
            ShowMenu();
        }
        public void ShowMenu()
        {
            Console.WriteLine("\n*********************************************************" +
                              "\n* *Welcome to Bangazon!Command Line Ordering System * *" +
                              "\n*********************************************************" +
                              "\n1.Create an account" +
                              "\n2.Create a payment option" +
                              "\n3.Order a product" +
                              "\n4.Complete an order" +
                              "\n5.See product popularity" +
                              "\n6.Leave Bangazon!");
            string userInput = Console.ReadLine();
            while (userInput != "6")
            {
                switch (userInput)
                {
                    case "1":
                        CreateAccount();
                        break;
                    //case "2":
                    //    CreatePaymentOption();
                    //    break;
                    //case "3":
                    //    OrderProducts();
                    //    break;
                    //case "4":
                    //    CompleteOrder();
                    //    break;
                    //case "5":
                    //    SeeProductPopularity();
                    //    break;
                }
                userInput = Console.ReadLine();
            }
        }


        public void CreateAccount()
        {
            Customer newCust = new Customer();
            Console.WriteLine("Please enter First Name:");
            newCust.FirstName = Console.ReadLine();
            Console.WriteLine("Please enter Last Name:");
            newCust.LastName = Console.ReadLine();
            Console.WriteLine("What is your street address?");
            newCust.StreetAddress = Console.ReadLine();
            Console.WriteLine("Your city:");
            newCust.City = Console.ReadLine();
            Console.WriteLine("State or Province name:");
            newCust.StateProvince = Console.ReadLine();
            Console.WriteLine("Postal Code:");
            newCust.PostalCode = Console.ReadLine();
            Console.WriteLine("Your phone number?");
            newCust.PhoneNumber = Console.ReadLine();
            _newSQLdata.CreateCustomer(newCust);
        }






    }
}
