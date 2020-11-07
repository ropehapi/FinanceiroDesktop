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
                UsuarioDAO objDAO = new UsuarioDAO();
                tb_usuario objUser = new tb_usuario();

                objUser.nome_usuario = txtNome.Text.Trim();
                objUser.email_usuario = txtEmail.Text.Trim();
                objUser.senha_usuario = txtSenha.Text.Trim();
                try
                {
                    objDAO.Create(objUser);
                    EstadoInicial();
                    MessageBox.Show("Cadastro realizado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ocorreu um erro na operação , tente novamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                             
            }
        }

        private bool ValidarCampos()
        {
            bool ret = true;
            string campos = "";

            if (txtNome.Text.Trim() == "")
            {
                ret = false;
                campos = "-Nome\n";
            }

            if (txtEmail.Text.Trim() == "")
            {
                ret = false;
                campos += "-Email\n";
            }
            if (txtSenha.Text.Trim() == "")
            {
                ret = false;
                campos += "-Senha\n";
            }
            if (txtRSenha.Text.Trim() == "")
            {
                ret = false;
                campos += "-Repetir senha";
            }
            if (!ret)
            {
                MessageBox.Show("Preencher o(s) seguinte(s) campo(s):\n\n" + campos, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return ret;
        }

        private void frmCadastro_Load(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void EstadoInicial()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            txtRSenha.Clear();
        }
    }
}
