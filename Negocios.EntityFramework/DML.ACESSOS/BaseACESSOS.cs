using Negocios.ConexaoBD;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Negocios.EntityFramework.DML.ACESSOS
{
    public class BaseACESSOS : DbContext
    {
        public BaseACESSOS(int pTimeOut = 30)
            : base(new TransacoesBD(CONSTANTES.C_ACESSOS, pTimeOut, false).StringDeConexao())
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<USUARIOS> USUARIOS { get; set; }
    }
}
