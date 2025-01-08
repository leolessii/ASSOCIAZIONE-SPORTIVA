using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace AssociazioneSportiva
{
    public enum Formato
    {
        Xaml,
        Json
    }
    public class Serializzatore : IOutput
    {
        public void ScriviAtleta(Atleta atleta, Formato formato)
        {
            string path = "atleti." + formato.ToString();
            if (formato == Formato.Xaml)
            {
                StreamWriter file = new StreamWriter(path + ".xml", true);
                XmlSerializer serializer;
                serializer = new XmlSerializer(typeof(Atleta));
                serializer.Serialize(file, atleta);
                file.Close();
            }
            else if (formato == Formato.Json)
            {
                StreamWriter file = new StreamWriter(path + ".json", true);
                string text = JsonSerializer.Serialize(atleta);
                file.Write(text);
                file.Close();
            }
        }

        public void ScriviIstruttore(Istruttore istruttore, Formato formato)
        {
            string path = "istruttori." + formato.ToString();
            if (formato == Formato.Xaml)
            {
                StreamWriter file = new StreamWriter(path + ".xml", true);
                XmlSerializer serializer;
                serializer = new XmlSerializer(typeof(Atleta));
                serializer.Serialize(file, istruttore);
                file.Close();
            }
            else if (formato == Formato.Json)
            {
                StreamWriter file = new StreamWriter(path + ".json", true);
                string text = JsonSerializer.Serialize(istruttore);
                file.Write(text);
                file.Close();
            }
        }

        public void ScriviSpecialita(Specialita specialita, Formato formato)
        {
            string path = "specialita." + formato.ToString();
            if (formato == Formato.Xaml)
            {
                StreamWriter file = new StreamWriter(path + ".xml", true);
                XmlSerializer serializer;
                serializer = new XmlSerializer(typeof(Atleta));
                serializer.Serialize(file, specialita);
                file.Close();
            }
            else if (formato == Formato.Json)
            {
                StreamWriter file = new StreamWriter(path + ".json", true);
                string text = JsonSerializer.Serialize(specialita);
                file.Write(text);
                file.Close();
            }
        }
    }
}