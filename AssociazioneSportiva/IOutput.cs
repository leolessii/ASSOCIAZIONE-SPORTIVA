using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public interface IOutput
    {
        public void ScriviAtleta(Atleta atleta);
        public void ScriviIstruttore(Istruttore istruttore);
        public void ScriviSpecialita(Specialita specialita);
    }
}