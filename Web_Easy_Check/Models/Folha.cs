using System.Collections.Generic;

namespace Web_Easy_Check.Models
{
    public class Folha
    {
        public Empresa Empresa { get; set; }
        public string Funcao { get; set; }
        public double SalarioHora { get; set; }
        public double SalarioBase { get; set; }
        public int MesPeriodo { get; set; }
        public int AnoPeriodo { get; set; }
        public string TipoContracheque { get; set; }
        public string Departamento { get; set; }
        public string CentroDeCusto { get; set; }
        public double FGTS { get; set; }
        public IList<ItensFolha> ItensFolha { get; set; }
    }
}