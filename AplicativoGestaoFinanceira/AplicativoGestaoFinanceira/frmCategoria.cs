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
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void EstadoInicial()
        {
            txtNomeCat.Clear();
            txtLinha.Clear();
            CarregarGrid();

            btnExcluir.Visible = false;
            btnSalvar.Text = ("Registrar");
        }

        private bool ValidarCampos()
        {
            bool ret = true;
            string campos = "";

            if (txtNomeCat.Text.Trim() == "")
            {
                ret = false;
                campos = "-Nome da categoria";
            }

            if (!ret)
            {
                MessageBox.Show("Preencher o(s) seguinte(s) campo(s)\n\n"+campos , "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return ret;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                CategoriaDAO objDao = new CategoriaDAO();
                tb_categoria objCategoria = new tb_categoria();

                objCategoria.id_usuario = Util.CodigoLogado;
                objCategoria.nome_categoria = txtNomeCat.Text.Trim();

                try
                {
                    if (txtLinha.Text == "")
                    {
                        objDao.Create(objCategoria);
                    }
                    else
                    {
                        objCategoria.id_categoria = Convert.ToInt32(txtLinha.Text);
                        objDao.Update(objCategoria);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void CarregarGrid()
        {
            grdCategorias.DataSource = new CategoriaDAO().Select(Util.CodigoLogado);

            grdCategorias.Columns["id_usuario"].Visible = false;
            grdCategorias.Columns["id_categoria"].Visible = false;
            grdCategorias.Columns["tb_usuario"].Visible = false;
            grdCategorias.Columns["tb_movimento"].Visible = false;

            grdCategorias.Columns["nome_categoria"].HeaderText = "Categoria";
        }

        private void grdCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(grdCategorias.RowCount > 0)
            {
                tb_categoria objLinhaClicada = (tb_categoria)grdCategorias.CurrentRow.DataBoundItem;

                txtLinha.Text = objLinhaClicada.id_categoria.ToString();
                txtNomeCat.Text = objLinhaClicada.nome_categoria;

                btnExcluir.Visible = true;
                btnSalvar.Text = "Alterar";
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir o registro ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int codCategoria = Convert.ToInt32(txtLinha.Text);

                try
                {
                    new CategoriaDAO().Delete(codCategoria);
                    EstadoInicial();
                    MessageBox.Show("Registro excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {
                    MessageBox.Show("Não foi possível excluir o item , tente novamente mais tarde", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

       
    }
}
