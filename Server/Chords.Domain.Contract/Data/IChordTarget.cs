namespace Chords.Domain.Contract.Data
{
    public interface IChordTarget : IUniqueItem
    {
        IUniqueItem Chord { get; }

        string Target { get; }
    }
}