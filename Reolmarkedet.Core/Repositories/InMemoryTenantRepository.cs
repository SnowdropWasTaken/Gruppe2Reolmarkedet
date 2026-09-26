using Reolmarkedet.Core.Interfaces;
using Reolmarkedet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.Core.Repositories
{
    internal class InMemoryTenantRepository : ITenantRepository
    {
        private List<Tenant> _tenants = new List<Tenant>();
        private int _nextId = 1;

        public Tenant? GetById(int tenantID)
        {
            //vi har ikke tilføjet tenantID endnu - hvis ikke skal der rettes i ITenantRepository GetById.
            return _tenants.Find(t => t.TenantID == tenantID);
        }

        public List<Tenant> GetAll()
        {   //Skal tilføje firstname og last name til Tenant klassen, så vi kan sortere på det.
            //LINQ er blevet brugt - da vi vil koble db 
            return _tenants
            .OrderBy(t => t.LastName)
            .ThenBy(t => t.FirstName)
            .ToList();
        }

        public void AddTenant(Tenant tenant)
        {
            tenant.TenantID = _nextId++;
        }
        public void UpdateTenant(Tenant tenant)
        {
            var existingTenant = GetById(tenant.TenantID);
            if (existingTenant != null) {
                existingTenant.FirstName = tenant.FirstName;
                existingTenant.LastName = tenant.LastName;
                existingTenant.Email = tenant.Email;
                existingTenant.Phone = tenant.Phone;    
                existingTenant.RegNumber = tenant.RegNumber;
                existingTenant.BankNumber = tenant.BankNumber;

            }
        }
        public void RemoveTenant(int tenantID)
        {
            var existingTenant = GetById(tenantID);
            if (existingTenant != null)
                _tenants.Remove(existingTenant);
            
        }

    }
}
