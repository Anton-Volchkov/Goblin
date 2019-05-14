using System;

namespace Narfu.Domain
{
    public class Group : IEquatable<Group>
    {
        public int RealId { get; set; }
        public int SiteId { get; set; }
        public string Name { get; set; }

        public bool Equals(Group other)
        {
            return SiteId == other.SiteId;
        }
        public override int GetHashCode()
        {
            return RealId ^ SiteId;
        }
    }
}