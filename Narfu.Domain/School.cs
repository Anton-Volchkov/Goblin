using System;

namespace Narfu.Domain
{
    public class School : IEquatable<School>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public bool Equals(School other)
        {
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}