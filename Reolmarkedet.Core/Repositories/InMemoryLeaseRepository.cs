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

<<<<<<< HEAD
<<<<<<< HEAD
        public Lease? Get (int leaseID)
        {
            return _leases.Find(l => l.ID == leaseID); 
        }
        public Lease? Get (string searchTerm)
        {
             return _leases.Find(l => 
             l.Tenant.FirstName == searchTerm ||
             l.Shelf.ShelfName == searchTerm);    
=======

        public Lease? GetById(int leaseID)
        {
            return _leases.Find(l => l.LeaseID == leaseID);
        }

        public List<Lease> GetAll()
        {
            return new List<Lease>(_leases);
                  
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
        }

        public int Insert(Lease lease)
        {
            lease.LeaseID = _nextId++;
            _leases.Add(lease);
        }

        public void UpdateLease(Lease lease)
        {
            var existingLease = GetById(lease.LeaseID);
            if (existingLease != null)
            {
                existingLease.StartDate = lease.StartDate;
                existingLease.TerminationDate = lease.TerminationDate;
            }
        }

        public void RemoveLease(int leaseId)
        {
            var lease = Get(leaseID);   
            if (lease != null)           
            {
                _leases.Remove(lease);
            }
        }

    }
}
