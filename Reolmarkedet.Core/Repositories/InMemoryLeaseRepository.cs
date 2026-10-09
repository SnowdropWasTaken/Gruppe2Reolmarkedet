using Reolmarkedet.Core.Interfaces;
using Reolmarkedet.Core.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.Core.Repositories
{
    public class InMemoryLeaseRepository : ILeaseRepository
    {
        private readonly List<Lease> _leases = new List<Lease>();
        private int _nextId = 1;

        public Lease? GetById(int leaseID)
        {
            return _leases.Find(l => l.LeaseId == leaseID);
        }

        public List<Lease> Search(string searchTerm)
        {
            return _leases.Where(l =>
                l.Tenant.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || // Sørger for at 'Per' og 'per' bliver fundet, ved at ignorere case-sensitivitet.
                l.Tenant.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                l.Shelf.ShelfName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        public List<Lease> GetAll()
        {
            return new List<Lease>(_leases).ToList();
        }

        public int Insert(Lease lease)
        {
            lease.LeaseId = _nextId++;
            _leases.Add(lease);
            return lease.LeaseId;
        }

        public void Update(Lease lease)
        {
            var existingLease = GetById(lease.LeaseId);
            if (existingLease != null)
            {
                existingLease.StartDate = lease.StartDate;
                existingLease.TerminationDate = lease.TerminationDate;
            }
        }

        public void Delete(int leaseId)
        {
            var lease = GetById(leaseId);   // Find the lease by ID
            if (lease != null)              // Hvis der er et match slettes lease 
            {
                _leases.Remove(lease);
            }
        }

    }
}