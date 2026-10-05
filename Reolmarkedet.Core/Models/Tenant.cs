namespace Reolmarkedet.Core.Models;

public class Tenant
{
    public int TenantId;
    
    private string _firstName;

    public string FirstName
    {
        get => _name;
    }
    
    
    private string _email;

    public string Email
    {
        get => _email;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _firstName = value;
            }
            else
            {
                throw new ArgumentException("First name cannot be empty");
            }
        }
    }


    private string _lastName;
    public string LastName
    {
        get => _lastName;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _lastName = value;
            }
            else
            {
                throw new ArgumentException("Last name cannot be empty");
            }
        }
    }
    
    
    private string? _regNumber;

    public string RegNumber
    {
        get => _regNumber;
        set {
            // Check to see if its actually a number
            if (int.TryParse(value, out int result))
            {
                _regNumber = value;
            }
            else
            {
                throw new ArgumentException("Invalid registration number");
            }
        }
    }
    
    
    private string? _bankNumber;

    public string BankNumber
    {
        get => _bankNumber;
        set {
            // Check to see if its actually a number
            if (int.TryParse(value, out int result))
            {
                _bankNumber = value;
            }
            else
            {
                throw new ArgumentException("Invalid bank number");
            }
        }
    }

    public Tenant(string name, string email, string phone, string regNumber, string bankNumber)
    {
        _name = name;
        Email = email;
        Phone = phone;
        _regNumber = regNumber;
        _bankNumber = bankNumber;
    }

    public Tenant(string name, string email, string phone)
    {
        _name = name;
        Email = email;
        Phone = phone;
    }
}