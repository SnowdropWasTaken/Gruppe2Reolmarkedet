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


        public Shelf GetById(int shelfID)
        {
            //Vi har ikke tilføjet shelfID til klassen Shelf endnu.
            return _shelves.Find(s => s.shelfID == shelfID);
        }

        public Shelf? Get(string searchTerm)
        {
            return _shelves.Find(s => 
            s.ShelfName == searchTerm ||
            s.ShelfType.Name == searchTerm);    
=======
        public Shelf? GetById(int shelfID)
        {
            return _shelves.Find(s => s.ShelfId == shelfID);
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
=======
        public Shelf? GetById(int shelfID)
        {
            return _shelves.Find(s => s.ShelfId == shelfID);
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
        }

        public List<Shelf> GetAll()
        {
            return _shelves
                .OrderBy(s => s.ShelfName)
                .ThenBy(s => s.ShelfType.Name)
                .ToList();
        }

        public int Insert(Shelf shelf)
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

        public void Delete(int shelfID)
        {
            var existingShelf = Get(shelfID);
            if (existingShelf != null)
            {
                _shelves.Remove(existingShelf);
            }
        }

    }
}