using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pan.Julio.Teste.Model
{
    public class TipoOperacao : BaseModel
    {

        [Key]
        public int IdTipoOperacao { get; set; }

        [Required]
        public string NmTipoOperacao { get; set; }

    }
}