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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {

            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmCadastro cad = new frmCadastro();
            cad.ShowDialog();
        }

        private bool ValidarCampos()
        {
            bool ret = true;
            string campos = "";

            if(txtEmail.Text.Trim() == "")
            {
                ret = false;
                campos = "- Email \n";
            }

            if (txtSenha.Text.Trim() == "")
            {
                ret = false;
                campos += "- Senha";
            }

            if (!ret)
            {
                MessageBox.Show("Preencher o(s) campo(s) obrigatório(s)\n\n" + campos, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return ret;
        }
    }
}
