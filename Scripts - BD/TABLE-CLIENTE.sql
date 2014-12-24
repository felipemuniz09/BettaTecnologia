create table [dbo].[CLIENTE]
(
	[ID_CLIENTE] int identity(0,1),
	[EMAIL_CLIENTE] nvarchar(100) constraint NN_CLIENTE_EMAIL not null,
	[NOME_CLIENTE] nvarchar(100) constraint NN_CLIENTE_NOME not null,
	[REMOVIDO] int constraint NN_CLIENTE_REMOVIDO not null constraint DF_CLIENTE_REMOVIDO default(0),
	[TELEFONE_CLIENTE] nvarchar(20) constraint NN_CLIENTE_TELEFONE not null,
	[TIPO_CLIENTE] int constraint NN_CLIENTE_TIPO not null,
	constraint PK_CLIENTE_ID primary key (ID_CLIENTE),
	constraint FK_CLIENTE_TPCLIENTE foreign key (TIPO_CLIENTE) references [dbo].[TIPO_CLIENTE](CODIGO)
)
