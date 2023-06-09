using System;
namespace src.Customer;

public class Customer
{
    private int _id;
    private string _firstName { get; set; }
    private string _lastName { get; set; }
    private string _email;
    private string _address { get; set; }

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    public Customer(int id, string firstName, string lastName, string email, string address)
    {
        _id = id;
        _firstName = firstName;
        _lastName = lastName;
        _email = email;
        _address = address;
    }

    public void ChangeFirstname(string newFirstName)
    {
        if (newFirstName is not null)
        {
            _firstName = newFirstName;
        }
        else
        {
            throw new Exception("User FirstName Cann't be empty");
        }
    }

    public void ChangeLastName(string newLastname)
    {
        if (newLastname is not null)
        {
            _lastName = newLastname;
        }
        else
        {
            throw new Exception("User LastName Cann't be empty");
        }
    }

    public void ChangeEmail(string newEmail)
    {
        if (newEmail is not null)
        {
            _lastName = newEmail;
        }
        else
        {
            throw new Exception("User Email Cann't be empty");
        }
    }

    public void ChangeAddress(string newAddress)
    {
        if (newAddress is not null)
        {
            _address = newAddress;
        }
        else
        {
            throw new Exception("User Address Cann't be empty");
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType()) return false;
        Customer otherCustomer = (Customer)obj;
        if (_email == otherCustomer.Email && _id == otherCustomer.Id) return true;
        return false;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        return (hash * 23) + _email.GetHashCode();
    }
}
