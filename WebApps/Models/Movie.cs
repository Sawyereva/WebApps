using System.ComponentModel.DataAnnotations;

namespace WebApps.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}
