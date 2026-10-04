using Reolmarkedet.Core.Models;
using System.Collections.Generic;

namespace Reolmarkedet.Core.Interfaces
{
    public interface IBankAccountRepository
    {
        BankAccount? GetById(int bankAccountId);
        BankAccount? GetByTenantId(int tenantId);
        List<BankAccount> GetAll();
        int Insert(BankAccount bankAccount);
        void Update(BankAccount bankAccount);
        void Delete(int bankAccountId);
    }
}
