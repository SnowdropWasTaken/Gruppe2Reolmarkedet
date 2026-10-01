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
        void AddShelf(Shelf shelf);
        void UpdateShelf(Shelf shelf);
        void RemoveShelf(int shelfID);

    }
}
