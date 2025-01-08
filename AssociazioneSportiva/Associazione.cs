using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
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
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("nome non valido");
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
            _tesserati = new List<Tesserato>();
            _specialita = new List<Specialita>();
        }
        public Associazione(string nome, int quotaAssociativa, List<Tesserato> tesserati, List<Specialita> specialita) : this(nome, quotaAssociativa)
        {
            _tesserati = tesserati;
            _specialita = specialita;
        }

        public Tesserato TesseratoDaId(int id)
        {
            Tesserato? tesseratoCercato = null;
            foreach (Tesserato t in _tesserati)
            {
                if (t.Tessera.Code == id) tesseratoCercato = t;
                break;
            }
            if (tesseratoCercato == null) throw new ArgumentNullException("Tesserato non trovato");
            return tesseratoCercato;
        }
        public List<IGestioneSpecialita> TesseratiConSpecialita
        {
            get {
                List<IGestioneSpecialita> specializzati = new List<IGestioneSpecialita>();
                foreach(Tesserato t in _tesserati) {
                    if(t is IGestioneSpecialita) {
                        specializzati.Add(t as IGestioneSpecialita);
                    }
                }
                return specializzati;
            }
        }
        public void AggiungiSpecialita(Specialita s)
        {
            Specialita.Add(s);
        }

        public List<Atleta> RestituisciAtleti()
        {
            List<Atleta> atleti=new List<Atleta>();
            foreach(Tesserato tesserato in _tesserati) {
                if(tesserato is Atleta) atleti.Add(tesserato as Atleta);
            }
            return atleti;
        }
        public List<Istruttore> RestituisciIstruttori()
        {
            List<Istruttore> istruttori = new List<Istruttore>();
            foreach (Tesserato tesserato in _tesserati) {
                if (tesserato is Istruttore) istruttori.Add(tesserato as Istruttore);
            }
            return istruttori;
        }
        public List<Amministratore> RestituisciAmministratori()
        {
            List<Amministratore> amministratori = new List<Amministratore>();
            foreach (Tesserato tesserato in _tesserati) {
                if (tesserato is Amministratore) amministratori.Add(tesserato as Amministratore);
            }
            return amministratori;
        }
        public void RimuoviTesserato(Tesserato t)
        {
            _tesserati.Remove(t);
        }
    }
}