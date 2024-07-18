using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netcore_devsecops.Models
{
    public class User
    {
        [Key]
        public Guid IdUser { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        [ForeignKey("IdRole")]
        public Guid IdRole { get; set; }
        public Role? Role { get; set; }
    }
}
