using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public class Atleta:Tesserato,IGestioneSpecialita,ISalvabile
    {
        private CertificatoMedico _certificatoMedico;
        private List<StagioneSportiva> _stagioni;

        public Atleta(Tessera tessera, string nome, string cognome, string numeroTelefono, DateOnly dataNascita, CertificatoMedico certificatoMedico) : base(tessera, nome, cognome, numeroTelefono, dataNascita)
        {
            _certificatoMedico = certificatoMedico;
            _stagioni = new List<StagioneSportiva>();
        }
        public Atleta(Tessera tessera, string nome, string cognome, string numeroTelefono, DateOnly dataNascita, CertificatoMedico certificatoMedico, List<StagioneSportiva> stagioni) : this(tessera, nome, cognome, numeroTelefono, dataNascita, certificatoMedico)
        {
            _stagioni = stagioni;
        }
        public CertificatoMedico CertificatoMedico
        {
            get { return _certificatoMedico; }
            private set { _certificatoMedico = value; }
        }
        public List<StagioneSportiva> Stagioni
        {
            get { return _stagioni; }
            private set { _stagioni = value; }
        }
        public void AggiungiSpecialita(Specialita specialita, int stagione)
        {
            bool found = false;
            foreach (StagioneSportiva s in _stagioni)
            {
                if(s.Anno == stagione)
                {
                    s.AggiungiSpecialita(specialita);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                //##TODO usare cottruttore con parametri giusti
                StagioneSportiva nuovaStagione = new StagioneSportiva();
            }
        }

        public List<Specialita> GetSpecialitaDiStagione(StagioneSportiva stagione)
        {
            foreach(StagioneSportiva s in _stagioni)
            {
                if (s.Equals(stagione))
                {
                    //##TODO togli commento
                    ///return s.Specialita;
                }
            }
            throw new Exception("Stagione non presente");
        }

        public List<Specialita> GetSpecialitaDiStagione(int anno)
        {
            foreach (StagioneSportiva s in _stagioni)
            {
                if (s.Anno==anno)
                {
                    //##TODO togli commento
                    ///return s.Specialita;
                }
            }
            throw new Exception("Stagione non presente");
        }

        public void RimuoviSpecialita(Specialita specialita, int stagione)
        {
            throw new NotImplementedException();
        }

        public void RimuoviSpecialita(string nome, int stagione)
        {
            throw new NotImplementedException();
        }

        public void Save(IOutput Interface, Formato formato)
        {
            Interface.ScriviAtleta(this,formato);
        }
    }
}