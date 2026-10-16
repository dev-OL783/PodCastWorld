namespace PodCastWorld
{
    public class Episode
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public int ListenCount { get; set; }

        public Episode(string title, string description)
        {
            Title = title;
            Description = description;
            DateCreated = DateTime.Now;
            ListenCount = 0;
        }

        public override string ToString()
        {
            return $"{Title} ({DateCreated:d}) - {ListenCount} listens";
        }
    }
}