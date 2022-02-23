using System;
using System.IO;
namespace InterpretadorNumeros
{
    internal class Program
    {
        static string[] base10 = new string[10] {
        " __ \n|  |\n|__|", "    \n   |\n   |", " __ \n __|\n|__ ", " __ \n __|\n __|",
        "    \n|__|\n   |", " __ \n|__ \n __|", " __ \n|__ \n|__|", " __ \n   |\n   |",
        " __ \n|__|\n|__|", " __ \n|__|\n __|"};
        static string separaNumero(ref string[] linhas)
        {
            string numeroAtual = "";
            numeroAtual += linhas[0].Substring(0, 4) + "\n";
            numeroAtual += linhas[1].Substring(0, 4) + "\n";
            numeroAtual += linhas[2].Substring(0, 4);

            linhas[0] = linhas[0].Remove(0, 4);
            linhas[1] = linhas[1].Remove(0, 4);
            linhas[2] = linhas[2].Remove(0, 4);
            return numeroAtual;
        }
        static string[] removeEspaços(ref StringReader leitor, ref string numeros)
        {
            int tamanho = 1;
            foreach (char x in numeros)
            {
                if (x == '\n')
                    tamanho++;
            }
            string[] copia = new string[tamanho];
            int i = 0;
            while (i < tamanho)
            {
                if (i == 0 || i % 4 != 0)
                {
                    copia[i] = leitor.ReadLine();
                    copia[i] = copia[i].Substring(copia[i].Length - 40, 40);
                }
                i++;
            }
            return copia;
        }
        static void Main(string[] args)
        {
            string numero = @" __      __  __      __  __  __  __  __ 
                              |  |   | __| __||__||__ |__    ||__||__|
                              |__|   ||__  __|   | __||__|   ||__| __|";
            /*       30 espaços       */
            StringReader stringReader = new StringReader(numero);
            string[] linhas = removeEspaços(ref stringReader, ref numero);
            string numeroAtual;
            int iterador = 0;
            int linha = 0;
            while (linha <= linhas.Length)
            {
                numeroAtual = separaNumero(ref linhas);
                Console.Write(Array.IndexOf(base10, numeroAtual));
                iterador += 4;
                if (iterador >= linhas[0].Length)
                {
                    iterador = 0;
                    linha++;
                }
            }
        }
    }
}
