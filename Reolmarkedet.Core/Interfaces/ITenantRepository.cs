using Reolmarkedet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.Core.Interfaces
{
    //public interface ITenantRepository
    //{
    //    Tenant? Get(int tenantID);
    //    Tenant? Get(string searchTerm);
        
    //    List<Tenant> GetAll();
        
    //    void AddTenant(Tenant tenant);

    //    void UpdateTenant(Tenant tenant);

    //    void RemoveTenant(int tenantID);
    //}

    public interface ITenantRepository
    {
        Tenant? Get(int tenantID);
        Tenant? Get(string searchTerm);
        
        List<Tenant> GetAll();

        int Insert(Tenant tenant);
        void Update(Tenant tenant);
        void Delete(int tenantID);
    }
}
