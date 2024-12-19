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

        public override void CaricaFoto(string path, int id)
        {
            File.Copy(path, $"CertificatiMedici/certificatoMedico_{id}");
            Path = $"CertificatiMedici/certificatoMedico_{id}";
        }
    }
}