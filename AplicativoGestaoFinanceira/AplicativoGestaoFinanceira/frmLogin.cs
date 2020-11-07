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
                UsuarioDAO dao = new UsuarioDAO();
                tb_usuario objUser = dao.ValidarLogin(txtEmail.Text.Trim(), txtSenha.Text.Trim());

                if(objUser == null)
                {
                    MessageBox.Show("Usuário não encontrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Util.CodigoLogado = objUser.id_usuario;
                    Util.NomeLogado= objUser.nome_usuario.Split(' ')[0];
                    this.DialogResult = DialogResult.OK;

                }

            }
        }

        private bool ValidarCampos()
        {
            bool ret = true;
            string campos = "";

            if (txtEmail.Text.Trim() == "")
            {
                ret = false;
                campos = "-Email\n";
            }
            if (txtSenha.Text.Trim() == "")
            {
                ret = false;
                campos += "-Senha\n";
            }

            if (!ret)
            {
                MessageBox.Show("Por favor , preencha o(s) seguinte(s) campo(s):\n\n" + campos, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return ret;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmCadastro cad = new frmCadastro();
            cad.ShowDialog();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void EstadoInicial()
        {
            txtEmail.Clear();
            txtSenha.Clear();
        }
    }
}
