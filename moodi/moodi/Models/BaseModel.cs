using System;

namespace moodi.Models
{
    public class BaseModel : IComparable
    {
        public Guid ID { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            var other = obj as BaseModel;
            if (other == null)
                throw new ArgumentException("Object is not a Model");

            return ID.CompareTo(other.ID);
        }
    }
}
