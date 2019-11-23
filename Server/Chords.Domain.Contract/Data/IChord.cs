namespace Chords.Domain.Contract.Data
{
    public interface IChord : IUniqueItem
    {
        string Name { get; }

        string DefaultPayload { get; }

        IUser Owner { get; }
    }
}