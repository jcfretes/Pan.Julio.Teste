using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pan.Julio.Teste.Model
{
    //Raiz do Agregado
    public class ContaCorrente : BaseModel
    {

        [Key]
        public int IdContaCorrente { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public DateTime DtAbertura { get; set; }

        [Required]
        public decimal VlSaldo { get; set; }

        [Required]
        public DateTime DtUltOperacao { get; set; }

    }
}