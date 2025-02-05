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
        public void ScriviAtleti(Formato formato, Associazione associazione)
        {
            string path = "atleti" + formato.ToString();
            if (formato == Formato.Xaml)
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration decl = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(decl);

                XmlElement root = doc.CreateElement("associazione");
                root.SetAttribute("nome", associazione.Nome);
                doc.AppendChild(root);

                foreach(Atleta a in associazione.RestituisciAtleti())
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
            else if (formato == Formato.Json)
            {
                StreamWriter file = new StreamWriter(path + ".json", true);
                string text = JsonSerializer.Serialize(associazione.RestituisciAtleti());
                file.Write(text);
                file.Close();
            }
        }

        public void ScriviIstruttore(Istruttore istruttore, Formato formato)
        {
            string path = "istruttori" + formato.ToString();
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
            string path = "specialita" + formato.ToString();
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