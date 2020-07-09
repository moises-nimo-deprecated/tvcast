using System;

namespace TvCast.Domain.TvMazeModels
{
    public class TvMazePerson
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public TvMazeImage Image { get; set; }
    }
}