using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssociazioneSportiva
{
    public abstract class TesseratoSpecializzato : Tesserato, IGestioneSpecialita
    {
        private List<StagioneSportiva> _stagioni;
        private CertificatoMedico? _certificatoMedico;

        public TesseratoSpecializzato(string nome, string cognome, string numeroTelefono, DateOnly dataNascita, CertificatoMedico? certificatoMedico, List<StagioneSportiva> stagioni, Tessera tessera) : this(nome, cognome, numeroTelefono, dataNascita, tessera)
        {
            CertificatoMedico = certificatoMedico;
            Stagioni = stagioni;
        }
        public TesseratoSpecializzato(string nome, string cognome, string numeroTelefono, DateOnly dataNascita, Tessera tessera) : base(nome, cognome, numeroTelefono, dataNascita, tessera)
        {
            _certificatoMedico = null;
            _stagioni = new List<StagioneSportiva>();
        }
        public CertificatoMedico? CertificatoMedico
        {
            get { return _certificatoMedico; }
            private set { _certificatoMedico = value; }
        }
        public List<StagioneSportiva> Stagioni
        {
            get { return _stagioni; }
            private set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    for (int j = i + 1; j < value.Count; j++)
                    {
                        if (value[i].Equals(value[j])) throw new Exception("Non possono esserci più stagioni con lo stesso anno");
                    }
                }
                _stagioni = value;
            }
        }

        /// <summary>
        /// Aggiunge una specialità a una determinata stagione
        /// </summary>
        /// <param name="specialita"></param>
        /// <param name="stagione"></param>
        public void AggiungiSpecialita(Specialita specialita, int anno)
        {
            bool found = false;
            foreach (StagioneSportiva s in _stagioni)
            {
                if (s.Anno == anno)
                {
                    s.AggiungiSpecialita(specialita);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                StagioneSportiva nuovaStagione = new StagioneSportiva(anno);
                nuovaStagione.AggiungiSpecialita(specialita);
                _stagioni.Add(nuovaStagione);
            }
        }

        /// <summary>
        /// Restituisce la lista delle specialità in una determinata stagione
        /// </summary>
        /// <param name="anno"></param>
        /// <returns>lLa lista delle specialità in una determinata stagione, lista vuota se non ce ne sono</returns>
        public List<Specialita> GetSpecialitaDiStagione(int anno)
        {
            List<Specialita> res = new List<Specialita>();
            foreach (StagioneSportiva s in _stagioni)
            {
                if (s.Anno == anno)
                {
                    res = s.Specialita;
                    break;
                }
            }
            return res;
        }

        /// <summary>
        /// Rimuove una specialità data stagione
        /// </summary>
        /// <param name="specialita"></param>
        /// <param name="stagione"></param>
        /// <returns>True se la specalità è stata rimossa, False se non è stata trovata o non rimossa</returns>
        public bool RimuoviSpecialita(Specialita specialita, int anno)
        {
            foreach (StagioneSportiva s in _stagioni)
            {
                if (s.Anno == anno)
                {
                    return s.Specialita.Remove(specialita);
                }
            }
            return false;
        }


    }
}
