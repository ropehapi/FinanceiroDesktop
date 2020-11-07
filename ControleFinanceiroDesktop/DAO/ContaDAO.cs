using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ContaDAO
    {
        public void Create(tb_conta objConta)
        {
            banco objBanco = new banco();
            objBanco.AddTotb_conta(objConta);
            objBanco.SaveChanges();
        }

        public List<tb_conta> Select(int cod_logado)
        {
            banco objBanco = new banco();
            List<tb_conta> objRetorno = objBanco.tb_conta.Where(conta => conta.id_usuario == cod_logado).ToList();
            return objRetorno;
        }

        public void Update(tb_conta objConta)
        {
            banco objBanco = new banco();
            tb_conta objResgate = objBanco.tb_conta.Where(conta => conta.id_conta == objConta.id_conta).FirstOrDefault();
            objResgate.nome_banco = objConta.nome_banco;
            objResgate.numero_conta = objConta.numero_conta;
            objResgate.saldo_conta = objConta.saldo_conta;
            objBanco.SaveChanges();
        }

        public void Delete(int id_conta)
        {
            banco objBanco = new banco();
            tb_conta objResgate = objBanco.tb_conta.Where(conta => conta.id_conta == id_conta).FirstOrDefault();
            objBanco.DeleteObject(objResgate);
            objBanco.SaveChanges();
        }
    }
}
