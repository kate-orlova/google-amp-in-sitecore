using System;

namespace MyFoundation.Models
{
    [Serializable]
    public class Image
    {
        public string Alt { get; set; }

        public int Height { get; set; }

        public int HSpace { get; set; }

        public string Src { get; set; }

        public int VSpace { get; set; }

        public int Width { get; set; }

        public Guid MediaId { get; set; }

        public string Title { get; set; }

        public virtual DateTime DateCreated { get; set; }

        public virtual DateTime DateUpdated { get; set; }

        public virtual string AdditionalParameters { get; set; }
    }
}