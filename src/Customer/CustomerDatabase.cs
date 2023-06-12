using System;
using System.Text;
using src.Utils;
namespace src.Customer;

public class CustomerDatabase
{
    private List<Customer> _customers;
    private static CustomerDatabase _instance;
    private static readonly object _lockObject = new Object();
    private Stack<Customer> _undoStack;
    private Stack<Customer> _redoStack;

    public string filePath = "src/customers.csv";

    private CustomerDatabase()
    {
        _customers = FileHelper.GetAllCustomers(filePath);
        _undoStack = new Stack<Customer>();
        _redoStack = new Stack<Customer>();
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
        foreach (Customer customer in _customers)
        {
            if (customer.Equals(newCustomer))
            {
                throw new InvalidOperationException("Email and Id should be unique.");
            }
        }
        _customers.Add(newCustomer);
        FileHelper.AddNewCustomer(filePath, newCustomer);
        _undoStack.Push(newCustomer);
        _redoStack.Clear();
        Console.WriteLine("Customer Successfully Added.");
    }
    // Reading
    public Customer GetCustomerById(int id)
    {
        ArgumentNullException.ThrowIfNull(id);
        Customer? findCustomer = _customers.Find(item => item.Id == id);
        if (findCustomer != null) return _customers[id];
        else throw new Exception($"Customer with id: {id} doesn't exist in database");
    }
    // Updating
    public void UpdateCustomer(Customer updatedCustomer)
    {
        ArgumentNullException.ThrowIfNull(updatedCustomer);
        Customer? findCustomer = _customers.Find(item => item.Id == updatedCustomer.Id);
        if (findCustomer != null)
        {
            Customer oldCustomer = _customers[updatedCustomer.Id];
            _customers[updatedCustomer.Id] = updatedCustomer;
            FileHelper.UpdateCustomerData(filePath, "Update", _customers);
            _undoStack.Push(oldCustomer);
            _redoStack.Clear();
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
        Customer? findCustomer = _customers.Find(item => item.Id == id);
        if (findCustomer != null)
        {
            _customers.Remove(findCustomer);
            FileHelper.UpdateCustomerData(filePath, "Delete", _customers);
            _undoStack.Push(findCustomer);
            _redoStack.Clear();
            Console.WriteLine("Customer Successfully Deleted.");
        }
        else
        {
            throw new Exception("Deletion Exception: No user with this id found in the Database.");
        }
    }

    public void UndoAction(Customer customer)
    {
        if (_undoStack.Count > 0)
        {
            Customer oldCustomer = _undoStack.Pop();
            _redoStack.Push(oldCustomer);
            Customer? findCustomer = _customers.Find(customer => customer.Id == oldCustomer.Id);
            if (findCustomer != null)
            {
                _customers.Remove(findCustomer);
            }
            else
            {
                _customers.Add(oldCustomer);
            }
            FileHelper.UpdateCustomerData(filePath, "Update", _customers);
        }
    }

    public void RedoAction()
    {
        if (_redoStack.Count > 0)
        {
            Customer oldCustomer = _redoStack.Pop();
            _undoStack.Push(oldCustomer);
            Customer? findCustomer = _customers.Find(customer => customer.Id == oldCustomer.Id);
            if (findCustomer != null)
            {
                _customers.Remove(findCustomer);
            }
            else
            {
                _customers.Add(oldCustomer);
            }
            FileHelper.UpdateCustomerData(filePath, "Update", _customers);
        }
    }

    public override string ToString()
    {
        StringBuilder databaseState = new StringBuilder("Customer Database: \n");
        foreach (Customer customer in _customers)
        {
            databaseState.Append($"Id : {customer.Id}\n First Name: {customer.FirstName}\n Last Name: {customer.Lastname}\n Email: {customer.Email}\n Address: {customer.Address}");
        }
        return databaseState.ToString();
    }
}