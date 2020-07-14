using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pan.Julio.Teste.Model
{
    public class TipoLancamento : BaseModel
    {

        [Key]
        public int IdTipoLancamento { get; set; }

        [Required]
        [MaxLength(50)]
        public string NmTipoLancamento { get; set; }

    }
}