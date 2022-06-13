namespace Movie.Models
{
    public class Actor_Movie
    {
        public int MovieId { get; set; }
        public Moviee Movie { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
