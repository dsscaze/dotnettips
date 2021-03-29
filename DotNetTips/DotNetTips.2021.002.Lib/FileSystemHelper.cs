using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTips._2021._002.Lib
{
    public static class FileSystemHelper
    {
        public static string[] ListarArquivosPasta(string caminhoPasta)
        {
            //FileInfo f = new FileInfo("");
            //DirectoryInfo d = new DirectoryInfo(caminhoPasta);

            string[] objs = Directory.GetFiles(caminhoPasta);
            return objs;
        }

        public static FileInfo ObterInfosArquivo(string caminhoCompleto)
        {
            FileInfo f = new FileInfo(caminhoCompleto);
            return f;
        }
    }
}
