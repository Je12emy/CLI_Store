using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string HowTo { get; set; }

        [Required]
        public int PlatformId { get; set; }

        public Platform Platform {get; set;}
    }
}
