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
            txtBanco.Clear();
            txtNumeroBanco.Clear();
            txtSaldo.Clear();
            txtLinha.Clear();
            CarregarGrid();

            btnExcluir.Visible = false;
            btnSalvar.Text = "Registrar";
        }

        private void CarregarGrid()
        {
            grdContas.DataSource = new ContaDAO().Read(Util.CodigoLogado);

            grdContas.Columns["id_usuario"].Visible = false;
            grdContas.Columns["id_conta"].Visible = false;
            grdContas.Columns["tb_usuario"].Visible = false;
            grdContas.Columns["tb_movimento"].Visible = false;

            grdContas.Columns["nome_banco"].HeaderText = "Banco";
            grdContas.Columns["numero_conta"].HeaderText = "Número da conta";
            grdContas.Columns["saldo_conta"].HeaderText = "Saldo da conta";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                ContaDAO objDao = new ContaDAO();
                tb_conta objConta = new tb_conta();

                objConta.id_usuario = Util.CodigoLogado;
                objConta.nome_banco = txtBanco.Text.Trim();
                objConta.numero_conta = txtNumeroBanco.Text.Trim();
                objConta.saldo_conta = Convert.ToDecimal(txtSaldo.Text.Trim());

                try
                {
                    if (txtLinha.Text.Trim() == "")
                    {
                        objDao.Create(objConta);
                    }
                    else
                    {
                        objConta.id_conta = Convert.ToInt32(txtLinha.Text.Trim());
                        objDao.Update(objConta);
                    }
                    EstadoInicial();
                    MessageBox.Show("Ação realizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {
                    MessageBox.Show("Ocorreu um erro na operação , tente novamente mais tarde", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarCampos()
        {
            bool ret = true;
            string campos = "";

            if (txtBanco.Text.Trim() == "")
            {
                ret = false;
                campos = "-Banco\n";
            }

            if (txtNumeroBanco.Text.Trim() == "")
            {
                ret = false;
                campos += "-Número do banco\n";
            }

            if (txtSaldo.Text.Trim() == "")
            {
                ret = false;
                campos += "-Saldo";
            }

            if (!ret)
            {
                MessageBox.Show("Preencher o(s) seguinte(s) campo(s)\n\n" + campos, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return ret;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir o registro ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int codConta = Convert.ToInt32(txtLinha.Text);

                try
                {
                    new ContaDAO().Delete(codConta);
                    EstadoInicial();
                    MessageBox.Show("Registro excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Não foi possível excluir o item , tente novamente mais tarde", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void grdCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(grdContas.RowCount > 0)
            {
                tb_conta objLinhaClicada = (tb_conta)grdContas.CurrentRow.DataBoundItem;

                txtBanco.Text = objLinhaClicada.nome_banco;
                txtLinha.Text = Convert.ToString(objLinhaClicada.id_conta);
                txtNumeroBanco.Text = objLinhaClicada.numero_conta;
                txtSaldo.Text = Convert.ToString(objLinhaClicada.saldo_conta);

                btnExcluir.Visible = true;
                btnSalvar.Text = "Alterar";
            }
        }
    }
}
