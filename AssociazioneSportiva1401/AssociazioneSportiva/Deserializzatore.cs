using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace AssociazioneSportiva
{
    public class Deserializzatore : IInput
    {
        public List<Atleta>? LeggiAtleti()
        {
            if (File.Exists("atleti.xml"))
            {
                string text;
                StreamReader sr = new StreamReader("Atleti.xml");
                XmlSerializer xmls = new XmlSerializer(typeof(Atleta));
                List<Atleta> dati = (List<Atleta>)xmls.Deserialize(sr)!;
                return dati;
            }
            else if(File.Exists("atleti.json"))
            {
                string text;
                StreamReader sr = new StreamReader("atleti.json");
                text = sr.ReadToEnd();
                sr.Close();
                List<Atleta>? dati = JsonSerializer.Deserialize<List<Atleta>>(text);
                return dati;
            }
            return null;
        }

        public List<Istruttore> LeggiIstruttori(string path)
        {
            throw new NotImplementedException();
        }

        public List<Specialita> LeggiSpecialita(string path)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Legge la associazione dal file delle impostazioni
        /// </summary>
        /// <returns>L'associazione se le impostazioni sono presenti e corrette, null se il file non è presente</returns>
        public Associazione? LeggiAssociazione()
        {
            if (File.Exists("impostazioni.json"))
            {
                string text;
                StreamReader sr = new StreamReader("impostazioni.json"); text = sr.ReadToEnd(); sr.Close();
                List<string>? dati = JsonSerializer.Deserialize<List<string>>(text);
                return new Associazione(dati[0], Convert.ToInt32(dati[1]), dati[2]);
            }
            return null;
        }
    }
}