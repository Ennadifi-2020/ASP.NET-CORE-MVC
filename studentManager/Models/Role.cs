using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentManager.Models
{
    public class Role
    {
        [Required]
        public string RoleName { get; set; }

        public string id { get; set; }

        public List<string> Users { get; set; }
    }
}
