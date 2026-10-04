using Reolmarkedet.Core.Interfaces;
using Reolmarkedet.Core.Models;
using System.Collections.Generic;

namespace Reolmarkedet.Core.Repositories
{
    public class InMemoryBankAccountRepository : IBankAccountRepository
    {
        private readonly List<BankAccount> _bankAccounts = new List<BankAccount>();
        private int _nextId = 1;

        public BankAccount? GetById(int bankAccountId)
        {
            return _bankAccounts.Find(b => b.BankAccountId == bankAccountId);
        }

        public BankAccount? GetByTenantId(int tenantId)
        {
            return _bankAccounts.Find(b => b.TenantId == tenantId);
        }

        public List<BankAccount> GetAll()
        {
            return new List<BankAccount>(_bankAccounts).ToList();
        }

        public int Insert(BankAccount bankAccount)
        {
            bankAccount.BankAccountId = _nextId++;
            _bankAccounts.Add(bankAccount);
            return bankAccount.BankAccountId;
        }

        public void Update(BankAccount bankAccount)
        {
            var existing = GetById(bankAccount.BankAccountId);
            if (existing != null)
            {
                existing.RegistrationNumber = bankAccount.RegistrationNumber;
                existing.AccountNumber = bankAccount.AccountNumber;
            }
        }

        public void Delete(int bankAccountId)
        {
            var existing = GetById(bankAccountId);
            if (existing != null)
            {
                _bankAccounts.Remove(existing);
            }
        }
    }
}