using Reolmarkedet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.Core.Interfaces
{
    public interface IShelfRepository
    {
<<<<<<< HEAD


        Shelf? Get(int shelfID);
        Shelf? Get(string searchTerm);

        Shelf? GetById(int shelfID);

=======
        Shelf? GetById(int shelfID);
>>>>>>> 6dcdbbd80aac4e4e1dda8895424cb4deb4bd308d
        List<Shelf> GetAll();
        int Insert(Shelf shelf);
        void Update(Shelf shelf);
        void Delete(int shelfID);

    }
}
