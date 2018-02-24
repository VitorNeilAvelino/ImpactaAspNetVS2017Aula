using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capitulo02.Tabuada
{
    public partial class TabuadaForm : Form
    {
        public TabuadaForm()
        {
            InitializeComponent();
        }

        private void tabuadaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b' || e.KeyChar == '\r')
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8 || e.KeyChar == 13)
            {
                if (e.KeyChar == 13 && tabuadaTextBox.Text != string.Empty)
                {
                    Calcular();
                }
            }
            else
            {
                e.KeyChar = '\0';
            }
        }

        private void Calcular()
        {
            var tabuada = Convert.ToInt32(tabuadaTextBox.Text);
            //var tabuadas = int.Parse(tabuadaTextBox.Text);

            for (int i = 0; i <= 10; i++)
            {
                tabuadaListBox.Items.Add($"{tabuada} * {i} = {tabuada * i}");
            }

            tabuadaTextBox.Focus();
            tabuadaTextBox.SelectAll();
        }
    }
}
