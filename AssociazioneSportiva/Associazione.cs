using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public class Associazione
    {
        private string _nome;
        private int _quotaAssociativa;
        private List<Tesserato> _tesserati;
        private List<Specialita> _specialita;

        public string Nome
        {
            get { return _nome; }
            set 
            {
                if(string.IsNullOrEmpty(value)) throw new ArgumentNullException("nome non valido");
                _nome = value;
            }
        }
        public int QuotaAssociativa
        {
            get { return _quotaAssociativa; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("quota troppo bassa");
                _quotaAssociativa = value;
            }
        }
        public List<Tesserato> Tesserati
        {
            get { return _tesserati; }
        }

        public List<Specialita> Specialita
        {
            get { return _specialita; }
        }
        public Associazione(string nome, int quotaAssociativa)
        {
            Nome = nome;
            QuotaAssociativa = quotaAssociativa;
            List<Tesserato> _tesserati= new List<Tesserato>();
            List<Specialita> _specialita= new List<Specialita>();
        }
        public Associazione(string nome, int quotaAssociativa, List<Tesserato> tesserati, List<Specialita> specialita):this(nome, quotaAssociativa)
        {
            List<Tesserato> _tesserati = tesserati;
            List<Specialita> _specialita = specialita;
        }

        public Tesserato TesseratoDaId(int id)
        {
            Tesserato tesseratoCercato;
            foreach(Tesserato t in  _tesserati)
            {
                if(t.Tessera.Code==id) tesseratoCercato = t; 
                break;
            }
            return tesseratoCercato;
        }
        public List<Tesserato> TesseratiDaSpecialitaInAnno(Specialita s, int anno)
        {
            List<Tesserato> tesseratiConSpecialitaDellAnno = new List<Tesserato>();
            foreach(Tesserato t in _tesserati)
            {
                if (t.Stagioni.Anno == anno && t.Stagioni.Specialita.Contains(s)) tesseratiConSpecialitaDellAnno.Add(t);
            }
            return tesseratiConSpecialitaDellAnno;
        }

        public void AggiungiSpecialita(Specialita s)
        {
            Specialita.Add(s);
        }
    }
}