using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public interface ISalvabile
    {
        public void Save(IOutput Interface, Formato formato);
    }
}