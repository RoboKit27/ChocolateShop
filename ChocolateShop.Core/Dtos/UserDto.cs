using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateShop.Core.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Phone { get; set; }
        public int Password { get; set; }
        public RoleDto? Role { get; set; }
        public int? RoleId { get; set; }
    }
}
