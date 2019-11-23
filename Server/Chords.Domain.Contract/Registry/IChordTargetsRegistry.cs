using System.Collections.Generic;
using Chords.Domain.Contract.Data;

namespace Chords.Domain.Contract.Registry
{
    public interface IChordTargetsRegistry : IRegistry<IChordTarget>
    {
        IReadOnlyList<IChordTarget> GetItemsByChord(IChord chord);
    }
}