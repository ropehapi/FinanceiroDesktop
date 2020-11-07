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

namespace ControleFinanceiroDesktop
{
    public partial class frmMovimento : Form
    {
        public frmMovimento()
        {
            InitializeComponent();
        }

       

        private void frmMovimento_Load(object sender, EventArgs e)
        {
            ConfigurarCombos();
            CarregarCombos();
            EstadoInicial();
        }

        public void ConfigurarCombos()
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
            List<tb_empresa> lstEmps = objDaoEmp.Select(Util.CodigoLogado);
            List<tb_conta> lstContas = objDaoConta.Select(Util.CodigoLogado);

            cbCategoria.DataSource = lstCats;
            cbConta.DataSource = lstContas;
            cbEmpresa.DataSource = lstEmps;
        }

        private void EstadoInicial()
        {
            cbConta.SelectedIndex = -1;
            cbCategoria.SelectedIndex = -1;
            cbEmpresa.SelectedIndex = -1;
            cbTipo.SelectedIndex = -1;
            txtCod.Clear();
            txtObs.Clear();
            txtValor.Clear();

            btnExcluir.Visible = false;
            btnRegistrar.Text = "Registrar";
        }

        private bool ValidarCampos()
        {
            bool ret = true;
            string campos = "";

            if(cbCategoria.SelectedIndex == -1)
            {
                ret = false;
                campos = "-Categoria\n";
            }
            if (cbConta.SelectedIndex == -1)
            {
                ret = false;
                campos += "-Conta\n";
            }
            if (cbEmpresa.SelectedIndex == -1)
            {
                ret = false;
                campos += "-Empresa\n";
            }
            if (cbTipo.SelectedIndex == -1)
            {
                ret = false;
                campos += "-Tipo\n";
            }
            if (txtValor.Text.Trim() == "")
            {
                ret = false;
                campos += "-Valor\n";
            }
            if (!ret)
            {
                MessageBox.Show("Preencher o(s) campo(s) obrigatório(s)\n\n" + campos, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return ret;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                MovimentoDAO objDAO = new MovimentoDAO();
                tb_movimento objMov = new tb_movimento();

                objMov.id_usuario = Util.CodigoLogado;
                objMov.data_movimento = dtpData.Value.Date;
                objMov.tipo_movimento = Convert.ToInt16(cbTipo.SelectedIndex);
                objMov.id_categoria = Convert.ToInt32(cbCategoria.SelectedValue);
                objMov.obs_movimento = txtObs.Text.Trim();
                objMov.id_empresa = Convert.ToInt32(cbEmpresa.SelectedValue);
                objMov.id_conta = Convert.ToInt32(cbConta.SelectedValue);
                objMov.valor_movimento = Convert.ToDecimal(txtValor.Text.Trim());

                try
                {
                    objDAO.LancarMov(objMov);
                    EstadoInicial();
                    MessageBox.Show("Ação realizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ocorreu um erro na operação , tente novamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        
        private void Pesquisar()
        {
            MovimentoDAO objDao = new MovimentoDAO();
            List<MovimentoVO> lstFiltrada = objDao.FiltrarMovimento(Util.CodigoLogado, cbFiltrarTipo.SelectedIndex, dtpInicial.Value.Date, dtpFinal.Value.Date);
            grdMovimentos.DataSource = lstFiltrada;
            grdMovimentos.Columns["objMov"].Visible = false;
        }

        

        private void grdMovimentos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (grdMovimentos.RowCount > 0)
            {

                MovimentoVO objLinhaVo = (MovimentoVO)grdMovimentos.CurrentRow.DataBoundItem;
                tb_movimento objLinhaClicada = objLinhaVo.objMov;


                txtCod.Text = Convert.ToString(objLinhaClicada.id_movimento);
                txtObs.Text = objLinhaClicada.obs_movimento;
                txtValor.Text = Convert.ToString(objLinhaClicada.valor_movimento);

                cbCategoria.SelectedValue = objLinhaClicada.id_categoria;
                cbConta.SelectedValue = objLinhaClicada.id_conta;
                cbEmpresa.SelectedValue = objLinhaClicada.id_empresa;
                cbTipo.SelectedIndex = objLinhaClicada.tipo_movimento;

                dtpData.Text = Convert.ToString(objLinhaClicada.data_movimento);

                btnExcluir.Visible = true;
                btnRegistrar.Visible = false;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
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
    }
}
