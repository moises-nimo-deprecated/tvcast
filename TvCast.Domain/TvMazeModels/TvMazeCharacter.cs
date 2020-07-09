namespace TvCast.Domain.TvMazeModels
{
    public class TvMazeCharacter
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public TvMazeImage Image { get; set; }
    }
}