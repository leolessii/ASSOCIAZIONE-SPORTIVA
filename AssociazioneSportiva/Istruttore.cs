﻿using System;
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

        public Istruttore(Tessera tessera, string nome, string cognome, string numeroTelefono, DateOnly dataNascita, CertificatoMedico certificatoMedico,CertificatoIstruttore certificatoIstruttore) : base(tessera, nome, cognome, numeroTelefono, dataNascita)
        {
            _certificatoIstruttore = certificatoIstruttore;
            _certificatoMedico = certificatoMedico;
            _stagioni = new List<StagioneSportiva>();
        }
        public Istruttore(Tessera tessera, string nome, string cognome, string numeroTelefono, DateOnly dataNascita, CertificatoMedico certificatoMedico, CertificatoIstruttore certificatoIstruttore, List<StagioneSportiva>stagioni) : this(tessera, nome, cognome, numeroTelefono, dataNascita,certificatoMedico,certificatoIstruttore)
        {
            _stagioni = stagioni;
        }

        public CertificatoIstruttore CertificatoIstruttore
        {
            get { return _certificatoIstruttore;}
            private set
            {
                _certificatoIstruttore = value;
            }
        }
        public CertificatoMedico CertificatoMedico
        {
            get { return _certificatoMedico; }
            private set
            {
                _certificatoMedico = value;
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
                //##TODO usare cottruttore con parametri giusti
                StagioneSportiva nuovaStagione = new StagioneSportiva();
            }
        }

        public List<Specialita> GetSpecialitaDiStagione(StagioneSportiva stagione)
        {
            foreach (StagioneSportiva s in _stagioni)
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
                if (s.Anno == anno)
                {
                    //##TODO togli commento
                    ///return s.Specialita;
                }
            }
            throw new Exception("Stagione non presente");
        }

        public void Save(IOutput Interface)
        {
            Interface.ScriviIstruttore(this);
        }
    }
}