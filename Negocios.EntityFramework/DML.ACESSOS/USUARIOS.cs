using System.ComponentModel.DataAnnotations;

namespace Negocios.EntityFramework.DML.ACESSOS
{

    public class USUARIOS
    {
        [Key]
        public int USUID { get; set; }
        public string USUNOME { get; set; }
        public string USUSENHA { get; set; }
        public System.DateTime USUULTLOGIN { get; set; }
    }
}
