namespace Domain.Entities
{
    public class Shortlink : Identifier
    {
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public int Hint { get; set; }
    }
}
