using System.ComponentModel.DataAnnotations;

namespace Negocios.EntityFramework.DML.ACESSOS
{

    public class USUARIOS
    {
        [Key]
        public int USUID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o usuário")]
        [StringLength(20)]
        public string USUNOME { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a senha")]
        [StringLength(20)]
        public string USUSENHA { get; set; }
        public System.DateTime USUULTLOGIN { get; set; }
    }
}
