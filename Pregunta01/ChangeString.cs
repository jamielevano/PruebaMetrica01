using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta01
{
    class ChangeString
    {
        static void Main(string[] args)
        {
            build();
        }


        static void build()
        {
            var cadena = Console.ReadLine();
            var resultado = string.Empty;
            int valor = 0;

            for (var i = 0; i < cadena.Length; i++)
            {
                var nchar = Encoding.ASCII.GetBytes(cadena.Substring(i, 1));
                if ((nchar[0] > 64 && nchar[0] < 91) || (nchar[0] > 96 && nchar[0] < 123))
                {
                    valor = nchar[0] + 1;
                    switch (valor)
                    {
                        case 123:
                            valor = 97;
                            break;
                        case 91:
                            valor = 65;
                            break;
                    }
                }
                else
                {
                    valor = nchar[0];
                }

                resultado = resultado + Convert.ToString((char)valor);
            }
            Console.WriteLine(resultado);

            System.Threading.Thread.Sleep(5000);

        }
    }
}
