using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public interface IOutput
    {
        public void ScriviAtleti(Formato formato, Atleta a);
        public void ScriviIstruttore(Formato formato, Istruttore i);
        public void ScriviSpecialita(Formato formato, Specialita s);
        public void InviaDatiAtleti(Associazione associazione);
    }
}