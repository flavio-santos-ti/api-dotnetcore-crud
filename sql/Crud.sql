-- Database PostgreSQL

CREATE DATABASE crud
TEMPLATE=template0
LC_CTYPE="pt_BR.UTF-8"
LC_COLLATE="pt_BR.UTF-8";

-- Pessoa

CREATE TABLE IF NOT EXISTS public.pessoa 
(
	id BIGSERIAL NOT NULL,
	nome CHARACTER VARYING(30) NOT NULL,
	sobrenome CHARACTER VARYING(40),
	dt_nascto TIMESTAMP NOT NULL,
	tipo CHAR(1), -- F = Física, J = Jurídica
	referencia INT NOT NULL,
	dt_inclusao TIMESTAMP NOT NULL,
	dt_alteracao TIMESTAMP NOT NULL,
	CONSTRAINT pk_pessoa PRIMARY KEY(id)
);

-- Usuário

CREATE TABLE IF NOT EXISTS public.usuario
(
	id BIGINT NOT NULL,
	login CHARACTER VARYING(80) NOT NULL,
	senha CHARACTER VARYING(100) NOT NULL, 
	dt_inclusao TIMESTAMP NOT NULL,
	dt_alteracao TIMESTAMP NOT NULL,
	CONSTRAINT pk_usuario PRIMARY KEY(id)
); 


