using Reolmarkedet.Core.Interfaces;
using Reolmarkedet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.Core.Repositories
{
    public class InMemoryShelfRepository : IShelfRepository
    {
        private List<Shelf> _shelves = new List<Shelf>();
        private int _nextId = 1;


        public Shelf GetById(int shelfID)
        {
            //Vi har ikke tilføjet shelfID til klassen Shelf endnu.
            return _shelves.Find(s => s.shelfID == shelfID);
        }

        public List<Shelf> GetAll()
        {
            return _shelves
                .OrderBy(s => s.ShelfName)
                .ThenBy(s => s.ShelfType)
                .ToList();
        }

        public void AddShelf(Shelf shelf)
        {
            shelf.ShelfID = _nextId++;
            _shelves.Add(shelf);    
        }

        public void UpdateShelf(Shelf shelf)
        {
            var existingShelf = _shelves.Find(s => s.ShelfID == shelf.ShelfID);
            if (existingShelf != null) { 
            
            }  
        }

        public void RemoveShelf(int shelfID)
        {
            var existingShelf = GetById(shelfID);
            if (existingShelf != null)
            {
                _shelves.Remove(existingShelf);
            }
        }

    }
}
