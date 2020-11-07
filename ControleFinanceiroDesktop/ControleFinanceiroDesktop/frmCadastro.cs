using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleFinanceiroDesktop
{
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {

            }
        }

        private bool ValidarCampos()
        {
            bool ret = true;
            string campos = "";
            string senha, rsenha;

            senha = txtSenha.Text.Trim();
            rsenha = txtRSenha.Text.Trim();

            if (txtNome.Text.Trim() == "")
            {
                ret = false;
                campos = "-Nome\n";
            }

            if(txtEmail.Text.Trim() == "")
            {
                ret = false;
                campos += "-Email\n";
            }

            if (txtSenha.Text.Trim() == "")
            {
                ret = false;
                campos += "-Senha\n";
            }
            else if (txtSenha.Text.Length < 6)
            {
                ret = false;
                campos += "A senha deve ter no mínimo 6 dígitos";
            }
            else if(txtSenha.Text.Trim() != txtRSenha.Text.Trim())
            {
                ret = false;
                campos += "As senhas devem coincidir";
            }
            

            if (!ret)
            {
                MessageBox.Show("Preencher o(s) campo(s) abaixo:\n\n" + campos, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            return ret;

        }

 
    }
}
