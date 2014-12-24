create table [dbo].[PEDIDO]
(
	ID_PEDIDO int identity(0,1),
	ID_CLIENTE int constraint NN_PEDIDO_CLIENTE not null,
	DATA_PEDIDO datetime constraint NN_PEDIDO_DATA not null constraint DF_PEDIDO_DATA default(getdate()),
	DESCRICAO_PEDIDO nvarchar(300) constraint NN_PEDIDO_DESCRICAO not null,
	VALOR_PEDIDO float constraint NN_PEDIDO_VALOR not null,
	constraint PK_PEDIDO primary key (ID_PEDIDO),
	constraint FK_PEDIDO_CLIENTE foreign key(ID_CLIENTE) references [dbo].[CLIENTE](ID_CLIENTE)
)
