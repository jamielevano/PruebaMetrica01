using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta02
{
    class OrderRange
    {
        static int[] valores = new int[] { 58, 60, 55, 48, 57, 73 };
        static void Main(string[] args)
        {
            build(valores);
        }

        public static void build(int[] numeros)
        {
            CultureInfo cur = new CultureInfo("en-US");
            string[] listanumeros = new string[numeros.Length];

            List<int> nrosPares = new List<int>();
            List<int> nrosImpares = new List<int>();

            foreach (int nro in valores)
            {
                if (nro % 2 == 0)
                    nrosPares.Add(nro);
                else
                    nrosImpares.Add(nro);
            }

            nrosPares.Sort();
            nrosImpares.Sort();

            string resultPares = "Pares: " + string.Join(",", nrosPares);
            string resultImpares = "Impares: " + string.Join(",", nrosImpares);


            Console.WriteLine(resultPares);
            Console.WriteLine(resultImpares);

            System.Threading.Thread.Sleep(5000);


        }
    }
}
