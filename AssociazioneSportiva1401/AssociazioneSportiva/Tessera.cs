﻿using System;
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
        private List<DateOnly> _rinnovi;
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
        public List<DateOnly> Rinnovi
        {
            get { return _rinnovi; }
            private set
            {
                _rinnovi = value;
            }
        }
        public Tessera(int code, DateOnly data, List<DateOnly> rinnovi) : this(code, data)
        {
            Rinnovi = rinnovi;
        }
        public Tessera(int code, DateOnly data)
        {
            Code = code;
            DataPrimaIscrizione = data;
            _rinnovi = new List<DateOnly>();
        }
        public Tessera()
        {
        }


    }
}