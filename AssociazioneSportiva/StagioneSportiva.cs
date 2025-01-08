using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociazioneSportiva
{
    public class StagioneSportiva
    {
        private int _anno;
        private List<Specialita> _specialita;
        public int Anno
        {
            get { return _anno; }
            set
            {
                if (value <= 0) throw new ArgumentException("anno sbagliato");
                _anno = value;
            }
        }

        public List<Specialita> Specialita
        {
            get { return _specialita; }
        }

        public StagioneSportiva(int anno)
        {
            Anno = anno;
            _specialita = new List<Specialita>();
        }
        public StagioneSportiva(int anno, List<Specialita> specialita) : this(anno)
        {
            _specialita = specialita;
        }
        public void AggiungiSpecialita(Specialita s)
        {
            _specialita.Add(s);
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is StagioneSportiva)) return false;
            return (obj as StagioneSportiva).Anno == Anno;
        }
    }
}