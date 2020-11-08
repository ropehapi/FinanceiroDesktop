select nome_usuario,nome_categoria
from tb_categoria
inner join tb_usuario
on tb_categoria.id_usuario = tb_usuario.id_usuario

select nome_usuario,nome_empresa,endereco_empresa,telefone_empresa
from tb_empresa
inner join tb_usuario
on tb_empresa.id_usuario = tb_usuario.id_usuario

select nome_usuario,nome_banco,numero_conta,saldo_conta,email_usuario
from tb_conta
inner join tb_usuario
on tb_conta.id_usuario = tb_usuario.id_usuario

select nome_categoria,nome_empresa,nome_usuario,data_movimento,valor_movimento,email_usuario
from tb_movimento
inner join tb_usuario
on tb_movimento.id_usuario = tb_usuario.id_usuario
inner join tb_categoria
on tb_movimento.id_categoria = tb_categoria.id_categoria
inner join tb_empresa
on tb_movimento.id_empresa = tb_empresa.id_empresa

select nome_categoria,nome_empresa,nome_usuario,data_movimento,valor_movimento,email_usuario
from tb_movimento
inner join tb_usuario
on tb_movimento.id_usuario = tb_usuario.id_usuario
inner join tb_empresa
on tb_movimento.id_empresa = tb_empresa.id_empresa
inner join tb_categoria
on tb_movimento.id_categoria = tb_categoria.id_categoria

