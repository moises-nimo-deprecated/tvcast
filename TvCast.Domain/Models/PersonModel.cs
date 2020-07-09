using System;
using TvCast.Entity.Entities.Data;

namespace TvCast.Domain.Models
{
    public class PersonModel
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public ImageModel Image { get; set; }
    }
}