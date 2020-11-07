using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UsuarioDAO
    {

        public tb_usuario ValidarLogin(string email, string senha)
        {
            banco objbanco = new banco();
            tb_usuario objUser = objbanco.tb_usuario.Where(usu => usu.email_usuario == email && usu.senha_usuario == senha).FirstOrDefault();


            return objUser;
            

        }

        public void Create(tb_usuario objUser)
        {
            banco objBanco = new banco();
            objBanco.AddTotb_usuario(objUser);
            objBanco.SaveChanges();
        }


    }
}
