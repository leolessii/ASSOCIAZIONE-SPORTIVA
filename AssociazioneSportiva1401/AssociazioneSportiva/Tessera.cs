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
        private int _code;
        private DateOnly _dataPrimaIscrizione;
        private DateOnly _rinnovo;
        public int Code
        {
            get { return _code; }
            private set
            {
                if (value <= 0) throw new ArgumentException("");
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
        public Tessera(int code, DateOnly data, DateOnly rinnovo) : this(code, data)
        {
            Rinnovo = rinnovo;
        }
        public Tessera(int code, DateOnly data)
        {
            Code = code;
            DataPrimaIscrizione = data;
            DateTime dt = DateTime.Now.AddYears(1);
            _rinnovo = DateOnly.FromDateTime(dt);
        }

        public Tessera(int code)
        {
            Code = code;
            DataPrimaIscrizione = DateOnly.FromDateTime(DateTime.Now);
            DateTime dt = DateTime.Now.AddYears(1);
            _rinnovo = DateOnly.FromDateTime(dt);
        }
        public Tessera()
        {
        }


    }
}