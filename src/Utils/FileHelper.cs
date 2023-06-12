using System.IO;
using System;
namespace src.Utils;

public class FileHelper
{
    public static List<Customer.Customer> GetAllCustomers(string path)
    {
        try
        {
            List<Customer.Customer> customerList = new List<Customer.Customer>();
            using (var databaseReader = new StreamReader(path))
            {
                if (databaseReader != null)
                {
                    string oneCustomer;
                    while ((oneCustomer = databaseReader.ReadLine()) != null)
                    {
                        string[] customerData = oneCustomer.Split(",");
                        if (customerData.Length > 5)
                        {
                            Customer.Customer customer = new Customer.Customer(Int32.Parse(customerData[0]), customerData[1], customerData[2], customerData[3], customerData[4]);
                            customerList.Add(customer);
                        }
                    }
                }
            }
            Console.WriteLine("Customers read from file successfully");
            return customerList;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public static void AddNewCustomer(string path, Customer.Customer customer)
    {
        try
        {
            using (var databaseWriter = new StreamWriter(path, true))
            {
                databaseWriter.WriteLine($"{customer.Id},{customer.FirstName},{customer.Lastname},{customer.Email},{customer.Address}");
            }
            Console.WriteLine("Customers added to file successfully");
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public static void UpdateCustomerData(string path, string type, List<Customer.Customer> customers)
    {
        try
        {
            using (var databaseWriter = new StreamWriter(path))
            {
                foreach (Customer.Customer customer in customers)
                {
                    databaseWriter.WriteLine($"{customer.Id},{customer.FirstName},{customer.Lastname},{customer.Email},{customer.Address}");
                }
            }
            Console.WriteLine($"Customers {type} to file successfully");
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
