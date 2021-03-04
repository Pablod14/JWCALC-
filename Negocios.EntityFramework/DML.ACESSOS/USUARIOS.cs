using System.ComponentModel.DataAnnotations;

namespace Negocios.EntityFramework.DML.ACESSOS
{

    public class USUARIOS
    {
        [Key]
        public int USUID { get; set; }

        [Display(Name = "Nome de Usu�rio")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o usu�rio")]
        [StringLength(20)]
        public string USUNOME { get; set; }

        [Display(Name = "Senha")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a senha")]
        [StringLength(20)]
        public string USUSENHA { get; set; }
        public System.DateTime USUULTLOGIN { get; set; }
    }
}
