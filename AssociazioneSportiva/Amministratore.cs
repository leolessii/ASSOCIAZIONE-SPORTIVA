﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public class Amministratore : Tesserato
    {
        public Amministratore(string nome, string cognome, string numeroTelefono, DateOnly dataNascita) : base(nome, cognome, numeroTelefono, dataNascita)
        {
        }
    }
}