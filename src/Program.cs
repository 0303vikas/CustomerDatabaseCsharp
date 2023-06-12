using System;


using src.Customer;
using src.Utils;
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer(1, "vikas", "singh", "2751vikas@mail.com", "bakers street 212");
            Customer customer2 = new Customer(2, "vikas", "singh", "vikas@mail.com", "bakers street 212");
            Customer customer3 = new Customer(1, "vikas", "singh", "2751vikas@mail.com", "bakers street 212");
            Customer customer4 = new Customer(4, "vikas", "singh", "Singh@mail.com", "bakers street 212");

            CustomerDatabase customerDatabase = CustomerDatabase.Instance();
            customerDatabase.AddCustomer(customer1);
            customerDatabase.AddCustomer(customer2);
            customerDatabase.AddCustomer(customer3);
            customerDatabase.AddCustomer(customer4);

        }
    }
}