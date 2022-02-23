using System;
using System.IO;
namespace Tentativa2
{
    internal class Program
    {
        static string[][] _linha = new string[3][]{ new string[10]{" __ ", "    ", " __ ", " __ ",
                "    ", " __ ", " __ ", " __ ", " __ ", " __ "},
            new string[10]{"|  |", "   |", " __|", " __|",
                "|__|", "|__ ", "|__ ", "   |", "|__|", "|__|"},
            new string[10]{"|__|" , "   |" , "|__ " , " __|",
                "   |", " __|",  "|__|", "   |", "|__|", " __|"}};
        static string[] calculaLinha(int linhaAtual, ref string[] linha, ref string[] fila)
        {
            string itera;
            itera = linha[linhaAtual][0].ToString();
            itera += linha[linhaAtual][1];
            itera += linha[linhaAtual][2];
            itera += linha[linhaAtual][3];
            linha[linhaAtual] = linha[linhaAtual].Remove(0, 4);
            for (int i = 0; i < fila.Length; i++)
            {
                if (fila[i] is not null && !fila[i].Equals(itera))
                {
                    fila[i] = null;
                }
                else if (linhaAtual < 2)
                {
                    fila[i] = _linha[linhaAtual + 1][i];
                }
            }
            return fila;
        }
        static void Main(string[] args)
        {
            string numero = @" __      __  __      __  __  __  __  __ 
                              |  |   | __| __||__||__ |__    ||__||__|
                              |__|   ||__  __|   | __||__|   ||__| __|";
            StringReader stringReader = new StringReader(numero);
            string[] linhas = new string[3] { stringReader.ReadLine(), stringReader.ReadLine().Trim(),
            stringReader.ReadLine().Trim() };
            string[] fila;
            int valor;
            for (int i = 0; i < 10; i++)
            {
                fila = _linha[0];
                //Array.ForEach(fila, x=> Console.Write(x));
                //Array.ForEach(_linha[0], x => Console.Write(x));
                calculaLinha(0, ref linhas, ref fila);
                calculaLinha(1, ref linhas, ref fila);
                calculaLinha(2, ref linhas, ref fila);
                valor = Array.IndexOf(fila, Array.Find(fila, x => x is not null));
                Console.Write(valor);
            }
        }
    }
}
