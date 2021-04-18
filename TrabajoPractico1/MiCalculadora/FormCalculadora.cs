using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entidades;


namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if( MessageBox.Show("Está seguro que desea salir?", 
                                "Confirmación de Salida", 
                                MessageBoxButtons.YesNo, 
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultado = this.lblResultado.Text;

            if( resultado != "" )
            {
                Numero numero = new Numero(resultado);
                resultado = numero.DecimalBinario(resultado);
                this.lblResultado.Text = resultado;
            }
            else
            {
                MessageBox.Show("No hay ningun resultado para convertir.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string resultado = this.lblResultado.Text;

            if( resultado != "" )
            {
                Numero numero = new Numero(resultado);
                resultado = numero.BinarioDecimal(resultado);
                this.lblResultado.Text = resultado;
            }
            else
            {
                MessageBox.Show("No hay ningun resultado para convertir o el numero no está en binario.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string nro1 = this.txtNumero1.Text;
            string nro2 = this.txtNumero2.Text;
            string operador = this.cmbOperador.Text;

            if( nro1 != "" && nro2 != "" )
            {
                double resultado = Operar(nro1, nro2, operador);
                this.lblResultado.Text = resultado.ToString();
            }
            else
            {
                MessageBox.Show("No se puede realizar la operación si no se ingresaron dos operandos.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            
            double resultado = Calculadora.Operar(num1, num2, operador);

            return resultado;
        }
    }
}
