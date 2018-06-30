using System;
using System.Collections.Generic;
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
            var erros = ValidarFormulario();

            if (erros.Count == 0)
            {
                Calcular();
            }
            else
            {
                MessageBox.Show(string.Join(Environment.NewLine, erros),
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Calcular()
        {
            var percentual = 0m;
            var valor = Convert.ToDecimal(valorTextBox.Text);
            var nordeste = new List<string> { "BA", "PE", "AL" };

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
                case var uf when nordeste.Contains(uf):
                    percentual = 0.5m;
                    break;
                case null:
                    throw new NullReferenceException("Texto do combo UF não pode ser nulo.");
                default:
                    percentual = 0.75m;
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

        private List<string> ValidarFormulario()
        {
            var erros = new List<string>();

            if (nomeTextBox.Text == string.Empty)
            {
                erros.Add("O campo Nome é obrigatório.");
            }

            if (valorTextBox.Text == string.Empty)
            {
                erros.Add("O campo Valor é obrigatório.");
            }
            else
            {
                if (!decimal.TryParse(valorTextBox.Text, out decimal valor))
                {
                    erros.Add("O campo Valor está com formato inválido.");
                }
            }

            if (ufComboBox.SelectedIndex == -1)
            {
                erros.Add("Selecione a UF.");
            }

            return erros;
        }
    }
}