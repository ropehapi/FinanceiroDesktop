select * from tb_usuario
select * from tb_empresa
select * from tb_conta
select * from tb_categoria
select * from tb_movimento

insert into tb_empresa
(id_usuario,nome_empresa,endereco_empresa,telefone_empresa)
values
(2,'empresa2','endereço2','222')

insert into tb_conta
(id_usuario,nome_banco,numero_conta,saldo_conta)
values
(2,'banco2','222',1000)

insert into tb_categoria
(id_usuario,nome_categoria)
values
(2,'categoria2')

insert into tb_movimento
(id_usuario,data_movimento,tipo_movimento,obs_movimento,valor_movimento,id_categoria,id_conta,id_empresa)
values
(2,'2010-08-18',0,'222',1000,11,11,12)

insert into tb_empresa
(id_usuario,nome_empresa,endereco_empresa,telefone_empresa)
values
(2,'empresa22','endereço22','222222')

insert into tb_conta
(id_usuario,nome_banco,numero_conta,saldo_conta)
value
(2,'banco22','222',1000)

insert into tb_categoria
(id_usuario,nome_categoria)
values
(2,'categoria22')

insert into tb_movimento
(id_usuario,data_movimento,tipo_movimento,obs_movimento,valor_movimento,id_categoria,id_conta,id_empresa)
values
(2,'2015-11-15',0,'obs222',1000,11,11,12)

insert into tb_empresa
(id_usuario,nome_empresa,endereco_empresa,telefone_empresa)
values
(2,'empresa222','endereço222','2222222')

insert into tb_conta
(id_usuario,nome_banco,numero_conta,saldo_conta)
values
(2,'banco222','22222',1000)

insert into tb_categoria
(id_usuario,nome_categoria)
values
(2,'categoria222')

insert into tb_movimento
(id_usuario,data_movimento,tipo_movimento,obs_movimento,valor_movimento,id_categoria,id_conta,id_empresa)
values
(2,'2015-12-18',1,'obs222',1000,12,12,13)

insert into tb_empresa
(id_usuario,nome_empresa,endereco_empresa,telefone_empresa)
values
(2,'empresa222','endereço222','222222')

insert into tb_conta
(id_usuario,nome_banco,numero_conta,saldo_conta)
values
(2,'banco222','222',1000)

insert into tb_categoria
(id_usuario,nome_categoria)
values
(2,'categoria222')

insert into tb_movimento
(id_usuario,data_movimento,tipo_movimento,obs_movimento,valor_movimento,id_categoria,id_conta,id_empresa)
values
(2,'2020-08-02',1,'obs222',1000,13,13,14)
