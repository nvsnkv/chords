using System;
using System.Collections.Generic;
using Chords.Domain.Contract.Data;
using Chords.Domain.Contract.Registry;

namespace Chords.Registry.Fake
{
    public sealed class FakeChordTargetsRegistry : IChordTargetsRegistry
    {
        public IReadOnlyList<IChordTarget> GetItems(IUser owner)
        {
            return new List<IChordTarget>().AsReadOnly();
        }

        public IChordTarget Get(IUniqueItem item, IUser owner)
        {
            throw new ArgumentException("Unable to find requested item: fake registry is always empty!", nameof(item));
        }

        public bool Exists(IUniqueItem item, IUser owner)
        {
            return false;
        }

        public void Update(IChordTarget item, IUser owner)
        {
            throw new System.NotImplementedException();
        }

        public IUniqueItem Add(IChordTarget item, IUser owner)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(IUniqueItem item, IUser owner)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyList<IChordTarget> GetItemsByChord(IChord chord)
        {
            throw new ArgumentException("Unable to find requested items: fake registry is always empty!", nameof(chord));
        }
    }
}