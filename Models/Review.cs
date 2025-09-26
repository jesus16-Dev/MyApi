namespace MyApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }

        // Relaciones con User 
        public int UserId { get; set; }
        public User User { get; set; }
        //  Relacion con Platform
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
