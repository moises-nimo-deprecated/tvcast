using System;

namespace TvCast.Entity.Entities.Data
{
    public class PersonData
    {
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public ImageData Image { get; set; }
    }
}