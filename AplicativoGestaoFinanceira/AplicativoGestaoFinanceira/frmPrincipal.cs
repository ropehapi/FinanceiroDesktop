using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace AplicativoGestaoFinanceira
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnCat_Click(object sender, EventArgs e)
        {
            frmCategoria cat = new frmCategoria();
            cat.ShowDialog();
        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            frmEmpresa emp = new frmEmpresa();
            emp.ShowDialog();
        }

        private void btnConta_Click(object sender, EventArgs e)
        {
            frmContas conta = new frmContas();
            conta.ShowDialog();
        }

        private void btnMov_Click(object sender, EventArgs e)
        {
            frmMovimento mov = new frmMovimento();
            mov.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblUser.Text = Util.NomeLogado;
        }
    }
}
