﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public interface IGestioneSpecialita
    {
        public List<Specialita> GetSpecialitaDiStagione(StagioneSportiva stagione);
        public List<Specialita> GetSpecialitaDiStagione(int anno);
        public void AggiungiSpecialita(Specialita specialita,int stagione);
    }
}