using Negocios.ConexaoBD;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;

namespace Negocios.EntityFramework.DML.JWCALC
{
    public class BaseJWCALC : DbContext
    {
        public BaseJWCALC(string pNomeDataBase, int pTimeOut = 30)
            : base(new TransacoesBD(pNomeDataBase, pTimeOut, false).StringDeConexao())
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<DONATIVO> DONATIVO { get; set; }
        public virtual DbSet<ENTRADASDONATIVO> ENTRADASDONATIVO { get; set; }
        public virtual DbSet<RECIBO> RECIBO { get; set; }
        public virtual DbSet<TIPODONATIVO> TIPODONATIVO { get; set; }
        public virtual DbSet<TIPORECIBO> TIPORECIBO { get; set; }
    }
}
