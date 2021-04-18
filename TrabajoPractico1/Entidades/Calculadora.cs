using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Metodos

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            char operacion = ValidarOperador(operador[0])[0];

            switch ( operacion )
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
            }

            return resultado;
        }

        private static string ValidarOperador(char operador)
        {
            string retorno;

            if( operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                retorno = operador.ToString();
            }
            else
            {
                retorno = "+";
            }

            return retorno;
        }

        #endregion
    }
}
