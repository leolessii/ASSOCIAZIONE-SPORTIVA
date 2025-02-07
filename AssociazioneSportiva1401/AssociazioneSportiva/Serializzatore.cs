using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml;
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
        public void InviaDatiAtleti(Associazione associazione)
        {
            string path = "Atleti.xml";

            XmlDocument doc = new XmlDocument();
            XmlDeclaration decl = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(decl);

            XmlElement root = doc.CreateElement("associazione");
            root.SetAttribute("nome", associazione.Nome);
            doc.AppendChild(root);

            foreach (Atleta a in associazione.RestituisciAtleti())
            {
                XmlElement Atleta = doc.CreateElement("Atleta");
                Atleta.SetAttribute("IdTessera", a.Tessera.Code.ToString());
                root.AppendChild(Atleta);

                XmlElement nome = doc.CreateElement("Nome");
                nome.InnerText = a.Nome;
                Atleta.AppendChild(nome);

                XmlElement cognome = doc.CreateElement("Cognome");
                cognome.InnerText = a.Cognome;
                Atleta.AppendChild(cognome);

                XmlElement DataNascita = doc.CreateElement("Data_Nascita");
                DataNascita.InnerText = a.DataNascita.ToString();
                Atleta.AppendChild(DataNascita);

                XmlElement DataRinnovo = doc.CreateElement("Data_Rinnovo");
                DataRinnovo.InnerText = a.Tessera.Rinnovo.ToString();
                Atleta.AppendChild(DataRinnovo);
            }

            doc.Save("Atleti.xml");
        }
        public void ScriviAtleti(Formato formato, Atleta a)
        {
            string path = "atleti";
            if (formato == Formato.Xaml)
            {
                StreamWriter file = new StreamWriter(path + ".xml", true);
                XmlSerializer serializer;
                serializer = new XmlSerializer(typeof(Atleta));
                serializer.Serialize(file, a);
                file.Close();
            }
            else if (formato == Formato.Json)
            {
                StreamWriter file = new StreamWriter(path + ".json", true);
                string text = JsonSerializer.Serialize(a);
                file.Write(text);
                file.Close();
            }
        }

        public void ScriviIstruttore(Formato formato, Istruttore i)
        {
            string path = "istruttori";
            if (formato == Formato.Xaml)
            {
                StreamWriter file = new StreamWriter(path + ".xml", true);
                XmlSerializer serializer;
                serializer = new XmlSerializer(typeof(Atleta));
                serializer.Serialize(file, i);
                file.Close();
            }
            else if (formato == Formato.Json)
            {
                StreamWriter file = new StreamWriter(path + ".json", true);
                string text = JsonSerializer.Serialize(i);
                file.Write(text);
                file.Close();
            }
        }

        public void ScriviSpecialita(Formato formato, Specialita s)
        {
            string path = "specialita";
            if (formato == Formato.Xaml)
            {
                StreamWriter file = new StreamWriter(path + ".xml", true);
                XmlSerializer serializer;
                serializer = new XmlSerializer(typeof(Atleta));
                serializer.Serialize(file, s);
                file.Close();
            }
            else if (formato == Formato.Json)
            {
                StreamWriter file = new StreamWriter(path + ".json", true);
                string text = JsonSerializer.Serialize(s);
                file.Write(text);
                file.Close();
            }
        }
        /// <summary>
        /// Sccrive le impostazioni nel file .json, se non esiste lo crea
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="quota"></param>
        /// <param name="pathCertificati"></param>
        public void ScriviImpostazioni(string nome, int quota, string pathCertificati)
        {
            if (!File.Exists("impostazioni.json"))
            {
                var file = File.Create("impostazioni.json");
                file.Close();
            }
            string text = JsonSerializer.Serialize(new List<string>() { nome, quota.ToString(), pathCertificati });
            StreamWriter sw = new StreamWriter("impostazioni.json"); sw.Write(text); sw.Close();
        }
    }
}