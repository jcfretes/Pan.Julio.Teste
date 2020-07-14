using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pan.Julio.Teste.Model
{
    //Agregado
    public class Lancamentos : BaseModel
    {

        [Key]
        public int IdLancamento { get; set; }

        [Required]
        public int IdContaCorrente { get; set; }

        [Required]
        public int IdTipoOperacao { get; set; }

        [Required]
        public int IdTipoLancamento { get; set; }

        [Required]
        public DateTime DtOperacao { get; set; }

        [Required]
        public decimal VlOperacao { get; set; }

    }
}