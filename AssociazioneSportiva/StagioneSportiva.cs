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
            get {
                return _anno;
            }
        }
        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            if(!(obj is StagioneSportiva))return false;
            return (obj as StagioneSportiva).Anno == Anno;
        }
    }
}