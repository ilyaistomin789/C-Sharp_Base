using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace OOP_LAB_14
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_14";
            var pineDefault = new Pine(30, 4, "Pine Family", 1567444);
            var pineSibirica = new Pine(44, 500, "Pine Family", 1333657);
            var pineHalepensis = new Pine(20, 2, "Pine Family", 200000);
            var oakPetiolate = new Oak(40, 300, "Fagaceae Family", 3000000);
            var oakDefault = new Oak(30, 40, "Fagaceae Family", 200000);
            var result = new Pine();
            CustomSerializer.XmlSerializer(path,"xml.xml",pineDefault);
            CustomSerializer.BinarySerializer(path,"Sibirica.bin",pineSibirica);
            CustomSerializer.BinaryDeserializer(path,"Sibirica.bin",out result);
            CustomSerializer.JsonSerializer(path,"jsonHalepensis.json",pineHalepensis);
            Console.WriteLine(result);
            string pathDemeshchik = @"D:\Visual Studio 2019\OOP(C#)\OOP_LAB_14\demeshchik.xml";
            XDocument xmlFile = XDocument.Load(pathDemeshchik);
            foreach (var elements in xmlFile.Element("game_dialogs").Elements("dialog").Elements("phrase_list").Elements("phrase"))
            {
                XElement next = elements.Element("next");
                if (next == null)
                {
                    Console.WriteLine(elements.Element("text"));
                }
            }
            XDocument newXElement = new XDocument(new XElement("RootItem",
                new XElement("Item",
                    new XAttribute("Id", "1"),
                    new XElement("Text", "Text Node"),
                    new XElement("Text", "Another text node")),
                new XElement("Item",
                    new XAttribute("Id", "2"),
                    new XElement("Text", "Only one text node"))));
            XDeclaration newXDeclaration = new XDeclaration("1.0","windows-1251","yes");
            newXElement.Declaration = newXDeclaration;
            Console.WriteLine(newXDeclaration);
            Console.WriteLine(newXElement);
            using (StreamWriter sw = new StreamWriter(Path.Combine(path,"MyXML.xml")))
            {
                sw.WriteLine(newXDeclaration);
                sw.WriteLine(newXElement);
                sw.Close();
            }

        }
    }
}
