using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public abstract class Certificato
    {
        private DateOnly _dataEmissione;
        private DateOnly _dataScadenza;
        private string? _path;

        public DateOnly DataEmissione
        {
            get { return _dataEmissione; }
            set { _dataEmissione = value; }
        }
        public DateOnly DataScadenza
        {
            get { return _dataScadenza; }
            set { _dataScadenza = value; }
        }

        public string? Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public Certificato(DateOnly dataEmissione, DateOnly dataScadenza)
        {
            DataEmissione = dataEmissione;
            DataScadenza = dataScadenza;
            Path = null;
        }
        /// <summary>
        /// Carica la foto del certificato e la salva nella cartella apposita
        /// </summary>
        /// <param name="path"></param>
        /// <param name="nome"></param>
        /// <param name="pathSalvataggio"></param>
        public abstract void CaricaFoto(string path, string nome, string pathSalvataggio);
    }
}