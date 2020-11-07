using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CategoriaDAO
    {
        public void Create(tb_categoria objCategoria)
        {
            //Crio um obj do banco de dados 
            banco objBanco = new banco();

            //ADD no banco , na tabela categoria o obj de entrada
            objBanco.AddTotb_categoria(objCategoria);

            //Salvar no banco de dados
            objBanco.SaveChanges();
        }

        public List<tb_categoria> Select( int cod_logado)
        {
            banco objBanco = new banco();
            List<tb_categoria> lstCats = objBanco.tb_categoria.Where(cats => cats.id_usuario == cod_logado).ToList();

            return lstCats;
        } 

        public void Update(tb_categoria objCategoria)
        {
            banco objBanco = new banco();

            tb_categoria objResgate = objBanco.tb_categoria.Where(cat => cat.id_categoria == objCategoria.id_categoria).FirstOrDefault();

            objResgate.nome_categoria = objCategoria.nome_categoria;

            objBanco.SaveChanges();
        }

        public void Delete(int id_categoria)
        {
            banco objBanco = new banco();

            tb_categoria objResgate = objBanco.tb_categoria.Where(cat => cat.id_categoria == id_categoria).FirstOrDefault();

            objBanco.DeleteObject(objResgate);

            objBanco.SaveChanges();

        }
    }
}
