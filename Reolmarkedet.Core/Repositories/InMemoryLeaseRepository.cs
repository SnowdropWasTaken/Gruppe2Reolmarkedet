using Reolmarkedet.Core.Interfaces;
using Reolmarkedet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.Core.Repositories
{
    public class InMemoryLeaseRepository : ILeaseRepository
    {
        private readonly List<Lease> _leases = new List<Lease>();
        private int _nextId = 1;


        public Lease GetById(int leaseID)
        {
            return _leases.Find(l => l.LeaseID == leaseID);
        }

        public List<Lease> GetAll()
        {
            return new List<Lease>(_leases);
                  
        }

        public void AddLease(Lease lease)
        {
            lease.LeaseID = _nextId++;
            _leases.Add(lease);
        }

        public void UpdateLease(Lease lease)
        {
            var existingLease = GetById(lease.LeaseID);
            if (existingLease != null)
            {
                existingLease.TenantID = lease.TenantID;
                existingLease.ShelfID = lease.ShelfID;
                existingLease.StartDate = lease.StartDate;
                existingLease.EndDate = lease.EndDate;
            }
        }

        public void RemoveLease(int leaseId)
        {
            var lease = GetById(leaseId);   // Find the lease by ID
            if (lease != null)              // Hvis der er et match slettes lease 
            {
                _leases.Remove(lease);
            }
        }


    }
}
