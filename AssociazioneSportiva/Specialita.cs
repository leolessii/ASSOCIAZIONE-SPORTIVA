using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public class Specialita : ISalvabile
    {
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set
            {
                if(string.IsNullOrEmpty(value)) throw new ArgumentNullException("Nome invalido");
                _nome = value;
            }
        }

        public Specialita(string nome)
        {
            Nome = nome;
        }
        public void Save(IOutput interfaccia)
        {
            interfaccia.ScriviSpecialita(this);
        }
    }
}