using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public class Istruttore : Tesserato, IGestioneSpecialita
    {
        private CertificatoIstruttore _certificatoIstruttore;
        private List<StagioneSportiva> _stagioni;

        public Istruttore(string nome, string cognome, string numeroTelefono, DateOnly dataNascita) : base(nome, cognome, numeroTelefono, dataNascita)
        {
            DateOnly now = DateOnly.FromDateTime(DateTime.Now);
            DateOnly scad = new DateOnly(now.Year + 5, now.Month, now.Day);
            _certificatoIstruttore = new CertificatoIstruttore(now, scad);
            _stagioni = new List<StagioneSportiva>();
        }
        public Istruttore(string nome, string cognome, string numeroTelefono, DateOnly dataNascita, CertificatoIstruttore certificatoIstruttore, List<StagioneSportiva> stagioni) : this(nome, cognome, numeroTelefono, dataNascita)
        {
            _certificatoIstruttore = certificatoIstruttore;
            _stagioni = stagioni;
        }

        public CertificatoIstruttore CertificatoIstruttore
        {
            get { return _certificatoIstruttore; }
            private set
            {
                _certificatoIstruttore = value;
            }
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
                nuovaStagione.Specialita.Add(specialita);
            }
        }

        public List<Specialita> GetSpecialitaDiStagione(StagioneSportiva stagione)
        {
            foreach (StagioneSportiva s in _stagioni)
            {
                if (s.Equals(stagione))
                {
                    return s.Specialita;
                }
            }
            throw new Exception("Stagione non presente");
        }


        public List<Specialita> GetSpecialitaDiStagione(int anno)
        {
            foreach (StagioneSportiva s in _stagioni)
            {
                if (s.Anno == anno) {
                   return s.Specialita;
                }
            }
            throw new Exception("Stagione non presente");
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
            Interface.ScriviIstruttore(this, formato);
        }
    }
}