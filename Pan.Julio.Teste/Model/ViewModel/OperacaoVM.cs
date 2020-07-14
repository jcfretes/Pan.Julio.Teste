using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pan.Julio.Teste.Model.ViewModel
{
    public class OperacaoVM : BaseVM
    {

        public int IdCliente { get; set; }

        public int IdContaOrigem { get; set; }

        public int? IdContaDestino { get; set; }

        public int? IdLancamento { get; set; }

        public int IdTipoLancamento { get; set; }

        public int IdTipoOperacao { get; set; }

        public decimal VlOperacao { get; set; }

        //Agregados


        //Objetos de Valor
        public Cliente Cliente { get; set; }

    }
}