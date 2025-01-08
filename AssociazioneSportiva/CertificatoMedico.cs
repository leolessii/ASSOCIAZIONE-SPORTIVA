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

        public override void CaricaFoto(string path, string nome)
        {
            if(File.Exists($"../../../CertificatiMedici/certificatoMedico_{nome}.png")) {
                File.Delete($"../../../CertificatiMedici/certificatoMedico_{nome}.png");
            }
            File.Copy(path, $"../../../CertificatiMedici/certificatoMedico_{nome}.png");
            Path = $"../../../CertificatiMedici/certificatoMedico_{nome}.png";
        }
    }
}