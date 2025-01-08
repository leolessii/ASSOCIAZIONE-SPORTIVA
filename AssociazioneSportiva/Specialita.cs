using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public class Specialita
    {
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Nome invalido");
                _nome = value;
            }
        }

        public Specialita(string nome)
        {
            Nome = nome;
        }
        public override string ToString()
        {
            return Nome;
        }
        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            if(!obj.GetType().Equals(typeof(Specialita))) return false;
            return (obj as Specialita).Nome == Nome;
        }


    }
}