using System;
using System.Collections.Generic;
using Chords.Domain.Contract.Data;
using Chords.Domain.Contract.Registry;

namespace Chords.Registry.Fake
{
    public sealed class FakeChordsRegistry : IChordsRegistry
    {
        public IReadOnlyList<IChord> GetItems(IUser owner)
        {
            return new List<IChord>().AsReadOnly();
        }

        public IChord Get(IUniqueItem item, IUser owner)
        {
            throw new ArgumentException("Unable to find requested item: fake registry is always empty!", nameof(item));
        }

        public bool Exists(IUniqueItem item, IUser owner)
        {
            return false;
        }

        public void Update(IChord item, IUser owner)
        {
            throw new NotImplementedException();
        }

        public IUniqueItem Add(IChord item, IUser owner)
        {
            throw new NotImplementedException();
        }

        public void Delete(IUniqueItem item, IUser owner)
        {
            throw new NotImplementedException();
        }
    }
}
