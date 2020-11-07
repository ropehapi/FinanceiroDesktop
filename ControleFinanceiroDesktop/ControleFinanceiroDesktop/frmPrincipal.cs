using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleFinanceiroDesktop
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria cat = new frmCategoria();
            cat.ShowDialog();
        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpresa emp = new frmEmpresa();
            emp.ShowDialog();
        }

        private void contasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContas acc = new frmContas();
            acc.ShowDialog();
        }

        private void movimentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMovimento mov = new frmMovimento();
            mov.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
