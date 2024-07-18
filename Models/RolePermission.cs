using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace netcore_devsecops.Models
{
    [PrimaryKey(nameof(IdRole), nameof(IdPermission))]
    public class RolePermission
    {
        [ForeignKey("IdRole")]
        public Guid IdRole { get; set; }
        public Role? Role { get; set; }

        [ForeignKey("IdPermission")]
        public Guid IdPermission { get; set; }
        public Permission? Permission { get; set; }

        public bool IsAccessed { get; set; } = false;
    }
}
