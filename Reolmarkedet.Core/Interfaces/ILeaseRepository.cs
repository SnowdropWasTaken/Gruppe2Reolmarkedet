using Reolmarkedet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.Core.Interfaces
{
    public interface ILeaseRepository
    {
        Lease? GetById(int leaseId);
        List<Lease> GetAll();
        int Insert(Lease lease);
        void Update(Lease lease);
        void Delete(int leaseId);


    }
}