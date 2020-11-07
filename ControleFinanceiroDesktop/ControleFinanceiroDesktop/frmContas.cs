using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace ControleFinanceiroDesktop
{
    public partial class frmContas : Form
    {
        public frmContas()
        {
            InitializeComponent();
        }

        private void frmContas_Load(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void EstadoInicial()
        {
            txtNomeBanco.Clear();
            txtNrConta.Clear();
            txtSaldo.Clear();
            txtCod.Clear();
            CarregarGrid();

            btnExcluir.Visible = false;
            btnSalvar.Text = "Cadastrar";
        }

        private void CarregarGrid()
        {
            grdContas.DataSource = new ContaDAO().Select(Util.CodigoLogado);

            grdContas.Columns["id_conta"].Visible = false;
            grdContas.Columns["id_usuario"].Visible = false;
            grdContas.Columns["tb_usuario"].Visible = false;
            grdContas.Columns["tb_movimento"].Visible = false;

            grdContas.Columns["nome_banco"].HeaderText = "Banco";
            grdContas.Columns["numero_conta"].HeaderText = "Numero da conta";
            grdContas.Columns["saldo_conta"].HeaderText = "Saldo";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                ContaDAO objDAO = new ContaDAO();
                tb_conta objConta = new tb_conta();

                objConta.nome_banco = txtNomeBanco.Text.Trim();
                objConta.numero_conta = txtNrConta.Text.Trim();
                objConta.saldo_conta = Convert.ToDecimal(txtSaldo.Text.Trim());
                objConta.id_usuario = Util.CodigoLogado;

                try
                {
                    if (txtCod.Text.Trim() == "")
                    {
                        objDAO.Create(objConta);
                     
                    }
                    else
                    {
                        objConta.id_conta = Convert.ToInt32(txtCod.Text);
                        objDAO.Update(objConta);
                        
                    }

                    MessageBox.Show("Ação realizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {
                    MessageBox.Show("Ocorreu um erro na operação , tente novamente mais tarde", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                EstadoInicial();
            }
        }

        private bool ValidarCampos()
        {
            bool ret = true;
            string campos = "";

            if (txtNomeBanco.Text.Trim() == "")
            {
                ret = false;
                campos = "-Nome banco\n";
            }
            if (txtNrConta.Text.Trim() == "")
            {
                ret = false;
                campos += "-Número da conta\n";
            }
            if (txtSaldo.Text.Trim() == "")
            {
                ret = false;
                campos += "-Saldo";
            }
            if (!ret)
            {
                MessageBox.Show("Preencher o(s) campo(s) obrigatório(s)\n\n" + campos, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return ret;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir o registro ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int codigoConta = Convert.ToInt32(txtCod.Text.Trim());

                try
                {

                    new ContaDAO().Delete(codigoConta);
                    EstadoInicial();
                    MessageBox.Show("Registro excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {

                    MessageBox.Show("Não foi possível excluir o item , tente novamente mais tarde", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void grdContas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdContas.RowCount > 0)
            {
                tb_conta objLinhaClicada = (tb_conta)grdContas.CurrentRow.DataBoundItem;

                txtCod.Text = objLinhaClicada.id_conta.ToString();
                txtNomeBanco.Text = objLinhaClicada.nome_banco;
                txtNrConta.Text = Convert.ToString(objLinhaClicada.numero_conta);
                txtSaldo.Text = Convert.ToString(objLinhaClicada.saldo_conta);

                btnExcluir.Visible = true;
                btnSalvar.Text = "Alterar";

            }
        }
    }
}
