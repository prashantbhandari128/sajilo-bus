using System.ComponentModel.DataAnnotations;

namespace WebService.DataAccess.Entities
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        [Required]
        [MaxLength(100)]
        public string LocationName { get; set; } = String.Empty;
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }
        public string CreatedAt { get; set; } = String.Empty;
    }
}
