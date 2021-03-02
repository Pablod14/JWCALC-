using System.ComponentModel.DataAnnotations;

namespace Negocios.EntityFramework.DML.ACESSOS
{

    public class USUARIOS
    {
        [Key]
        public int USUID { get; set; }
        [Required]
        public string USUNOME { get; set; }
        [Required]
        public string USUSENHA { get; set; }
        public System.DateTime USUULTLOGIN { get; set; }
    }
}
