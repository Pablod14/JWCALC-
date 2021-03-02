using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Negocios.EntityFramework.DML.JWCALC
{
    public class ENTRADASDONATIVO
    {
        public int ENTID { get; set; }
        [Key]
        [Column(Order = 1)]
        public int ENTRECIBO { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ENTDONATIVO { get; set; }
    
        public virtual DONATIVO DONATIVO { get; set; }
        public virtual RECIBO RECIBO { get; set; }
    }
}
