using Reolmarkedet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.Core.Interfaces
{
    public interface IShelfRepository
    {

        Shelf GetById(int shelfID);
        List<Shelf> GetAll();
        int Insert(Shelf shelf);
        void Update(Shelf shelf);
        void Delete(int shelfID);

    }
}
