namespace DesignPatterns.Repository.Models
{
    public class Post
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public string Content { get; set; }
    }
}