using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.Core.Models;

public class BankAccount
{
    public int BankAccountId;
    public int TenantId;

    private string _registrationNumber;

    public string RegistrationNumber
    {
        get => _registrationNumber;
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && int.TryParse(value, out _))
            {
                _registrationNumber = value;
            }
            else
            {
                throw new ArgumentException("Invalid registration number");
            }
        }
    }

    private string _accountNumber;

    public string AccountNumber
    {
        get => _accountNumber;
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && int.TryParse(value, out _))
            {
                _accountNumber = value;
            }
            else
            {
                throw new ArgumentException("Invalid account number");
            }
        }
    }

    public BankAccount(string registrationNumber,
                       string accountNumber)
    {
        RegistrationNumber = registrationNumber;
        AccountNumber = accountNumber;
    }
}