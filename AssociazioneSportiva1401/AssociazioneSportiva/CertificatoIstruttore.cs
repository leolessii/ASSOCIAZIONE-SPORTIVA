using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public class CertificatoIstruttore : Certificato
    {
        private List<Specialita> _specialita;

        public List<Specialita> Specialita
        {
            get { return _specialita; }
        }

        public CertificatoIstruttore(DateOnly dataEmissione, DateOnly datascadenza) : base(dataEmissione, datascadenza)
        {
            _specialita = new List<Specialita>();
        }
        public CertificatoIstruttore(DateOnly dataEmissione, DateOnly datascadenza, List<Specialita> specialita) : base(dataEmissione, datascadenza)
        {
            _specialita = specialita;
        }

        public override void CaricaFoto(string path, string nome, string pathSalvataggio)
        {
            if (File.Exists($"{pathSalvataggio}/CertificatiIstruttore/certificatoIstruttore_{nome}.png"))
            {
                File.Delete($"{pathSalvataggio}/CertificatiIstruttore/certificatoIstruttore_{nome}.png");
            }
            File.Copy(path, $"{pathSalvataggio}/CertificatiIstruttore/certificatoIstruttore_{nome}.png");
            Path = $"{pathSalvataggio}/CertificatiIstruttore/certificatoIstruttore_{nome}.png";
        }

    }
}