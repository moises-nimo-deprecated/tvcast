using System.Dynamic;

namespace TvCast.Domain.Models
{
    public class CastingModel
    {
        public PersonModel Person { get; set; }

        public CharacterModel Character { get; set; }
    }
}