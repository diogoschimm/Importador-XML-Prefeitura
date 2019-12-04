namespace ConfrontadorNFSe
{
    partial class FrmInicial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDiretorioXML = new System.Windows.Forms.TextBox();
            this.lblNcDiretorioXML = new System.Windows.Forms.Label();
            this.btnImportar = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnParar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStrConexao = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDiretorioXML
            // 
            this.txtDiretorioXML.Location = new System.Drawing.Point(23, 38);
            this.txtDiretorioXML.Name = "txtDiretorioXML";
            this.txtDiretorioXML.Size = new System.Drawing.Size(663, 20);
            this.txtDiretorioXML.TabIndex = 0;
            this.txtDiretorioXML.Text = "C:\\Users\\Diogo\\Desktop\\Notas Geradas";
            // 
            // lblNcDiretorioXML
            // 
            this.lblNcDiretorioXML.AutoSize = true;
            this.lblNcDiretorioXML.Location = new System.Drawing.Point(23, 19);
            this.lblNcDiretorioXML.Name = "lblNcDiretorioXML";
            this.lblNcDiretorioXML.Size = new System.Drawing.Size(86, 13);
            this.lblNcDiretorioXML.TabIndex = 1;
            this.lblNcDiretorioXML.Text = "Diretorio do XML";
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(692, 38);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(75, 23);
            this.btnImportar.TabIndex = 2;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtLog.ForeColor = System.Drawing.Color.Lime;
            this.txtLog.Location = new System.Drawing.Point(23, 126);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(744, 348);
            this.txtLog.TabIndex = 3;
            // 
            // btnParar
            // 
            this.btnParar.Location = new System.Drawing.Point(23, 490);
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(75, 23);
            this.btnParar.TabIndex = 4;
            this.btnParar.Text = "Parar";
            this.btnParar.UseVisualStyleBackColor = true;
            this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "String de Conexão (Salvar XML)";
            // 
            // txtStrConexao
            // 
            this.txtStrConexao.Location = new System.Drawing.Point(23, 91);
            this.txtStrConexao.Name = "txtStrConexao";
            this.txtStrConexao.Size = new System.Drawing.Size(663, 20);
            this.txtStrConexao.TabIndex = 5;
            this.txtStrConexao.Text = "Data Source=DESKTOP-4BB99RK\\SQL2017;Initial Catalog=BDNFSE;Integrated Security=SS" +
    "PI;";
            // 
            // FrmInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 543);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStrConexao);
            this.Controls.Add(this.btnParar);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.lblNcDiretorioXML);
            this.Controls.Add(this.txtDiretorioXML);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confrontador de NFS-e";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDiretorioXML;
        private System.Windows.Forms.Label lblNcDiretorioXML;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnParar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStrConexao;
    }
}

