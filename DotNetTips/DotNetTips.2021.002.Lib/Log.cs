using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTips._2021._002.Lib
{
    public static class Log
    {
        public static void RegistrarLog(string msg)
        {
            SalvarArquivo(msg, @"C:\Users\dssca\Documents\downloads2\output", "log.txt");
        }

        public static void SalvarArquivo(string msg, string nomeArquivo, string caminhoArquivo)
        {
            using (StreamWriter sw = new StreamWriter(caminhoArquivo + @"\" + nomeArquivo, true))
            {
                sw.WriteLine(msg);
            }

        }

        public static string LerArquivo(string caminho)
        {
            using (StreamReader sr = new StreamReader(caminho))
            {
                string s = sr.ReadToEnd();
                return s;
            }
        }
    }
}
