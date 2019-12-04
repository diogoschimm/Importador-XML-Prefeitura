
CREATE TABLE [dbo].[NFSE](
	[idNFSe] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[numeroNFSe] [varchar](100) NULL,
	[codigoVerificacao] [varchar](100) NULL,
	[dataEmissao] [datetime] NULL,
	[numeroRPS] [varchar](100) NULL,
	[discriminacao] [varchar](max) NULL,
	[numeroPedido] [varchar](100) NULL,
	[documentoTomador] [varchar](100) NULL,
	[nomeTomador] [varchar](1000) NULL,
	[valorNFSe] [decimal](18, 2) NULL,
	[valorISS] [decimal](18, 2) NULL
)


--//////// Extrações

select	documentoTomador, 
		numeroPedido, 
		convert(char(10), MIN(dataEmissao), 103) DataEmissao, 
		COUNT(*) Qtd, 
		SUM(valorISS) SomaIss, 
		max(valorIss) MinIss 
from nfse 
where dataEmissao >= '01/11/2019' --and dataEmissao <= '30/11/2019 23:59:59'
group by documentoTomador, numeroPedido
having COUNT(*) > 1
order by COUNT(*) desc


select  idNFSe,
		numeroNFSe,
		codigoVerificacao,
		convert(char(10), dataEmissao, 103) dataEmissao,
		numeroRPS,
		discriminacao,
		numeroPedido,
		documentoTomador,
		nomeTomador,
		valorNFSe,
		valorISS 
from nfse 
where dataEmissao >= '01/11/2019' --and dataEmissao <= '30/11/2019 23:59:59'
order by nfse.dataEmissao
