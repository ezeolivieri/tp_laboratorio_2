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

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            double nro = 0;

            if( double.TryParse(strNumero, out nro) )
            {
                nro = double.Parse(strNumero);
                this.numero = nro;
            }
            else
            {
                this.numero = nro;
            }
        }

        #endregion

        #region Metodos

        public void SetNumero(string strNumero)
        {
            this.numero = ValidarNumero(strNumero);
        }

        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";
            double resultado = 0;

            if( EsBinario(binario) )
            {
                string binarioInvertido = "";
                foreach (char nro in binario)
                {
                    binarioInvertido = nro + binarioInvertido;
                }


                for (int i = 0; i < binarioInvertido.Length; i++)
                {
                    if (binarioInvertido[i] == '1')
                    {
                        resultado += Math.Pow(2, i);
                    }
                }

                retorno = resultado.ToString();
            }

            return retorno;
        }

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

            string binarioInvertido = "";
            foreach (char nro in retorno)
            {
                binarioInvertido = nro + binarioInvertido;
            }
            retorno = binarioInvertido;

            return retorno;
        }

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
