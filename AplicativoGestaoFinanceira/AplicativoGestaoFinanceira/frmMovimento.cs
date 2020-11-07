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
    public partial class frmMovimento : Form
    {
        public frmMovimento()
        {
            InitializeComponent();
        }

        public void frmMovimento_Load(object sender, EventArgs e)
        {

            ConfigurarCombos();
            CarregarCombos();
            EstadoInicial();

        }

        private void ConfigurarCombos()
        {
            cbCategoria.DisplayMember = "nome_categoria";
            cbCategoria.ValueMember = "id_categoria";

            cbConta.DisplayMember = "nome_banco";
            cbConta.ValueMember = "id_conta";

            cbEmpresa.DisplayMember = "nome_empresa";
            cbEmpresa.ValueMember = "id_empresa";

        }

        private void CarregarCombos()
        {
            CategoriaDAO objDaoCat = new CategoriaDAO();
            EmpresaDAO objDaoEmp = new EmpresaDAO();
            ContaDAO objDaoConta = new ContaDAO();

            List<tb_categoria> lstCats = objDaoCat.Select(Util.CodigoLogado);
            List<tb_empresa> lstEmps = objDaoEmp.Read(Util.CodigoLogado);
            List<tb_conta> lstContas = objDaoConta.Read(Util.CodigoLogado);

            cbCategoria.DataSource = lstCats;
            cbConta.DataSource = lstContas;
            cbEmpresa.DataSource = lstEmps;


        }



        private void EstadoInicial()
        {
            txtCod.Clear();
            txtObservação.Clear();
            txtValor.Clear();
            cbCategoria.SelectedIndex = -1;
            cbConta.SelectedIndex = -1;
            cbEmpresa.SelectedIndex = -1;
            cbTipo.SelectedIndex = -1;


            btnExcluir.Visible = false;
            btnSalvar.Text = "Registrar";

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                MovimentoDAO objDAO = new MovimentoDAO();
                tb_movimento objMovimento = new tb_movimento();

                objMovimento.id_usuario = Util.CodigoLogado;
                objMovimento.data_movimento = dtData.Value.Date;
                objMovimento.tipo_movimento = Convert.ToInt16(cbTipo.SelectedIndex);
                objMovimento.id_categoria = Convert.ToInt32(cbCategoria.SelectedValue);
                objMovimento.obs_movimento = txtObservação.Text.Trim();
                objMovimento.id_empresa = Convert.ToInt32(cbEmpresa.SelectedValue);
                objMovimento.id_conta = Convert.ToInt32(cbConta.SelectedValue);
                objMovimento.valor_movimento = Convert.ToDecimal(txtValor.Text.Trim());

                try
                {
                    objDAO.LancarMov(objMovimento);
                    EstadoInicial();
                    MessageBox.Show("Ação realizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (cbTipo.SelectedIndex == -1)
            {
                ret = false;
                campos = "-Tipo\n";
            }

            if (cbCategoria.SelectedIndex == -1)
            {
                ret = false;
                campos += "-Categoria\n";
            }

            if (cbEmpresa.SelectedIndex == -1)
            {
                ret = false;
                campos += "-Empresa\n";
            }
            if (cbConta.SelectedIndex == -1)
            {
                ret = false;
                campos += "-Conta\n";
            }
            if (txtValor.Text.Trim() == "")
            {
                ret = false;
                campos += "-Valor";
            }
            if (!ret)
            {
                MessageBox.Show("Preencher o(s) seguinte(s) campo(s)\n\n" + campos, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return ret;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir o movimento ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int codMovimento = Convert.ToInt32(txtCod.Text.Trim());

                try
                {
                    new MovimentoDAO().ExcluirMovimento(codMovimento);
                    EstadoInicial();
                    MessageBox.Show("Registro excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Pesquisar();
                }
                
                catch
                {
                    MessageBox.Show("Não foi possível excluir o item , tente novamente mais tarde", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }



        private void grdMovimentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdMovimentos.RowCount > 0)
            {

                MovimentoVO objLinhaVo = (MovimentoVO)grdMovimentos.CurrentRow.DataBoundItem;
                tb_movimento objLinhaClicada = objLinhaVo.objMov;


                txtCod.Text = Convert.ToString(objLinhaClicada.id_movimento);
                txtObservação.Text = objLinhaClicada.obs_movimento;
                txtValor.Text = Convert.ToString(objLinhaClicada.valor_movimento);

                cbCategoria.SelectedValue = objLinhaClicada.id_categoria;
                cbConta.SelectedValue = objLinhaClicada.id_conta;
                cbEmpresa.SelectedValue = objLinhaClicada.id_empresa;
                cbTipo.SelectedIndex = objLinhaClicada.tipo_movimento;

                dtData.Text = Convert.ToString(objLinhaClicada.data_movimento);

                btnExcluir.Visible = true;
                btnSalvar.Visible= false;
            }
        }
        private void Pesquisar()
        {
            MovimentoDAO objDao = new MovimentoDAO();
            List<MovimentoVO> lstFiltrada = objDao.FiltrarMovimento(Util.CodigoLogado, cbFiltrar.SelectedIndex, dtDataInicial.Value.Date, dtDataFinal.Value.Date);
            grdMovimentos.DataSource = lstFiltrada;
            grdMovimentos.Columns["objMov"].Visible = false;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }
    }
}
