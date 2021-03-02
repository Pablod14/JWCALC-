namespace Negocios.EntityFramework.DML.JWCALC
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DONATIVO
    {
        public DONATIVO()
        {
            this.ENTRADASDONATIVO = new HashSet<ENTRADASDONATIVO>();
        }

        [Key]
        public int DONID { get; set; }
        public int DONTIPO { get; set; }
        public decimal DONVALOR { get; set; }
    
        public virtual TIPODONATIVO TIPODONATIVO { get; set; }

        public virtual ICollection<ENTRADASDONATIVO> ENTRADASDONATIVO { get; set; }
    }
}
