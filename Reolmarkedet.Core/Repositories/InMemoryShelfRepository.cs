using Reolmarkedet.Core.Interfaces;
using Reolmarkedet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.Core.Repositories
{
    internal class InMemoryShelfRepository : IShelfRepository
    {
        public Shelf GetById(int shelfId)
        {
            throw new NotImplementedException();
        }

        public List<Shelf> GetAll()
        {
            throw new NotImplementedException();
        }

        public void AddShelf(Shelf shelf)
        {
            throw new NotImplementedException();
        }

        public void UpdateShelf(Shelf shelf)
        {
            throw new NotImplementedException();
        }

        public void RemoveShelf(int shelfID)
        {
            throw new NotImplementedException();
        }

    }
}
