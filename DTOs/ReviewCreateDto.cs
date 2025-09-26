namespace MyApi.DTOs
{
    public class ReviewCreateDto
    {
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }


        public int UserId { get; set; }
        public int PlatformId { get; set; }
    }

    public class ReviewUpdateDto
    {
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}
