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

        
        public Tenant? Get(int tenantID)
        {
            //vi har ikke tilføjet tenantID til klassen Tenant endnu 
            return _tenants.Find(t => t.ID == tenantID);
        }

        public Tenant? Get(string searchTerm)
        {
            //vi har ikke tilføjet tenantID til klassen Tenant endnu 
            return new Tenant("","","");
        }
        
        public List<Tenant> GetAll()
        {   //Skal tilføje firstname og last name til Tenant klassen, så vi kan sortere på det.
            //LINQ er blevet brugt - da vi vil koble db 
            return new List<Tenant>(_tenants);
        }

        public void AddTenant(Tenant tenant)
        {   
            tenant.ID = _nextId++;
            _tenants.Add(tenant);
        }

        public void UpdateTenant(Tenant tenant)
        {
            var existingTenant = Get(tenant.ID);
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
            var existingTenant =  Get(tenantID);
            if (existingTenant != null)
                _tenants.Remove(existingTenant);
            
        }

    }
}
