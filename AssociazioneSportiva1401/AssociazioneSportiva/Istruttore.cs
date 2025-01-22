using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public class Istruttore : TesseratoSpecializzato
    {
        private CertificatoIstruttore? _certificatoIstruttore;
        public Istruttore(string nome, string cognome, string numeroTelefono, DateOnly dataNascita, CertificatoMedico? certificatoMedico, List<StagioneSportiva> stagioni, CertificatoIstruttore? certificatoIstruttore, Tessera tessera) : base(nome, cognome, numeroTelefono, dataNascita, certificatoMedico, stagioni, tessera)
        {
            CertificatoIstruttore = certificatoIstruttore;
        }
        public Istruttore(string nome, string cognome, string numeroTelefono, DateOnly dataNascita, Tessera tessera) : base(nome, cognome, numeroTelefono, dataNascita, tessera)
        {
            CertificatoIstruttore = null;
        }
        public CertificatoIstruttore? CertificatoIstruttore
        {
            get { return _certificatoIstruttore; }
            private set { _certificatoIstruttore = value; }
        }
    }
}