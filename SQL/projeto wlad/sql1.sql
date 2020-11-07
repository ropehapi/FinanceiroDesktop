insert into tb_usuario
(nome_usuario, email_usuario, senha_usuario)
values
('User1','user1@gmail.com','111');

insert into tb_usuario
(nome_usuario,email_usuario,senha_usuario)
values
('User2','user2@gmail.com','333');

insert into tb_usuario
(nome_usuario,email_usuario,senha_usuario)
values
('User3','user3@gmail.com','333');

insert into tb_usuario
(nome_usuario,email_usuario,senha_usuario)
values
('User4','user4@gmail.com','444');

insert into tb_usuario
(nome_usuario,email_usuario,senha_usuario)
values
('User5','user5@gmail.com','555');

select * from tb_usuario 

update tb_usuario
set senha_usuario = '222'
where id_usuario = 2

