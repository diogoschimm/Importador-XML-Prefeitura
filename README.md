# Importador.Xml.Prefeitura
Importador XML Prefeitura de Cuiabá-MT (Nota Control)

## Exemplo de Uso de Namespace e XPath com XML

```c#
  public class NFSeFactory
      {
          public NFSe CriarNFSe(Stream stream)
          {
              var xmlDoc = new XPathDocument(stream);
              var navigator = xmlDoc.CreateNavigator();

              var manager = new XmlNamespaceManager(navigator.NameTable);
              manager.AddNamespace("tc", "http://www.issnetonline.com.br/webserviceabrasf/vsd/tipos_complexos.xsd");
              manager.AddNamespace("ts", "http://www.issnetonline.com.br/webserviceabrasf/vsd/tipos_simples.xsd");

              var nodeNumeroNFSe = navigator.SelectSingleNode("//tc:Nfse/tc:InfNfse/tc:Numero", manager);
              var nodeCodigoVerificacao = navigator.SelectSingleNode("//tc:Nfse/tc:InfNfse/tc:CodigoVerificacao", manager);
              var nodeDataEmissao = navigator.SelectSingleNode("//tc:Nfse/tc:InfNfse/tc:DataEmissao", manager);
              var nodeNumeroRPS = navigator.SelectSingleNode("//tc:Nfse/tc:InfNfse/tc:IdentificacaoRps/tc:Numero", manager);
              var nodeDiscriminacao = navigator.SelectSingleNode("//tc:Nfse/tc:InfNfse/tc:Servico/tc:Discriminacao", manager);

              var nodeTomadorCNPJ = navigator.SelectSingleNode("//tc:Nfse/tc:InfNfse/tc:TomadorServico/tc:IdentificacaoTomador/tc:CpfCnpj/tc:Cnpj", manager);
              var nodeTomadorCPF = navigator.SelectSingleNode("//tc:Nfse/tc:InfNfse/tc:TomadorServico/tc:IdentificacaoTomador/tc:CpfCnpj/tc:Cpf", manager);
              var nodeTomadorNome = navigator.SelectSingleNode("//tc:Nfse/tc:InfNfse/tc:TomadorServico/tc:RazaoSocial", manager);

              var nodeValorServico = navigator.SelectSingleNode("//tc:Nfse/tc:InfNfse/tc:Servico/tc:Valores/tc:ValorServicos", manager);
              var nodeValorISS = navigator.SelectSingleNode("//tc:Nfse/tc:InfNfse/tc:Servico/tc:Valores/tc:ValorIss", manager);

              var numeroNFSe = nodeNumeroNFSe.Value;
              var codigoVerificacao = nodeCodigoVerificacao.Value;
              var dataEmissao = nodeDataEmissao.Value;
              var numeroRPS = (nodeNumeroRPS != null ? nodeNumeroRPS.Value : "");
              var discrimincacao = nodeDiscriminacao.Value;

              var pedido = discrimincacao.Substring(0, 17).Replace("Pedido:", "").Trim();

              var cnpj = nodeTomadorCNPJ != null ? nodeTomadorCNPJ.Value : "";
              var cpf = nodeTomadorCPF != null ? nodeTomadorCPF.Value : "";
              var documentoTomador = cnpj == "" ? cpf : cnpj;

              var nomeTomador = nodeTomadorNome.Value;

              var valorServico = nodeValorServico.Value;
              var valorISS = nodeValorISS.Value;

              var nfse = new NFSe();
              nfse.NumeroNFSe = numeroNFSe;
              nfse.CodigoVerificacao = codigoVerificacao;
              nfse.DataEmissao = dataEmissao.ToDateTime();
              nfse.NumeroRPS = numeroRPS;
              nfse.Discriminacao = discrimincacao;
              nfse.NumeroPedido = pedido;
              nfse.DocumentoTomador = documentoTomador;
              nfse.NomeTomador = nomeTomador;
              nfse.ValorNFSe = double.Parse(valorServico.Replace(".",","));
              nfse.ValorISS = double.Parse(valorISS.Replace(".", ","));

              return nfse;
          }
      }
```

## Estrutura de Banco de Dados

```sql
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
```
