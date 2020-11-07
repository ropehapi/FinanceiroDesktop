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
            txtCode.Clear();
            CarregarGrid();

            btnExcluir.Visible = false;
            btnSalvar.Text= "Cadastrar"; 
        }
        private bool ValidarCampos()
        {
            bool ret = true;
            string campos = "";

            if (txtNomeCat.Text.Trim() == "")
            {
                ret = false;
                campos = "- Nome";
            }
            if (!ret)
            {
                MessageBox.Show("Preencher o(s) campo(s) obrigatório(s)\n\n" + campos,"Atenção",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            return ret;
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                //OBJ aonde contém o método 
                CategoriaDAO objDao = new CategoriaDAO();
                //objeto que guardara as informações da tela (GET E SET)
                tb_categoria objCategoria = new tb_categoria();

                //pega as informações
                objCategoria.nome_categoria = txtNomeCat.Text.Trim();
                objCategoria.id_usuario = Util.CodigoLogado;

                try
                {
                    if (txtCode.Text == "")
                    {
                        objDao.Create(objCategoria);
                    }
                    else
                    {
                        objCategoria.id_categoria = Convert.ToInt32(txtCode.Text);
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
            grdCats.DataSource = new CategoriaDAO().Select(Util.CodigoLogado);
            //Ocultar colunas indesejadas 
            grdCats.Columns["id_usuario"].Visible = false;
            grdCats.Columns["id_categoria"].Visible = false;
            grdCats.Columns["tb_usuario"].Visible = false;
            grdCats.Columns["tb_movimento"].Visible = false;

            //mudar o header da grid
            grdCats.Columns["nome_categoria"].HeaderText = "Categoria";
        }

        private void grdCats_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(grdCats.RowCount > 0)
            {
                tb_categoria objLinhaClicada = (tb_categoria)grdCats.CurrentRow.DataBoundItem;

                txtCode.Text = objLinhaClicada.id_categoria.ToString();
                txtNomeCat.Text = objLinhaClicada.nome_categoria;

                btnExcluir.Visible = true;
                btnSalvar.Text = "Alterar";


            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja excluir o registro ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int codCategoria = Convert.ToInt32(txtCode.Text);

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
