select * from tb_categoria
select * from tb_conta
select * from tb_empresa
select * from tb_movimento

insert into tb_empresa
(id_usuario,nome_empresa,endereco_empresa,telefone_empresa)
values
(4,'empresa4','endereco2','22')

insert into tb_conta
(id_usuario,nome_banco,numero_conta,saldo_conta)
values
(4,'banco4','444',1000)

insert into tb_categoria
(id_usuario,nome_categoria)
values
(4,'categoria4')

insert into tb_movimento
(id_usuario,data_movimento,tipo_movimento,obs_movimento,valor_movimento,id_categoria,id_conta,id_empresa)
values
(4,'2010-08-17',0,'obs4',1000,4,4,5)

insert into tb_empresa
(id_usuario,nome_empresa,endereco_empresa,telefone_empresa)
values
(4,'empresa44','endereco44','4444')

insert into tb_conta
(id_usuario,nome_banco,numero_conta,saldo_conta)
values
(4,'banco4','4444',5000)

insert into tb_categoria
(id_usuario,nome_categoria)
values
(4,'categoria4')

insert into tb_movimento
(id_usuario,data_movimento,tipo_movimento,obs_movimento,valor_movimento,id_categoria,id_conta,id_empresa)
values
(4,'2010-05-18',1,'4444',1000,5,5,6)

