using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Threading;

namespace ConfrontadorNFSe
{
    public partial class FrmInicial : Form
    {

        private static int stop = 0;
        private static int qtdLog = 0;

        public FrmInicial()
        {
            InitializeComponent();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            this.Limpar();
            new Thread(this.Run).Start();
            //this.Run();
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            stop = 1;
        }

        private void Run()
        {
            this.RegistrarLog("Iniciando processamento");
            try
            {
                if (this.ValidarEntradas())
                    this.ProcessarArquivos();
            }
            catch (Exception ex)
            {
                this.RegistrarLog(ex.Message);
                this.RegistrarLog(ex.StackTrace);
            }
            this.RegistrarLog("Processamento Finalizado");
        }

        private void ProcessarArquivos()
        {
            var lista = this.ObterListaArquivos(this.txtDiretorioXML.Text);
            int total = lista.Count();

            for (int i = 0; i < total; i++)
            {
                if (stop == 1)
                    break;

                var arquivo = lista[i];
                this.RegistrarLog($"{i}/{total} - Processamento arquivo: " + arquivo.Name);
                this.ProcessarArquivo(arquivo);
            }

        }

        private void ProcessarArquivo(FileInfo arquivo)
        {
            using (var sw = new StreamReader(arquivo.FullName))
            {
                var nfse = new NFSeFactory().CriarNFSe(sw.BaseStream);

                var connection = new ConnectionFactory(this.txtStrConexao.Text);
                var repo = new NFSeRepository(connection);
                repo.Salvar(nfse);
            }
        }
         
        private List<FileInfo> ObterListaArquivos(string caminho)
        {
            var lista = new List<FileInfo>();
            foreach (var diretorio in new System.IO.DirectoryInfo(caminho).GetDirectories())
            {
                foreach (var arquivo in diretorio.GetFiles())
                {
                    if (arquivo.Extension == ".xml")
                    {
                        lista.Add(arquivo);
                    }
                }
            }
            return lista;
        }

        private bool ValidarEntradas()
        {
            if (this.txtDiretorioXML.Text == "")
                throw new Exception("Informe o caminho dos arquivos XML");

            if (!System.IO.Directory.Exists(this.txtDiretorioXML.Text))
                throw new Exception("Informe um caminho válido para os arquivos de XML");

            return true;
        }

        private void RegistrarLog(string mensagem)
        {
            qtdLog++;
            if (qtdLog >= 100)
            {
                this.txtLog.Text = "";
                qtdLog = 0;
            }
            this.txtLog.Text = mensagem + Environment.NewLine + this.txtLog.Text;
        }

        private void Limpar()
        {
            this.txtLog.Text = "";
            stop = 0;
            qtdLog = 0;
        }

    }
}
