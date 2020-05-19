using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Entity
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The name needs to be filled in")]
        [MaxLength(30, ErrorMessage = "Name needs to be up to 30 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The password needs to be filled in")]
        [MaxLength(20, ErrorMessage = "Password needs to be up to 20 characters")]
        public string Password { get; set; }
    }
}
