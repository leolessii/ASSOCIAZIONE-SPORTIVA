using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public class Associazione
    {
        private int _quotaAssociativa;
        private List<Tesserato> _tesserati;
        private List<Specialita> _specialita;
        public List<Tesserato> Tesserati
        {
            get { return _tesserati; }
        }
        public Tesserato TesseratoDaId(int id)
        {
            throw new NotImplementedException();
        }
        public List<Tesserato> TesseratiDaSpecialitaInAnno(Specialita s, int anno)
        {
            throw new NotImplementedException();
        }
    }
}