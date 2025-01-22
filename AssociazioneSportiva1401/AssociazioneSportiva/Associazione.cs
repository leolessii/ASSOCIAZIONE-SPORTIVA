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
        private string _percorsoCertificati;
        private List<Tesserato> _tesserati;
        private List<Specialita> _specialita;

        public string Nome
        {
            get { return _nome; }
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("nome non valido");
                _nome = value;
            }
        }
        public string PercorsoCertificati
        {
            get { return _percorsoCertificati; }
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("percorso non valido");
                _percorsoCertificati = value;
            }
        }
        public int QuotaAssociativa
        {
            get { return _quotaAssociativa; }
            private set
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
        public Associazione(string nome, int quotaAssociativa, string percorsoCertificati)
        {
            Nome = nome;
            QuotaAssociativa = quotaAssociativa;
            _tesserati = new List<Tesserato>();
            _specialita = new List<Specialita>();
            PercorsoCertificati = percorsoCertificati;
        }
        public Associazione(string nome, int quotaAssociativa, string percorsoCertificati, List<Tesserato> tesserati, List<Specialita> specialita) : this(nome, quotaAssociativa, percorsoCertificati)
        {
            _tesserati = tesserati;
            _specialita = specialita;
        }
        public Associazione()
        {
            
        }
        /// <summary>
        /// Ti restituisce il tesserato che ha l'id dato
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Tesserato con id specificato</returns>
        /// <exception cref="ArgumentNullException"></exception>
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
        /// <summary>
        /// Restituisce tutti i tesserati che implementano IGestioneSpecialità
        /// </summary>
        public List<IGestioneSpecialita> TesseratiConSpecialita
        {
            get
            {
                List<IGestioneSpecialita> specializzati = new List<IGestioneSpecialita>();
                foreach (Tesserato t in _tesserati)
                {
                    if (t is IGestioneSpecialita)
                    {
                        specializzati.Add(t as IGestioneSpecialita);
                    }
                }
                return specializzati;
            }
        }
        /// <summary>
        /// Aggiunge specialità
        /// </summary>
        /// <param name="s"></param>
        /// <exception cref="Exception"></exception>
        public void AggiungiSpecialita(Specialita s)
        {
            if (_specialita.Contains(s)) throw new Exception("specialità gia presente");
            Specialita.Add(s);
        }
        /// <summary>
        /// Restituisce tutti i tesserati che sono atleti
        /// </summary>
        /// <returns>Tesserati che sono atleti, lista vuota se non presenti</returns>
        public List<Atleta> RestituisciAtleti()
        {
            List<Atleta> atleti = new List<Atleta>();
            foreach (Tesserato tesserato in _tesserati)
            {
                if (tesserato is Atleta) atleti.Add(tesserato as Atleta);
            }
            return atleti;
        }
        /// <summary>
        /// Restituisce tutti i tesserati che sono istruttori
        /// </summary>
        /// <returns>Tesserati che sono istruttori, lista vuota se non presenti</returns>
        public List<Istruttore> RestituisciIstruttori()
        {
            List<Istruttore> istruttori = new List<Istruttore>();
            foreach (Tesserato tesserato in _tesserati)
            {
                if (tesserato is Istruttore) istruttori.Add(tesserato as Istruttore);
            }
            return istruttori;
        }
        /// <summary>
        /// Restituisce tutti i tesserati che sono amministratori
        /// </summary>
        /// <returns>Tesserati che sono amministratori, lista vuota se non presenti</returns>
        public List<Amministratore> RestituisciAmministratori()
        {
            List<Amministratore> amministratori = new List<Amministratore>();
            foreach (Tesserato tesserato in _tesserati)
            {
                if (tesserato is Amministratore) amministratori.Add(tesserato as Amministratore);
            }
            return amministratori;
        }
        /// <summary>
        /// Rimuove tesserato
        /// </summary>
        /// <param name="t"></param>
        /// <returns>True se è stato rimosso, false se non è stato trovato o non è stato rimosso</returns>
        public bool RimuoviTesserato(Tesserato t)
        {
            return _tesserati.Remove(t);
        }
        /// <summary>
        /// Aggiunge un tesserato
        /// </summary>
        /// <param name="tesserato"></param>
        /// <exception cref="Exception">Se un tesserato con quell'id esiste già</exception>
        public void AggiungiTesserato(Tesserato tesserato)
        {
            foreach (Tesserato t in _tesserati)
            {
                if (t.Equals(tesserato)) throw new Exception("Tesserato con questo id già presente");
            }
            _tesserati.Add(tesserato);
        }
    }
}