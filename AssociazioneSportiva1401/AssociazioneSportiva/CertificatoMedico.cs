using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public class CertificatoMedico : Certificato
    {
        public CertificatoMedico(DateOnly dataEmissione, DateOnly dataScadenza) : base(dataEmissione, dataScadenza)
        {
        }

        public override void CaricaFoto(string path, string nome, string pathSalvataggio)
        {
            if (File.Exists($"{pathSalvataggio}/CertificatiMedici/certificatoMedico_{nome}.png"))
            {
                File.Delete($"{pathSalvataggio}CertificatiMedici/certificatoMedico_{nome}.png");
            }
            File.Copy(path, $"{pathSalvataggio}/CertificatiMedici/certificatoMedico_{nome}.png");
            Path = $"{pathSalvataggio}/certificatoMedico_{nome}.png";
        }
    }
}