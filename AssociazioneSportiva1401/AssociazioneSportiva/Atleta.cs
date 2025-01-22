using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public class Atleta : TesseratoSpecializzato
    {
        public Atleta(string nome, string cognome, string numeroTelefono, DateOnly dataNascita, CertificatoMedico certificatoMedico, List<StagioneSportiva> stagioni, Tessera tessera) : base(nome, cognome, numeroTelefono, dataNascita, certificatoMedico, stagioni, tessera)
        {

        }
        public Atleta(string nome, string cognome, string numeroTelefono, DateOnly dataNascita, Tessera tessera) : base(nome, cognome, numeroTelefono, dataNascita, tessera)
        {

        }

        public Atleta()
        {

        }
    }
}