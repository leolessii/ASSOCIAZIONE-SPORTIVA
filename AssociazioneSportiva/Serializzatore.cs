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
        private string _path;
        public void ScriviAtleta(Atleta atleta,Formato formato)
        {
            if (formato == Formato.Xaml)
            {
                StreamWriter file = new StreamWriter(_path + ".xml",true);
                XmlSerializer serializer;
                serializer = new XmlSerializer(typeof(Atleta));
                serializer.Serialize(file, atleta);
                file.Close();
            }else if (formato == Formato.Json)
            {
                StreamWriter file = new StreamWriter(_path + ".json",true);
                string text = JsonSerializer.Serialize(atleta);
                file.Write(text);
                file.Close();
            }   
        }

        public void ScriviIstruttore(Istruttore istruttore)
        {
            throw new NotImplementedException();
        }

        public void ScriviSpecialita(Specialita specialita)
        {
            throw new NotImplementedException();
        }
    }
}