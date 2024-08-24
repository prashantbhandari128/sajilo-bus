using System.ComponentModel.DataAnnotations;

namespace WebService.DataAccess.Entities
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
