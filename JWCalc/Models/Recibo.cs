using System;
using System.Collections.Generic;

namespace JWCalc.Models
{
    public enum TipoDeRecibo
    {
        NaoDefinido = 0,
        Donativo,
        DepositoNoCofre,
        Pagamento,
        DinheiroAdiantado
    }

    public enum TipoDonativo
    {
        NaoDefinido = 0,
        ObraMundial,
        DespesaLocal,
        ConstrucaoFilial,
        Outros
    }


    public class Recibo
    {
        public DateTime Data { get; set; }

        public TipoDeRecibo Tipo { get; set; }

        public List<Donativo> EntradasDonativos { get; set; }

        public decimal TotalDonativo { get; set; }

        public string AssinadoPor { get; set; }

        public string ConferidoPor { get; set; }

        public bool SegundaViaEntregue => false;
    }

    public class Donativo
    {
        public TipoDonativo TipoDonativo { get; set; }

        public decimal Valor { get; set; }
    }
}