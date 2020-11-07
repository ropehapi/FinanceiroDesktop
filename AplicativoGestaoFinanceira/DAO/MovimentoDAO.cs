using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAO
{
    public class MovimentoDAO
    {
        public void LancarMov(tb_movimento objMovimento)
        {
            banco objBanco = new banco();
            objBanco.AddTotb_movimento(objMovimento);

            //Cria um novo processo
            using (TransactionScope tran = new TransactionScope())
            {
                //Salva o obj dentro do banco
                objBanco.SaveChanges();

                tb_conta objContaResgate = objBanco.tb_conta.Where(conta => conta.id_conta == objMovimento.id_conta).FirstOrDefault();


                if (objMovimento.tipo_movimento == 0)
                {
                    objContaResgate.saldo_conta += objMovimento.valor_movimento;
                }
                else
                {
                    objContaResgate.saldo_conta -= objMovimento.valor_movimento;
                }

                //salvar as alterações nos saldos das contas
                objBanco.SaveChanges();

                //se tudo der certo , salva o processo todo de uma vez só
                tran.Complete();
            }

        }

        public List<tb_movimento> Read(int codLogado)
        {
            banco objBanco = new banco();
            List<tb_movimento> lstMovimentos = objBanco.tb_movimento.Where(mov => mov.id_usuario == codLogado).ToList();
            return lstMovimentos;
        }

        public void ExcluirMovimento(int id_movimento)
        {
            banco objBanco = new banco();
            tb_movimento objResgate = objBanco.tb_movimento.Where(mov => mov.id_movimento == id_movimento).FirstOrDefault();
            tb_conta ContaResgate = objBanco.tb_conta.Where(conta => conta.id_conta == objResgate.id_conta).FirstOrDefault();
            decimal valorResarc = objResgate.valor_movimento;

            if (objResgate.tipo_movimento == 0)
            {
                ContaResgate.saldo_conta -= valorResarc;
            }
            else
            {
                ContaResgate.saldo_conta += valorResarc;
            }

            //crio um novo processo unificado
            using (TransactionScope tran = new TransactionScope())
            {
                //salvo contas com os saldos corretos
                objBanco.SaveChanges();

                objBanco.DeleteObject(objResgate);
                //salvo um banco com o obj já excluído
                objBanco.SaveChanges();

                //se o processo não der erro , eu salvo ele todo
                tran.Complete();
            }

        }

        public List<MovimentoVO> FiltrarMovimento(int codLogado, int tipo, DateTime dataInicial, DateTime dataFinal)
        {
            banco objBanco = new banco();
            List<tb_movimento> lstMovimentosFiltrados = new List<tb_movimento>();
            List<MovimentoVO> lstRetorno = new List<MovimentoVO>();

            if (tipo == 2)
            {
                lstMovimentosFiltrados = objBanco.tb_movimento
                                                              .Include("tb_categoria")
                                                              .Include("tb_empresa")
                                                              .Include("tb_conta")
                                                              .Where(
                                                                     mov => mov.id_usuario == codLogado
                                                                  && mov.data_movimento >= dataInicial
                                                                  && mov.data_movimento <= dataFinal
                                                                     ).ToList();
            }
            else
            {
                lstMovimentosFiltrados = objBanco.tb_movimento
                                                              .Include("tb_categoria")
                                                              .Include("tb_empresa")
                                                              .Include("tb_conta")
                                                              .Where(
                                                                     mov => mov.id_usuario == codLogado
                                                                  && mov.tipo_movimento == tipo
                                                                  && mov.data_movimento >= dataInicial
                                                                  && mov.data_movimento <= dataFinal
                                                                     ).ToList();
            }

            for (int i = 0; i < lstMovimentosFiltrados.Count; i++)
            {
                MovimentoVO vo = new MovimentoVO();

                //Propriedades para exibir na GRID
                vo.Categoria = lstMovimentosFiltrados[i].tb_categoria.nome_categoria;
                vo.Conta = lstMovimentosFiltrados[i].tb_conta.nome_banco + " / " + lstMovimentosFiltrados[i].tb_conta.numero_conta;
                vo.Empresa = lstMovimentosFiltrados[i].tb_empresa.nome_empresa;
                vo.Data = lstMovimentosFiltrados[i].data_movimento.ToShortDateString();
                vo.Valor = lstMovimentosFiltrados[i].valor_movimento;
                vo.Tipo = lstMovimentosFiltrados[i].tipo_movimento == 0 ? "Entrada" : "Saída";
                vo.Obs = lstMovimentosFiltrados[i].obs_movimento;

                vo.objMov = lstMovimentosFiltrados[i];

                lstRetorno.Add(vo);
            }

            return lstRetorno;
        }





    }
}
