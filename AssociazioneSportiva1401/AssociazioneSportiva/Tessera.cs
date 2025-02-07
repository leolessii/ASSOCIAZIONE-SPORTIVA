using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AssociazioneSportiva
{
    public class Tessera
    {
        private string _code;
        private DateOnly _dataPrimaIscrizione;
        private DateOnly _rinnovo;
        public string Code
        {
            get { return _code; }
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("");
                _code = value;
            }
        }
        public DateOnly DataPrimaIscrizione
        {
            get { return _dataPrimaIscrizione; }
            private set
            {
                _dataPrimaIscrizione = value;
            }
        }
        public DateOnly Rinnovo
        {
            get { return _rinnovo; }
            private set
            {
                _rinnovo = value;
            }
        }
        public Tessera(string code, DateOnly data, DateOnly rinnovo) : this(code, data)
        {
            Rinnovo = rinnovo;
        }
        public Tessera(string code, DateOnly data)
        {
            Code = code;
            DataPrimaIscrizione = data;
            DateTime dt = DateTime.Now.AddYears(1);
            _rinnovo = DateOnly.FromDateTime(dt);
        }

        public Tessera(string code)
        {
            Code = code;
            DataPrimaIscrizione = DateOnly.FromDateTime(DateTime.Now);
            _rinnovo = DateOnly.FromDateTime(DateTime.Now);
        }
        public Tessera()
        {
        }


    }
}