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
    public partial class frmEmpresa : Form
    {
        public frmEmpresa()
        {
            InitializeComponent();
        }

        private void frmEmpresa_Load(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void EstadoInicial()
        {
            txtNomeEmpresa.Clear();
            txtEndereco.Clear();
            txtTelefone.Clear();
            txtLinha.Clear();
            CarregarGrid();

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
                EmpresaDAO objDao = new EmpresaDAO();
                tb_empresa objEmpresa = new tb_empresa();

                objEmpresa.id_usuario = Util.CodigoLogado;
                objEmpresa.nome_empresa = txtNomeEmpresa.Text.Trim();
                objEmpresa.telefone_empresa = txtTelefone.Text.Trim();
                objEmpresa.endereco_empresa = txtEndereco.Text.Trim();

                try
                {
                    if (txtLinha.Text.Trim() == "")
                    {
                        objDao.Create(objEmpresa);
                    }
                    else
                    {
                        objEmpresa.id_empresa = Convert.ToInt32(txtLinha.Text);
                        objDao.Update(objEmpresa);
                    }
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

            if (txtNomeEmpresa.Text.Trim() == "")
            {
                ret = false;
                campos = "-Nome da empresa\n";
            }

            if (txtEndereco.Text.Trim() == "")
            {
                ret = false;
                campos += "-Endereço\n";
            }

            if (txtTelefone.Text.Trim() == "")
            {
                ret = false;
                campos += "-Telefone";
            }

            if (!ret)
            {
                MessageBox.Show("Preencher o(s) seguinte(s) campo(s)\n\n" + campos, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return ret;
        }

        private void CarregarGrid()
        {
            grdEmpresas.DataSource = new EmpresaDAO().Read(Util.CodigoLogado);
            //Ocultar colunas indesejadas 
            grdEmpresas.Columns["id_empresa"].Visible = false;
            grdEmpresas.Columns["id_usuario"].Visible = false;
            grdEmpresas.Columns["tb_usuario"].Visible = false;
            grdEmpresas.Columns["tb_movimento"].Visible = false;

            //mudar o header da grid
            grdEmpresas.Columns["nome_empresa"].HeaderText = "Empresa";
            grdEmpresas.Columns["endereco_empresa"].HeaderText = "Endereço";
            grdEmpresas.Columns["telefone_empresa"].HeaderText = "Telefone";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir o registro ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int codEmpresa = Convert.ToInt32(txtLinha.Text.Trim());

                try
                {
                    new EmpresaDAO().Delete(codEmpresa);
                    EstadoInicial();
                    MessageBox.Show("Registro excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {
                    MessageBox.Show("Não foi possível excluir o item , tente novamente mais tarde", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void grdEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(grdEmpresas.RowCount >0)
            {
                tb_empresa objLinhaClicada = (tb_empresa)grdEmpresas.CurrentRow.DataBoundItem;
                txtNomeEmpresa.Text = objLinhaClicada.nome_empresa;
                txtEndereco.Text = objLinhaClicada.endereco_empresa;
                txtTelefone.Text = objLinhaClicada.telefone_empresa;
                txtLinha.Text = Convert.ToString(objLinhaClicada.id_empresa);

                btnExcluir.Visible = true;
                btnSalvar.Text = "Alterar"; 
            }
        }
    }
}
