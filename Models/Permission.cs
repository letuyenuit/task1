using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netcore_devsecops.Models
{
    public class Permission
    {
        [Key]
        public Guid IdPermission { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public List<RolePermission> RolePermissions { get; set; }

    }
}
