using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capitulo01.Troco
{
    public partial class TrocoForm : Form
    {
        public TrocoForm()
        {
            InitializeComponent();
        }

        private void calcularButton_Click(object sender, EventArgs e)
        {
            decimal valorCompra = Convert.ToDecimal(valorCompraTextBox.Text);
            decimal valorPago = Convert.ToDecimal(valorPagoTextBox.Text);

            decimal troco = valorPago - valorCompra;

            trocoTextBox.Text = troco.ToString("c");

            //ToDo: refatorar para usar estrutura de repetição

            var moedas = new decimal[6] { 1, 0.5m, 0.25m, 0.10m, 0.05m, 0.01m };

            for (int i = 0; i <= 5; i++)
            {
                var quantidadeMoedas = (int)(troco / moedas[i]);
                troco %= moedas[i];
                moedasListView.Items[i].Text = quantidadeMoedas.ToString();
            }

            //var moedas1 = (int)troco;
            ////troco = troco % 1;
            //troco %= 1;

            //var moedas050 = (int)(troco / 0.5m);
            //troco %= 0.5m;

            //var moedas025 = (int)(troco / 0.25m);
            //troco %= 0.25m;

            //var moedas010 = (int)(troco / 0.1m);
            //troco %= 0.1m;

            //var moedas005 = (int)(troco / 0.05m);
            //troco %= 0.05m;

            //var moedas001 = (int)(troco / 0.01m);
            //troco %= 0.01m;

            ////var moedas001 = (int)troco;

            //moedasListView.Items[0].Text = moedas1.ToString();
            //moedasListView.Items[1].Text = moedas050.ToString();
            //moedasListView.Items[2].Text = moedas025.ToString();
            //moedasListView.Items[3].Text = moedas010.ToString();
            //moedasListView.Items[4].Text = moedas005.ToString();
            //moedasListView.Items[5].Text = moedas001.ToString();
        }
    }
}
