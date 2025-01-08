using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public abstract class Tesserato : IComparable<Tesserato>
    {
        private Tessera _tessera;
        private string _nome;
        private string _cognome;
        private string _numeroTelefono;
        private DateOnly _dataNascita;
        public Tesserato(string nome, string cognome, string numeroTelefono, DateOnly dataNascita)
        {
            Nome = nome;
            Cognome = cognome;
            NumeroTelefono = numeroTelefono;
            DataNascita = dataNascita;
            _tessera = new Tessera();
        }
        public Tessera Tessera
        {
            get { return _tessera; }
            private set { _tessera = value; }
        }
        public string Nome
        {
            get { return _nome; }
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("nome è vuoto o null");
                _nome = value;
            }
        }
        public string Cognome
        {
            get { return _cognome; }
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("cognome è vuoto o null");
                _cognome = value;
            }
        }
        public string NumeroTelefono
        {
            get { return _numeroTelefono; }
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("numero di telefono è vuoto o null");
                if (value.Length != 10) throw new ArgumentException("Numero non della lunghezza giusta");
                _numeroTelefono = value;
            }
        }
        public DateOnly DataNascita
        {
            get { return _dataNascita; }
            private set
            {
                _dataNascita = value;
            }
        }

        public int CompareTo(Tesserato? other)
        {
            if (other == null) return -1;
            int res = Cognome.CompareTo(other.Cognome);
            if (res == 0) Nome.CompareTo(other.Nome);
            return res;
        }
        public override string ToString()
        {
            return Nome + " " + Cognome ;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if(!(obj is Tesserato))return false;
            Tesserato t = obj as Tesserato;
            return t.Tessera.Code == Tessera.Code;
        }
        
    }
}