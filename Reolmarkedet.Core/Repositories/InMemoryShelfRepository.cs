using Reolmarkedet.Core.Interfaces;
using Reolmarkedet.Core.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.Core.Repositories
{
    public class InMemoryShelfRepository : IShelfRepository
    {
        private List<Shelf> _shelves = new List<Shelf>();
        private int _nextId = 1;

        public Shelf? GetById(int shelfID)
        {
            return _shelves.Find(s => s.ShelfId == shelfID);
        }

        public List<Shelf> GetAll()
        {
            return _shelves
                .OrderBy(s => s.ShelfName)
                .ThenBy(s => s.ShelfType.Name)
                .ToList();
        }

        public List<Shelf> Search(string searchTerm)
        {
            return _shelves.Where(s =>
                                  s.ShelfName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                  s.ShelfType.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        } // Omskrevet søgefunktion, men har vi behov for den? Vi har jo allerede GetById og GetAll, så vi kan jo bare filtrere derfra.

        public int Insert(Shelf shelf)
        {
            shelf.ShelfId = _nextId++;
            _shelves.Add(shelf);
            return shelf.ShelfId;
        }

        public void Update(Shelf shelf)
        {
            var existingShelf = _shelves.Find(s => s.ShelfId == shelf.ShelfId);
            if (existingShelf != null)
            {
                existingShelf.ShelfName = shelf.ShelfName;
                existingShelf.ShelfType = shelf.ShelfType;
                existingShelf.Status = shelf.Status;
            }
        }

        public void Delete(int shelfID)
        {
            var existingShelf = GetById(shelfID);
            if (existingShelf != null)
            {
                _shelves.Remove(existingShelf);
            }
        }

    }
}