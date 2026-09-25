namespace Reolmarkedet.Core.Models;

public class Tenant
{
    private string _name;

    public string Name
    {
        get => _name;
    }
    
    
    private string _email;

    public string Email
    {
        get => _email;
        set
        {
            if (value != null && value.Contains("@") && value.Contains("."))
            {
                // Removes all whitespace from the string
                _email = String.Concat(value.Where(c => !Char.IsWhiteSpace(c)));
            }
            else
            {
                throw new ArgumentException("Invalid email address");
            }
        }
    }
    
    
    private string _phone;

    public string Phone
    {
        get => _phone;
        set
        {
            if (value != null && value.Length > 7)
            {
                // Removes all whitespace from the string
                _phone = String.Concat(value.Where(c => !Char.IsWhiteSpace(c)));
            }
            else
            {
                throw new ArgumentException("Invalid phone number");
            }
        }
    }
    
    
    private string _regNumber;

    public string RegNumber
    {
        get => _regNumber;
    }
    
    
    private string _bankNumber;

    public string BankNumber
    {
        get => _bankNumber;
    }
    
    
    private List<Lease> _leases = new List<Lease>();

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

    public void AddLease(Lease lease)
    {
        _leases.Add(lease);
    }

    public void RemoveLease(Lease lease)
    {
        _leases.Remove(lease);
    }

    public IEnumerable<Lease> Leases()
    {
        return new List<Lease>(_leases);
    }
}