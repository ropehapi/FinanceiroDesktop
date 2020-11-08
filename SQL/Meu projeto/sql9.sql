select nome_usuario,nome_categoria
from tb_categoria
inner join tb_usuario
on tb_categoria.id_usuario = tb_usuario.id_usuario
where nome_usuario like '%u%'

select nome_usuario,nome_categoria
from tb_categoria
inner join tb_usuario
on tb_categoria.id_usuario = tb_usuario.id_usuario
where tb_categoria.id_usuario = 1

select 
nome_categoria,
nome_empresa,
nome_usuario,
data_movimento,
valor_movimento
from tb_movimento
inner join tb_usuario
on tb_movimento.id_usuario = tb_usuario.id_usuario

inner join tb_empresa
on tb_movimento.id_empresa = tb_empresa.id_empresa

inner join tb_categoria
on tb_movimento.id_categoria = tb_categoria.id_categoria

where tipo_movimento = 0

select nome_banco,
numero_conta,
nome_categoria,
nome_empresa,
nome_usuario,
data_movimento,
valor_movimento
from tb_movimento

inner join tb_usuario
on tb_movimento.id_usuario = tb_usuario.id_usuario

inner join tb_conta
on tb_movimento.id_conta = tb_conta.id_conta

inner join tb_categoria
on tb_movimento.id_categoria = tb_categoria.id_categoria

inner join tb_empresa
on tb_movimento.id_empresa = tb_empresa.id_empresa

where tipo_movimento = 0
and tb_movimento.id_usuario in(1,2)




