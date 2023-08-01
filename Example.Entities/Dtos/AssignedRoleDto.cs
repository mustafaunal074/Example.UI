using Example.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Entities.Dtos
{
    public class AssignedRoleDto
    {
        public AppRole Role { get; set; }
        public List<AppUser> HasRole { get; set; }
        public List<AppUser> HasNotRole { get; set; }
        public string RoleName { get; set; }
        public string[] AddIds { get; set; }
        public string[] DeleteIds { get; set; }
    }
}
