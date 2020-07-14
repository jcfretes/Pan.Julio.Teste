using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pan.Julio.Teste.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pan.Julio.Teste.EF
{
    public class DBOperacoesContext : DbContext
    {

        public DBOperacoesContext()//IConfiguration config)
        {
            //_config = config;
        }

        //Campos
        //IConfiguration _config;

        //Entidades
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<TipoLancamento> TipoLancamento { get; set; }
        public DbSet<TipoOperacao> TipoOperacao { get; set; }

        //Conexão
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(_config.GetValue(typeof(string), "StringConexao").ToString());
            options.UseSqlServer("Data Source=192.168.0.5\\ftsharp;Initial Catalog=TestePan;User Id=sa;Password=1Gordo@1");
        }

        //Dados e Relacionamentos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TipoLancamento>().HasData(
                new TipoLancamento() { IdTipoLancamento = 1, NmTipoLancamento = "Débito", DtCriacao = DateTime.Now, IcAtivo = 1 },
                new TipoLancamento() { IdTipoLancamento = 2, NmTipoLancamento = "Crédito", DtCriacao = DateTime.Now, IcAtivo = 1 }
                );

            modelBuilder.Entity<TipoOperacao>().HasData(
                new TipoOperacao() { IdTipoOperacao = 1, NmTipoOperacao = "Transferencia", DtCriacao = DateTime.Now, IcAtivo = 1 },
                new TipoOperacao() { IdTipoOperacao = 2, NmTipoOperacao = "Doc", DtCriacao = DateTime.Now, IcAtivo = 1 },
                new TipoOperacao() { IdTipoOperacao = 3, NmTipoOperacao = "Ted", DtCriacao = DateTime.Now, IcAtivo = 1 },
                new TipoOperacao() { IdTipoOperacao = 4, NmTipoOperacao = "Depósito", DtCriacao = DateTime.Now, IcAtivo = 1 },
                new TipoOperacao() { IdTipoOperacao = 5, NmTipoOperacao = "Saque", DtCriacao = DateTime.Now, IcAtivo = 1 },
                new TipoOperacao() { IdTipoOperacao = 6, NmTipoOperacao = "Pagamento", DtCriacao = DateTime.Now, IcAtivo = 1 }
                );
        }

    }
}