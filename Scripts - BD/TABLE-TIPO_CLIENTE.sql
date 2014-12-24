create table [dbo].[TIPO_CLIENTE]
(
	[CODIGO] int,
	[DESCRICAO] nvarchar(20) constraint NN_TPCLIENTE_DESCRICAO not null,
	constraint PK_TPCLIENTE_CODIGO primary key (CODIGO)
)
