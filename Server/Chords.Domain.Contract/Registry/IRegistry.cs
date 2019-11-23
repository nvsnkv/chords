using System.Collections.Generic;
using Chords.Domain.Contract.Data;

namespace Chords.Domain.Contract.Registry
{
    public interface IRegistry<T> where T : IUniqueItem
    {
        IReadOnlyList<T> GetItems(IUser owner);

        T Get(IUniqueItem item, IUser owner);

        bool Exists(IUniqueItem item, IUser owner);

        void Update(T item, IUser owner);

        IUniqueItem Add(T item, IUser owner);

        void Delete(IUniqueItem item, IUser owner);
    }
}