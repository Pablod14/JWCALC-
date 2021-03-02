using Negocios.ConexaoBD;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Negocios.EntityFramework.DML.ACESSOS
{
    public class BaseACESSOS : DbContext
    {
        public BaseACESSOS(string pNomeDataBase, int pTimeOut = 30)
            : base(new TransacoesBD(pNomeDataBase, pTimeOut, false).StringDeConexao())
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<USUARIOS> USUARIOS { get; set; }
    }
}
