using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pan.Julio.Teste.Model
{
    public class Cliente : BaseModel
    {

        [Key]
        public int IdCliente { get; set; }

        [Required]
        public bool IcPessoaFisica { get; set; }

        [Required]
        [MaxLength(50)]
        public string NmCliente { get; set; }
               
        [Required]
        [MaxLength(20)]
        public string NuDocumento { get; set; }

    }
}