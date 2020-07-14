using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pan.Julio.Teste.AppServices;
using Pan.Julio.Teste.Model.ViewModel;

namespace Pan.Julio.Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacoesController : ControllerBase
    {

        public OperacoesController(IOperacoesService operacoes)
        {
            _operacoes = operacoes;
        }

        IOperacoesService _operacoes;
        string MenssagemSucesso = "Operação realizada com sucesso.";

        [HttpPost()]
        public ActionResult Operacao(OperacaoVM Operacao)
        {
            OperacaoVM vOperacao = null;

            try
            {
                switch (Operacao.IdTipoOperacao)
                {
                    case 1:

                        vOperacao = _operacoes.RegistrarTransferencia(Operacao);

                        break;

                    default:

                        throw new Exception("Operação não implementada.");
                }

                vOperacao.Sucesso = true;
                vOperacao.Mensagem = MenssagemSucesso;

                return Ok(vOperacao);
            }
            catch (Exception Ex)
            {
                vOperacao.Sucesso = true;
                vOperacao.Mensagem = "Origem : " + Ex.Source + "-Mesangem : " + Ex.Message;

                return BadRequest(vOperacao);
            }
        }
               
    }
}