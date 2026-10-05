using Reolmarkedet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.Core.Interfaces
{
    public interface ILeaseRepository
    {
<<<<<<< HEAD
<<<<<<< HEAD
        Lease? Get (int ID);
        Lease? Get (string searchTerm);
        List<Lease> GetAll();
        void AddLease(Lease lease);
        void UpdateLease(Lease lease);
        void RemoveLease(int leaseID);
=======
        Lease? GetById(int leaseId);
        List<Lease> GetAll();
        int Insert(Lease lease);
        void Update(Lease lease);
        void Delete(int leaseId);
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
=======
        Lease? GetById(int leaseId);
        List<Lease> GetAll();
        int Insert(Lease lease);
        void Update(Lease lease);
        void Delete(int leaseId);
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d


    }
}
