using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public class Istruttore : Tesserato,IGestioneSpecialita,ISalvabile
    {
        private CertificatoIstruttore _certificatoIstruttore;
        private CertificatoMedico _certificatoMedico;
        private List<StagioneSportiva> _stagioni;

        public void AggiungiSpecialita(Specialita specialita, int stagione)
        {
            throw new NotImplementedException();
        }

        public List<Specialita> GetSpecialitaDiStagione(StagioneSportiva stagione)
        {
            throw new NotImplementedException();
        }

        public List<Specialita> GetSpecialitaDiStagione(int anno)
        {
            throw new NotImplementedException();
        }

        public void Save(IOutput Interface)
        {
            throw new NotImplementedException();
        }
    }
}