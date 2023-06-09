using System;
namespace src.Customer;

public class CustomerDatabase
{
    private Dictionary<int, Customer> _customers;
    private static CustomerDatabase _instance;
    private static readonly object _lockObject = new Object();

    private CustomerDatabase()
    {
        _customers = new Dictionary<int, Customer>();
    }

    public static CustomerDatabase Instance()
    {
        if (_instance == null)
        {
            lock (_lockObject)
            {
                _instance = new CustomerDatabase();
            }
        }
        return _instance;
    }

    public void AddCustomer(Customer newCustomer)
    {
        foreach (Customer customer in _customers.Values)
        {
            if (customer.Equals(newCustomer))
            {
                throw new InvalidOperationException("Email and Id should be unique.");
            }
        }
        _customers.Add(newCustomer.Id, newCustomer);
        Console.WriteLine("Customer Successfully Added.");
    }
    // Reading
    public Customer GetCustomerById(int id)
    {
        ArgumentNullException.ThrowIfNull(id);
        if (_customers.ContainsKey(id)) return _customers[id];
        else throw new Exception($"Customer with id: {id} doesn't exist in database");
    }
    // Updating
    public void UpdateCustomer(Customer updatedCustomer)
    {
        ArgumentNullException.ThrowIfNull(updatedCustomer);
        if (_customers.ContainsKey(updatedCustomer.Id))
        {
            _customers[updatedCustomer.Id] = updatedCustomer;
            Console.WriteLine("User Succesfully Updated.");
        }
        else
        {
            throw new Exception("Update Exception: No user with this id found in the Database.");
        }
    }
    // Deleting
    public void DeleteCustomer(int id)
    {
        ArgumentNullException.ThrowIfNull(id);
        if (_customers.ContainsKey(id))
        {
            _customers.Remove(id);
            Console.WriteLine("Customer Successfully Deleted.");
        }
        else
        {
            throw new Exception("Deletion Exception: No user with this id found in the Database.");
        }
    }













}