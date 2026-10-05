namespace Reolmarkedet.Core.Models;

public class Tenant
{
    public int TenantId;
    
    private string _firstName;

    public string FirstName
    {
        get => _firstName;
<<<<<<< HEAD
        set => _firstName = value;
    }
    private string _lastName;

    public string LastName
    {
        get => _lastName;
        set => _lastName = value;
    }

=======
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


>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
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


    // Tilføjer en bankkonto til Tenant klassen, så vi kan gemme reg og bank nummer.
    public BankAccount? BankAccount { get; set; }

<<<<<<< HEAD
    public Tenant(string firstName, String lastName, string email, string phone, string regNumber, string bankNumber)
    {
        _firstName = firstName;
        _lastName = lastName;
        Email = email;
        Phone = phone;
        _regNumber = regNumber;
        _bankNumber = bankNumber;
    }

    public Tenant(string firstName, string lastName, string email, string phone)
    {
        _firstName = firstName;
        _lastName= lastName;
=======
    //private string? _regNumber;

    //public string RegNumber
    //{
    //    get => _regNumber;
    //    set {
    //        // Check to see if its actually a number
    //        if (int.TryParse(value, out int result))
    //        {
    //            _regNumber = value;
    //        }
    //        else
    //        {
    //            throw new ArgumentException("Invalid registration number");
    //        }
    //    }
    //}


    //private string? _bankNumber;

    //public string BankNumber
    //{
    //    get => _bankNumber;
    //    set {
    //        // Check to see if its actually a number
    //        if (int.TryParse(value, out int result))
    //        {
    //            _bankNumber = value;
    //        }
    //        else
    //        {
    //            throw new ArgumentException("Invalid bank number");
    //        }
    //    }
    //}

    //public Tenant(string firstname, string lastname, string email, string phone, string regNumber, string bankNumber)
    //{
    //    _firstName = firstname;
    //    _lastName = lastname;
    //    Email = email;
    //    Phone = phone;
    //    _regNumber = regNumber;
    //    _bankNumber = bankNumber;
    //}

    public Tenant(string firstname, string lastname, string email, string phone)
    {
        _firstName = firstname;
        _lastName = lastname;
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
        Email = email;
        Phone = phone;
    }
}