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
            return _tenants.Find(t => t.TenantId == tenantID);
        }

        public Tenant? GetByPhone(string phone)
        {
            return _tenants.Find(t => t.Phone == phone);
        }

        public List<Tenant>? Search(string searchTerm)
        {
            return new List<Tenant>(_tenants.Where(t => t.FirstName.Contains(searchTerm) || t.LastName.Contains(searchTerm))).ToList();
        }
        
        public List<Tenant> GetAll()
        {   //Skal tilføje firstname og last name til Tenant klassen, så vi kan sortere på det.
            //LINQ er blevet brugt - da vi vil koble db 
            return new List<Tenant>(_tenants).ToList();
        }

        public int Insert(Tenant tenant)
        {   
            tenant.TenantId = _nextId++;
            _tenants.Add(tenant);
            return tenant.TenantId;
        }

        public void Update(Tenant tenant)
        {
            var existingTenant = GetById(tenant.TenantId);
            if (existingTenant != null) {
                existingTenant.FirstName = tenant.FirstName;
                existingTenant.LastName = tenant.LastName;
                existingTenant.Email = tenant.Email;
                existingTenant.Phone = tenant.Phone;

            }
        }
        public void Delete(int tenantID)
        {
            var existingTenant =  GetById(tenantID);
            if (existingTenant != null)
                _tenants.Remove(existingTenant);
            
        }

    }
}
