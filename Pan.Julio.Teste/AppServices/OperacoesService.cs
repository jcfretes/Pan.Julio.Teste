using Microsoft.Extensions.Configuration;
using Pan.Julio.Teste.EF;
using Pan.Julio.Teste.Model;
using Pan.Julio.Teste.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pan.Julio.Teste.AppServices
{
    public class OperacoesService : IOperacoesService
    {

        public OperacoesService(IConfiguration config, DBOperacoesContext context)
        {
            _config = config;
            _context = context;
        }

        IConfiguration _config;

        DBOperacoesContext _context;

        public OperacaoVM RegistrarTransferencia(OperacaoVM Operacao)
        {
            //Declarações
            ContaCorrente ContaOrigem = null;
            ContaCorrente ContaDestino = null;
            Lancamentos LancOrigem = null;
            Lancamentos LancDestino = null;
            DateTime DataOperacao;

            try
            {
                //Instâncias e Inicializações
                DataOperacao = DateTime.Now;

                //Desenvolvimento
                ContaOrigem = _context.ContaCorrente.Where(q => q.IdContaCorrente == Operacao.IdContaOrigem).FirstOrDefault();
                ContaDestino = _context.ContaCorrente.Where(q => q.IdContaCorrente == Operacao.IdContaDestino).FirstOrDefault();

                //Registrar Lançamento Conta Origem
                LancOrigem = LancamentoDebito(Operacao.IdContaOrigem, DataOperacao, Operacao.VlOperacao);
                _context.Add(LancOrigem);

                //Registrar Lançamento Conta Destino
                if (Operacao.IdContaDestino != null)
                {
                    LancDestino = LancamentoCredito((int)Operacao.IdContaDestino, DataOperacao, Operacao.VlOperacao);
                    _context.Add(LancDestino);
                }
                else
                {
                    throw new Exception("Operação Inválida.");
                }

                //Registrar Alteração Saldo Origem
                ContaOrigem.VlSaldo -= Operacao.VlOperacao;
                ContaOrigem.DtUltOperacao = DateTime.Now;
                _context.Update(ContaOrigem);

                //Registrar Alteração Saldo Destino
                ContaDestino.VlSaldo += Operacao.VlOperacao;
                ContaDestino.DtUltOperacao = DateTime.Now;
                _context.Update(ContaDestino);

                //Efetiva alterações
                _context.SaveChanges();

                //Retorna Id da Operação de Origem 
                Operacao.IdLancamento = LancOrigem.IdLancamento;
                return Operacao;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #region Método Privados

        private Lancamentos LancamentoCredito(int IdConta, DateTime pDataOperacao, decimal VlOperacao)
        {
            //Declarações
            Lancamentos LancOrigem = null;

            try
            {
                //Instâncias e Inicializações
                LancOrigem = new Lancamentos();

                //Desenvolvimento
                LancOrigem.IdContaCorrente = IdConta;
                LancOrigem.IdTipoLancamento = 1; //Débito
                LancOrigem.IdTipoOperacao = 1; //Transferência
                LancOrigem.VlOperacao = VlOperacao;
                LancOrigem.DtOperacao = pDataOperacao;
                LancOrigem.DtCriacao = DateTime.Now;
                LancOrigem.IcAtivo = 1;

                return LancOrigem;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private Lancamentos LancamentoDebito(int IdConta, DateTime pDataOperacao, decimal VlOperacao)
        {
            //Declarações
            Lancamentos LancDestino = null;

            try
            {
                //Instâncias e Inicializações
                LancDestino = new Lancamentos();

                //Desenvolvimento
                LancDestino.IdContaCorrente = IdConta;
                LancDestino.IdTipoLancamento = 2; //Crédito
                LancDestino.IdTipoOperacao = 1; //Transferência
                LancDestino.VlOperacao = VlOperacao;
                LancDestino.DtOperacao = pDataOperacao;
                LancDestino.DtCriacao = DateTime.Now;
                LancDestino.IcAtivo = 1;

                return LancDestino;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #endregion
    }
}