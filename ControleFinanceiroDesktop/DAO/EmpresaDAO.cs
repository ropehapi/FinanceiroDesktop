using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class EmpresaDAO
    {
        public void Create(tb_empresa objEmpresa)
        {
            banco objBanco = new banco();
            objBanco.AddTotb_empresa(objEmpresa);
            objBanco.SaveChanges();
        }

        public List<tb_empresa> Select(int codLogado)
        {
            banco objBanco = new banco();
            List<tb_empresa> lstEmpresas = objBanco.tb_empresa.Where(empr => empr.id_usuario == codLogado).ToList();
            return lstEmpresas;
        }

        public void Update(tb_empresa objEmpresa)
        {
            banco objBanco = new banco();
            tb_empresa objResgate = objBanco.tb_empresa.Where(empr => empr.id_empresa == objEmpresa.id_empresa).FirstOrDefault();
            objResgate.nome_empresa = objEmpresa.nome_empresa;
            objResgate.endereco_empresa = objEmpresa.endereco_empresa;
            objResgate.telefone_empresa = objEmpresa.telefone_empresa;
            objBanco.SaveChanges();

        }

        public void Delete (int id_empresa)
        {
            banco objBanco = new banco();
            tb_empresa objEmpresa = objBanco.tb_empresa.Where(empr => empr.id_empresa == id_empresa).FirstOrDefault();
            objBanco.DeleteObject(objEmpresa);
            objBanco.SaveChanges();
        }
    }
}
