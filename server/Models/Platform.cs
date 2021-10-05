using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace server.Models
{
    [GraphQLDescription("Represent a software or service CLI")]
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [GraphQLDescription("Represent a purchased valid licence")]
        public string LicenseKey { get; set; }

        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}
