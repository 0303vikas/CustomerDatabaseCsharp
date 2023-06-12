using System;
using src.Customer;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // creating new customers
            Customer customer1 = new Customer(1, "vikas", "singh", "2751vikas@mail.com", "bakers street 212");
            Customer customer2 = new Customer(2, "vikas", "singh", "vikas@mail.com", "bakers street 212");
            Customer customer3 = new Customer(1, "King", "Billi", "2751vikas@mail.com", "bakers street 212"); //for updating
            Customer customer4 = new Customer(4, "vikas", "singh", "Singh@mail.com", "bakers street 212");

            // Single Instance
            CustomerDatabase customerDatabase = CustomerDatabase.Instance();

            // Pre printing state of customer database
            Console.WriteLine(customerDatabase.ToString());

            //adding new customers
            customerDatabase.AddCustomer(customer1);
            customerDatabase.AddCustomer(customer2);
            customerDatabase.AddCustomer(customer4);

            // deleting from data
            customerDatabase.DeleteCustomer(customer1.Id);

            // updating customer data
            customerDatabase.UpdateCustomer(customer3);

            //undo the action
            customerDatabase.UndoAction();

            //redo the last action
            customerDatabase.RedoAction();
        }
    }
}