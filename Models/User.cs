using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTestApplication.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Username { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Password { get; set; }

    }
}
