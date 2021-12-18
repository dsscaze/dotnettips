using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppCalculadoraConceitual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicializar();
        }

        private void inicializar()
        {
            txtNumeroDigitado.Text = "0";
            txtResultado.Text = string.Empty;
            txtOperador.Text = string.Empty;
        }

        private void digitarValor(string numero)
        {
            if(txtNumeroDigitado.Text=="0" || !string.IsNullOrEmpty(txtOperador.Text))
            {
                txtNumeroDigitado.Text = numero;
            }
            else
            {
                txtNumeroDigitado.Text += numero;
            }

            numeroDigitado = decimal.Parse(txtNumeroDigitado.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            digitarValor("1");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            digitarValor("2");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            digitarValor("3");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            digitarValor("4");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            digitarValor("5");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            digitarValor("6");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            digitarValor("7");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            digitarValor("8");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            digitarValor("9");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            digitarValor("0");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            inicializar();
        }

        private void calcular()
        {
            if(!string.IsNullOrEmpty(txtOperador.Text))
            {
                switch (txtOperador.Text)
                {
                    case "+":
                        txtResultado.Text = (decimal.Parse(txtResultado.Text) + decimal.Parse(txtNumeroDigitado.Text)).ToString();
                        break;
                    case "-":
                        txtResultado.Text = (decimal.Parse(txtResultado.Text) - decimal.Parse(txtNumeroDigitado.Text)).ToString();
                        break;
                    case "X":
                        txtResultado.Text = (decimal.Parse(txtResultado.Text) * decimal.Parse(txtNumeroDigitado.Text)).ToString();
                        break;
                    case "÷":
                        txtResultado.Text = (decimal.Parse(txtResultado.Text) / decimal.Parse(txtNumeroDigitado.Text)).ToString();
                        break;
                }

            }
        }

        private void executarOperador(string operador)
        {
            if (txtResultado.Text == "")
            {
                txtResultado.Text = txtNumeroDigitado.Text;
            }
            else
            {
                if (numeroDigitado > -1)
                {
                    calcular();
                }
            }

            txtOperador.Text = operador;
            numeroDigitado = -1;
        }

        decimal resultado = 0;
        decimal numeroDigitado = -1;

        private void btnSomar_Click(object sender, EventArgs e)
        {
            executarOperador("+");
        }


        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            executarOperador("-");
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            executarOperador("X");
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            executarOperador("÷");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            digitarValor(",");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calcular();
        }
    }
}
