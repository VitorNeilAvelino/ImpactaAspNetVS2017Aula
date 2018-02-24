using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capitulo02.Fretes
{
    public partial class FretesForm : Form
    {
        public FretesForm()
        {
            InitializeComponent();
        }

        private void CalcularButton_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                Calcular();
            }
        }

        private void Calcular()
        {
            var percentual = 0m;
            var valor = Convert.ToDecimal(valorTextBox.Text);

            //ToDo: exemplificar novo switch do C# 7.
            switch (ufComboBox.Text.ToUpper())
            {
                case "SP":
                    percentual = 0.2m;
                    break;
                case "RJ":
                case "ES":
                    percentual = 0.3m;
                    break;
                case "MG":
                    percentual = 0.35m;
                    break;
                case "AM":
                    percentual = 0.6m;
                    break;
                default:
                    percentual = 0.75m;
                    break;
                case null:

                    break;
            }

            //if (ufComboBox.Text.ToUpper() == "SP")
            //{
            //    percentual = 0.2m;
            //}
            //else if (ufComboBox.Text.ToUpper() == "RJ" || ufComboBox.Text.ToUpper() == "ES")
            //{
            //    percentual = 0.25m;
            //}
            //else
            //{
            //    percentual = 0.75m;
            //}

            percentualTextBox.Text = percentual.ToString("p2");
            totalTextBox.Text = ((1 + percentual) * valor).ToString("c");
        }

        private bool ValidarFormulario()
        {
            //return true;

            if (nomeTextBox.Text == string.Empty)
            {
                MessageBox.Show("O campo Nome é obrigatório.",
              "Validação",
              MessageBoxButtons.OK,
           MessageBoxIcon.Error);

                return false;
            }

            if (valorTextBox.Text == string.Empty)
            {
                MessageBox.Show("O campo Valor é obrigatório.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            else
            {
                try
                {
                    Convert.ToDecimal(valorTextBox.Text);
                }
                catch
                {
                    MessageBox.Show("O campo Valor está com formato inválido.",
                        "Validação",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return false;
                }
            }

            if (ufComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione a UF.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            return true;
        }
    }
}
