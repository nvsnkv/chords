using System;

namespace Chords.Domain.Contract.Data
{
    public sealed class UniqueItem : IUniqueItem, IEquatable<IUniqueItem>
    {
        public UniqueItem(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public static implicit operator UniqueItem(string id)
        {
            return new UniqueItem(id);
        }

        public bool Equals(IUniqueItem other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is UniqueItem other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }
    }
}