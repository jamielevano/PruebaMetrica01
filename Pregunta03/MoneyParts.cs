using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta03
{
    class MoneyParts
    {

        static decimal[] factores = new decimal[] { 0.05m, 0.1m, 0.2m, 0.5m, 1, 2, 5, 10, 20, 50, 100, 200 };
        static void Main(string[] args)
        {

            decimal numero = 15;
            build(numero);
            Console.Read();
        }

        public static string build(decimal nro)
        {
            decimal suma = 0;
            string resultado = "";
            decimal[] menores = factores.Where(x => x <= nro).ToArray();
            CultureInfo cur = new CultureInfo("en-US");

            foreach (decimal men in menores)
            {
                if (esDivisor(nro, men))
                {
                    int param = Convert.ToInt16(nro / men, cur);
                    Console.WriteLine(escribirValor(men.ToString(), param));
                }
                else
                {
                    suma = 0;
                    resultado = "";
                    while (suma < nro)
                    {
                        resultado += men.ToString() + "|";
                        suma += men;
                        conbinarFactores(nro, suma, men, menores, resultado);
                    }
                }
            }
            return "";
        }

        public static void conbinarFactores(decimal val, decimal valAct, decimal nro, decimal[] valores, string cadena)
        {
            decimal suma = valAct;
            string cadenaAux = "";
            string cadenaAux2 = "";
            decimal r = 0;
            bool exite = false;
            while (suma < val)
            {
                suma += nro;
                cadenaAux += nro.ToString() + "|";
                foreach (decimal item in valores)
                {
                    cadenaAux2 += item.ToString() + "|";
                    if (suma + item == val)
                    {
                        r = suma + item;
                        exite = true;
                        break;
                    }
                    else if (suma + item > val)
                    {
                        break;
                    }
                }
                if (exite)
                {
                    Console.WriteLine(cadena + "**" + cadenaAux + "**" + cadenaAux2 + "-->" + r + "-->");
                }
                exite = false;
                cadenaAux2 = "";
                cadenaAux = "";
            }
        }

        public static bool esDivisor(decimal nro, decimal divisor)
        {
            return nro % divisor == 0;
        }

        public static string escribirValor(string valor, int nro)
        {
            string retval = "";
            for (int i = 1; i <= nro; i++)
            {
                retval += valor + "|";
            }
            return retval + "-->";
        }



    }
}
