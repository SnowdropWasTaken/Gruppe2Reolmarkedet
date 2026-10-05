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


<<<<<<< HEAD
<<<<<<< HEAD
        public Shelf? Get(int shelfID)
        {
            return _shelves.Find(s => s.ID == shelfID);
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
<<<<<<< HEAD
<<<<<<< HEAD
            shelf.ID = _nextId++;
            _shelves.Add(shelf);    
=======
            shelf.ShelfId = _nextId++;
            _shelves.Add(shelf);
            return shelf.ShelfId;
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
=======
            shelf.ShelfId = _nextId++;
            _shelves.Add(shelf);
            return shelf.ShelfId;
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
        }

        public void Update(Shelf shelf)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            var existingShelf = _shelves.Find(s => s.ID == shelf.ID);

            if (existingShelf != null) 
            { 
                existingShelf.ShelfName = shelf.ShelfName;
                existingShelf.ShelfType = shelf.ShelfType;
            }  
=======
=======
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
            var existingShelf = _shelves.Find(s => s.ShelfId == shelf.ShelfId);
            if (existingShelf != null)
            {
                existingShelf.ShelfName = shelf.ShelfName;
                existingShelf.ShelfType = shelf.ShelfType;
                existingShelf.Status = shelf.Status;
            }
<<<<<<< HEAD
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
=======
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
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