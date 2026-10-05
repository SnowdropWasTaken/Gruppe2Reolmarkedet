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
            return _leases.Find(l => l.LeaseId == leaseID);
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
=======

        public Lease? GetById(int leaseID)
        {
            return _leases.Find(l => l.LeaseId == leaseID);
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
        }

        public List<Lease> GetAll()
        {
<<<<<<< HEAD
<<<<<<< HEAD
            return new List<Lease>(_leases);
=======
=======
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
            return new List<Lease>(_leases).ToList();
                  
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
        }

        public int Insert(Lease lease)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            lease.ID = _nextId++;
=======
            lease.LeaseId = _nextId++;
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
=======
            lease.LeaseId = _nextId++;
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
            _leases.Add(lease);
            return lease.LeaseId;
        }

        public void Update(Lease lease)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            var existingLease = Get(lease.ID);
            if (existingLease != null)
            {
                existingLease.Tenant = lease.Tenant;
                existingLease.Shelf = lease.Shelf;
                existingLease.StartDate = lease.StartDate;
                existingLease.Price = lease.Price;
                existingLease.CancellationDate = lease.CancellationDate;
            }
        }

        public void RemoveLease(int leaseID)
=======
            var existingLease = GetById(lease.LeaseId);
            if (existingLease != null)
            {
                existingLease.StartDate = lease.StartDate;
                existingLease.TerminationDate = lease.TerminationDate;
            }
        }

        public void Delete(int leaseId)
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
=======
            var existingLease = GetById(lease.LeaseId);
            if (existingLease != null)
            {
                existingLease.StartDate = lease.StartDate;
                existingLease.TerminationDate = lease.TerminationDate;
            }
        }

        public void Delete(int leaseId)
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
        {
            var lease = Get(leaseID);   
            if (lease != null)           
            {
                _leases.Remove(lease);
            }
        }

    }
}
