using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.Core.Interfaces
{
    public interface IGenericRepo<T>
    {
        T? Get(int id);
        
        IEnumerable<T> GetAll();
        
        void Add(T item);

        void Update(T item);

        void Remove(int id);
    }
}
