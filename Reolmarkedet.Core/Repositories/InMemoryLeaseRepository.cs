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


        public Lease GetById(int leaseId)
        {
            throw new NotImplementedException();
        }

        public List<Lease> GetAll()
        {
            throw new NotImplementedException();
        }

        public void AddLease(Lease lease)
        {
            throw new NotImplementedException();
        }

        public void RemoveLease(int leaseId)
        {
            throw new NotImplementedException();
        }

        public void UpdateLease(Lease lease)
        {
            throw new NotImplementedException();
        }
    }
}
