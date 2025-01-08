using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public class Atleta : Tesserato, IGestioneSpecialita
    {
        private CertificatoMedico _certificatoMedico;
        private List<StagioneSportiva> _stagioni;

        public Atleta(string nome, string cognome, string numeroTelefono, DateOnly dataNascita, CertificatoMedico certificatoMedico, List<StagioneSportiva> stagioni) : base(nome, cognome, numeroTelefono, dataNascita)
        {
            _certificatoMedico = certificatoMedico;
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
                if (s.Anno == stagione)
                {
                    s.AggiungiSpecialita(specialita);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                StagioneSportiva nuovaStagione = new StagioneSportiva(stagione);
                nuovaStagione.AggiungiSpecialita(specialita);
                _stagioni.Add(nuovaStagione);
            }
        }

        public List<Specialita> GetSpecialitaDiStagione(StagioneSportiva stagione)
        {
            List<Specialita> res = new List<Specialita>();
            foreach (StagioneSportiva s in _stagioni) {
                if (s.Anno == stagione.Anno) {
                    res = s.Specialita;
                    break;
                }
            }
            return res;
        }

        public List<Specialita> GetSpecialitaDiStagione(int anno)
        {
            List<Specialita>res = new List<Specialita> ();
            foreach (StagioneSportiva s in _stagioni) {
                if (s.Anno == anno) {
                    res = s.Specialita;
                    break;
                }
            }
            return res;
        }

        public void RimuoviSpecialita(Specialita specialita, int stagione)
        {
            foreach (StagioneSportiva s in _stagioni) {
                if (s.Anno == stagione) {
                    s.Specialita.Remove(specialita);
                    break;
                }
            }
        }

        public void RimuoviSpecialita(string nome, int stagione)
        {
            foreach (StagioneSportiva s in _stagioni) {
                if (s.Anno == stagione) {
                    s.Specialita.Remove(new Specialita(nome));
                    break;
                }
            }
        }

        public void Save(IOutput Interface, Formato formato)
        {
            Interface.ScriviAtleta(this, formato);
        }
    }
}