using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOwin.Core.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public virtual Dado Dado { get; set; }

        public virtual Endereco Endereco { get; set; }
    }
}
