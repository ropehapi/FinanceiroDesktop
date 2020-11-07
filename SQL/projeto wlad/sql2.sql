select * from tb_categoria
select * from tb_conta
select * from tb_empresa
select * from tb_movimento


insert into tb_empresa
(id_usuario,nome_empresa,endereco_empresa,telefone_empresa)
values
(1,'empresa 1','rua 1','111111')

insert into tb_conta
(id_usuario,nome_banco,numero_conta,saldo_conta)
values
(1,'banco1','111',1000)

insert into tb_categoria
(id_usuario,nome_categoria)
values
(1,'categoria1')

insert into tb_movimento
(id_usuario,data_movimento,tipo_movimento,obs_movimento,valor_movimento,id_categoria,id_conta,id_empresa)
value
(1,'2020-08-17',0,'obs1',2000,1,1,1)

insert into tb_empresa
(id_usuario,nome_empresa,endereco_empresa,telefone_empresa)
values
(1,'empresa11','endereço11','1111111')

insert into tb_conta
(id_usuario,nome_banco,numero_conta,saldo_conta)
values
(1,'banco11','11111',2000)

insert into tb_categoria
(id_usuario,nome_categoria)
values
(1,'categoria11')

insert into tb_movimento
(id_usuario,data_movimento,tipo_movimento,obs_movimento,valor_movimento,id_categoria,id_conta,id_empresa)
values
(1,'2020-08-11',0,'11111111',3000,2,2,2)

insert into tb_empresa
(id_usuario,nome_empresa,endereco_empresa,telefone_empresa)
values
(1,'empresa111','endereco111','1111111')

insert into tb_conta
(id_usuario,nome_banco,numero_conta,saldo_conta)
values
(1,'banco111','11111',5000)

insert into tb_categoria
(id_usuario,nome_categoria)
values
(1,'categoria111')

delete from tb_empresa
where id_empresa = 4

insert into tb_movimento
(id_usuario,data_movimento,tipo_movimento,obs_movimento,valor_movimento,id_categoria,id_conta,id_empresa)
values
(1,'2020-09-05',1,'obs 111',1000,3,3,3)












