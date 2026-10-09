namespace Reolmarkedet.Core.Models;

public class Tenant
{
    public int TenantId;

    //  Tilføjer en firstname property til Tenant klassen, så vi kan gemme fornavn.
    private string _firstName;
    public string FirstName
    {
        get => _firstName;
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

    // Tilføjer en lastName property til Tenant klassen, så vi kan gemme efternavn.
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

    // Tilføjer en email property til Tenant klassen, så vi kan gemme email.
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

    // Tilføjer en phone property til Tenant klassen, så vi kan gemme telefonnummer.
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


    // Constructor for nye lejere, der skal på venteliste - hvorfor vi ikke har deres bankoplysninger endnu.
    public Tenant(string firstname, string lastname, string email, string phone)
    {
        _firstName = firstname;
        _lastName = lastname;
        Email = email;
        Phone = phone;
    }

    // Constructor for nye aktive lejere, hvor bankoplysninger gives samtidig, og derfor kan oprettes ved samme lejlighed.
    public Tenant(string firstname, string lastname, string email, string phone, BankAccount bankAccount)
    : this(firstname, lastname, email, phone)
    {
        BankAccount = bankAccount;
    }
}