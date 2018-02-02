using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetOwin.Models.DB
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}