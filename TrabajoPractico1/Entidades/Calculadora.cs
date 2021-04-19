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

        /// <summary>
        ///     Ejecutar la operacion dada como "operador" entre "num1" y "num2"
        /// </summary>
        /// <param name="num1">Operador de tipo Numero</param>
        /// <param name="num2">Operador de tipo Numero</param>
        /// <param name="operador">La operacion a ejecutar</param>
        /// <returns>Retorna un double como resultado</returns>
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

        /// <summary>
        ///     Valida el operador y lo retorna en un string. De no ser correcto, se retorna "+".
        /// </summary>
        /// <param name="operador">Char que representa una operacion matematica</param>
        /// <returns>Retorna un string con el operador validado</returns>
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
