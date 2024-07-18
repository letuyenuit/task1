using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netcore_devsecops.Models
{
    public class Role
    {
        [Key]
        public Guid IdRole { get; set; }
        public string Name { get; set; }
        public List<RolePermission>? RolePermissions { get; set; }
        public List<User>? Users { get; set; }  
    }
}
