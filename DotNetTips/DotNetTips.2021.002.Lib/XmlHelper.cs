using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DotNetTips._2021._002.Lib
{
    public static class XmlHelper
    {
        public static void serializarObjeto(Type tipo, object obj, string nomeArquivo, string pathArquivo)
        {
            StringBuilder objSerializado = new StringBuilder();
            var writer = new StringWriter(objSerializado);
            XmlSerializer serializer = new XmlSerializer(tipo);
            serializer.Serialize(writer, obj);

            Log.SalvarArquivo(objSerializado.ToString(), nomeArquivo, pathArquivo);

        }

        public static object deserializarObjeto(Type tipo, string nomeCompleto)
        {
            using (StreamReader xmlStream = new StreamReader(nomeCompleto))
            {
                XmlSerializer serializer = new XmlSerializer(tipo);
                object obj = serializer.Deserialize(xmlStream);
                xmlStream.Close();

                return obj;
            }
        }

    }
}
