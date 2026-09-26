using Reolmarkedet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.Core.Interfaces
{
    public interface ITenantRepository
    {
        Tenant? GetById(int tenantID);
        
        List<Tenant> GetAll();
        
        void AddTenant(Tenant tenant);

        void UpdateTenant(Tenant tenant);

        void RemoveTenant(int tenantID);
    }   
}
