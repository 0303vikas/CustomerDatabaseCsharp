using System;
namespace src.Customer;

public class CustomerDatabase
{
    private Dictionary<int, Customer> _customers;
    private int _id = 1;
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

    public void AddCustomer(string firstName, string lastName, string email, string address)
    {
        _ = firstName ?? throw new ArgumentNullException($"{nameof(firstName)} cann't be empty"); // doesn't provide any memory allocation. Compare and destroy
        _ = lastName ?? throw new ArgumentNullException($"{nameof(lastName)} cann't be empty");
        _ = email ?? throw new ArgumentNullException($"{nameof(email)} cann't be empty");
        _ = address ?? throw new ArgumentNullException($"{nameof(address)} cann't be empty");

        int newId = _customers.Count == 0 ? 1 : _customers.Count + 1;
        Customer newCustomer = new Customer(newId, firstName, lastName, email, address);

        foreach (Customer customer in _customers.Values)
        {
            if (customer.Equals(newCustomer))
            {
                throw new InvalidOperationException($"Customer with  email: {newCustomer.Email} already exist in database.");
            }
        }
        _customers.Add(newId, newCustomer);
        Console.WriteLine("Customer Successfully Added.");

    }
    // Reading
    // Updating
    // Deleting













}