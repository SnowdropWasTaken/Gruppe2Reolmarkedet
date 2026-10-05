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
<<<<<<< HEAD
            return _tenants.Find(t => t.ID == tenantID);
=======
            return _tenants.Find(t => t.TenantId == tenantID);
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
        }

        public Tenant? GetByPhone(string phone)
        {
<<<<<<< HEAD
            if (string.IsNullOrWhiteSpace(searchTerm))
                throw new ArgumentNullException("Søgning må ikke være tom", nameof(searchTerm));
           
            return _tenants.Find(t =>
            t.FirstName == searchTerm ||
            t.LastName == searchTerm ||
            t.Email == searchTerm ||
            t.Phone == searchTerm ||
            t.RegNumber == searchTerm ||
            t.BankNumber == searchTerm); 
            
=======
            return _tenants.Find(t => t.Phone == phone);
        }

        public List<Tenant>? Search(string searchTerm)
        {
            return new List<Tenant>(_tenants.Where(t => t.FirstName.Contains(searchTerm) || t.LastName.Contains(searchTerm))).ToList();
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
        }
        
        public List<Tenant> GetAll()
        {   
            //LINQ er blevet brugt - da vi vil koble db 
            return new List<Tenant>(_tenants).ToList();
        }

        public int Insert(Tenant tenant)
        {   
<<<<<<< HEAD
            if (tenant == null)
                throw new ArgumentNullException(nameof(tenant));

            tenant.ID = _nextId++;
=======
            tenant.TenantId = _nextId++;
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
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
