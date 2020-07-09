using System.Collections.Generic;

namespace TvCast.Domain.Models
{
    public class ShowModel
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CastingModel> Castings { get; set; }
    }
}