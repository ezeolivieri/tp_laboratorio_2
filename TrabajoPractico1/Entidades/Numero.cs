using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Constructores

        /// <summary>
        ///     Constructor por defecto, asigna 0 a la propiedad numero
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        ///     Constructor que dado un double, lo asigna a la propiedad numero
        /// </summary>
        /// <param name="numero">Número de tipo double</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        ///     Constructor que dado un string, lo asigna a la propiedad numero 
        ///     (de no ser posible el parseo le asigna 0).
        /// </summary>
        /// <param name="strNumero">dato de tipo string</param>
        public Numero(string strNumero)
        {
            SetNumero(strNumero);
        }

        #endregion

        #region Metodos

        /// <summary>
        ///     Setter de la propiedad numero
        /// </summary>
        /// <param name="strNumero">Dato de tipo string</param>
        public void SetNumero(string strNumero)
        {
            this.numero = ValidarNumero(strNumero);
        }

        /// <summary>
        ///     Método que convierte un numero binario a decimal.
        /// </summary>
        /// <param name="binario">Número binario de tipo string</param>
        /// <returns>Retorna un string con la conversión realizada a decimal.</returns>
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";
            double resultado = 0;

            if( EsBinario(binario) )
            {
                // Invierto el binario recibido
                string binarioInvertido = "";
                foreach (char nro in binario)
                {
                    binarioInvertido = nro + binarioInvertido;
                }

                // Recorro el binario invertido
                for (int i = 0; i < binarioInvertido.Length; i++)
                {
                    // Si encuentro un uno, lo resuelvo
                    if (binarioInvertido[i] == '1')
                    {
                        resultado += Math.Pow(2, i);
                    }
                }

                retorno = resultado.ToString();
            }

            return retorno;
        }

        /// <summary>
        ///     Método que convierte un numero decimal a numero binario
        /// </summary>
        /// <param name="numero">Número de tipo double</param>
        /// <returns>Retorna un string con la conversión realizada a binario.</returns>
        public string DecimalBinario(double numero)
        {
            string retorno = "Valor invalido";
            
            double dividendo = numero;
            double cociente = Math.Floor(dividendo / 2);
            double resto = dividendo % 2;

            StringBuilder cadenaBinaria = new StringBuilder();

            if( numero > 1 )
            {
                while (cociente > 1)
                {
                    cociente = Math.Floor(dividendo / 2);
                    resto = dividendo % 2;

                    cadenaBinaria.Append(resto.ToString());
                    dividendo = cociente;
                }

                cadenaBinaria.Append(cociente.ToString());
            }

            cadenaBinaria.Append(resto.ToString());
            retorno = cadenaBinaria.ToString();

            // Invierto la cadena formada
            string binarioInvertido = "";
            foreach (char nro in retorno)
            {
                binarioInvertido = nro + binarioInvertido;
            }
            retorno = binarioInvertido;

            return retorno;
        }

        /// <summary>
        ///     Método que convierte un numero decimal a numero binario
        /// </summary>
        /// <param name="numero">Número de tipo string</param>
        /// <returns>Retorna un string con la conversión realizada a binario.</returns>
        public string DecimalBinario(string numero)
        {
            string retorno = "Valor invalido";
            double resultado = 0;

            if( double.TryParse(numero, out resultado) )
            {
                resultado = double.Parse(numero);
                retorno = DecimalBinario(resultado);
            }

            return retorno;
        }

        /// <summary>
        ///     Método que evalúa si el string recibido representa un numero binario
        /// </summary>
        /// <param name="binario">Número de tipo string</param>
        /// <returns>Retorna true si "binario" es un numero binario o false en caso contrario</returns>
        private bool EsBinario(string binario)
        {
            bool esNroBinario = true;

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    i = binario.Length;
                    esNroBinario = false;
                }
            }

            return esNroBinario;
        }

        /// <summary>
        ///     Método para validar que el string recibido sea un número
        /// </summary>
        /// <param name="strNumero">Dato de tipo string</param>
        /// <returns>
        ///     Retorna un double resultante del parseo de "strNumero" 
        ///     (en caso de no poder parsear, se retorna 0).
        /// </returns>
        private double ValidarNumero(string strNumero)
        {
            double resultado = 0;

            if( double.TryParse(strNumero, out resultado) )
            {
                resultado = double.Parse(strNumero);
            }

            return resultado;
        }

        #endregion

        #region SobrecargasDeOperadores

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double resultado = 0;

            if( n2.numero == 0 )
            {
                resultado = double.MinValue;
            }
            else
            {
                resultado = n1.numero / n2.numero;
            }

            return resultado;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        #endregion

    }
}
