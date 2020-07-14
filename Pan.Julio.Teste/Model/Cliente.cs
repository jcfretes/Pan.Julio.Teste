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
        public int IdTipoCliente { get; set; }

        [Required]
        public string NmCliente { get; set; }
               
        [Required]
        public string NuDocumento { get; set; }

    }
}