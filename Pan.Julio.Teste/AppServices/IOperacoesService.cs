using Pan.Julio.Teste.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pan.Julio.Teste.AppServices
{
    public interface IOperacoesService
    {

        OperacaoVM RegistrarTransferencia(OperacaoVM Operacao); 

    }
}