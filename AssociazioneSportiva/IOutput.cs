using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public interface IOutput
    {
        public void ScriviAtleta(Atleta atleta, Formato formato);
        public void ScriviIstruttore(Istruttore istruttore, Formato formato);
        public void ScriviSpecialita(Specialita specialita, Formato formato);
    }
}