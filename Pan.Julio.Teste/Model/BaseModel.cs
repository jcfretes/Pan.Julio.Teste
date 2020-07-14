using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pan.Julio.Teste.Model
{
    public class BaseModel
    {

        [Required]
        public DateTime DtCriacao { get; set; }

        [Required]
        public int IcAtivo { get; set; }

    }
}