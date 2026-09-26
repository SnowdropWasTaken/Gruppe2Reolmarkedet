using Reolmarkedet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.Core.Interfaces
{
    public interface ILeaseRepository
    {
        Lease GetById(int leaseId);
        List<Lease> GetAll();
        void AddLease(Lease lease);
        void UpdateLease(Lease lease);
        void RemoveLease(int leaseId);


    }
}
