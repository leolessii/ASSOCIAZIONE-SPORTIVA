using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public interface IInput
    {
        public List<Atleta> LeggiAtleti();
        public List<Istruttore> LeggiIstruttori();
        public List<Specialita> LeggiSpecialita();
    }
}