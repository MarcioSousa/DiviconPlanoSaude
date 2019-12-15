namespace Projeto
{
    partial class frm_Principal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Principal));
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.btnPlanoSaude = new System.Windows.Forms.Button();
            this.stsStatusPrincipal = new System.Windows.Forms.StatusStrip();
            this.lblVersão = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsVendedor = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsPlanoSaude = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsEmpresa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPlanosSaude = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsCadastrar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVerificacao = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsGrafico = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSobre = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEmpresa = new System.Windows.Forms.Button();
            this.btnPlanoCliente = new System.Windows.Forms.Button();
            this.btnGraficos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.stsStatusPrincipal.SuspendLayout();
            this.menuPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCliente
            // 
            this.btnCliente.AutoSize = true;
            this.btnCliente.BackColor = System.Drawing.SystemColors.Control;
            this.btnCliente.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnCliente.Image")));
            this.btnCliente.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCliente.Location = new System.Drawing.Point(12, 27);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(72, 93);
            this.btnCliente.TabIndex = 0;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnCliente, "Clientes");
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.BackColor = System.Drawing.SystemColors.Control;
            this.btnFornecedor.Image = ((System.Drawing.Image)(resources.GetObject("btnFornecedor.Image")));
            this.btnFornecedor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFornecedor.Location = new System.Drawing.Point(90, 27);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.Size = new System.Drawing.Size(72, 93);
            this.btnFornecedor.TabIndex = 1;
            this.btnFornecedor.Text = "Vendedor";
            this.btnFornecedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnFornecedor, "Vendedores");
            this.btnFornecedor.UseVisualStyleBackColor = false;
            this.btnFornecedor.Click += new System.EventHandler(this.btnFornecedor_Click);
            // 
            // btnPlanoSaude
            // 
            this.btnPlanoSaude.BackColor = System.Drawing.SystemColors.Control;
            this.btnPlanoSaude.Image = ((System.Drawing.Image)(resources.GetObject("btnPlanoSaude.Image")));
            this.btnPlanoSaude.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPlanoSaude.Location = new System.Drawing.Point(246, 27);
            this.btnPlanoSaude.Name = "btnPlanoSaude";
            this.btnPlanoSaude.Size = new System.Drawing.Size(72, 93);
            this.btnPlanoSaude.TabIndex = 2;
            this.btnPlanoSaude.Text = "Planos Saúde";
            this.btnPlanoSaude.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnPlanoSaude, "Planos de Saúde");
            this.btnPlanoSaude.UseVisualStyleBackColor = false;
            this.btnPlanoSaude.Click += new System.EventHandler(this.btnPlanoSaude_Click);
            // 
            // stsStatusPrincipal
            // 
            this.stsStatusPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblVersão});
            this.stsStatusPrincipal.Location = new System.Drawing.Point(0, 707);
            this.stsStatusPrincipal.Name = "stsStatusPrincipal";
            this.stsStatusPrincipal.Size = new System.Drawing.Size(1008, 22);
            this.stsStatusPrincipal.TabIndex = 4;
            this.stsStatusPrincipal.Text = "statusStrip1";
            // 
            // lblVersão
            // 
            this.lblVersão.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblVersão.Name = "lblVersão";
            this.lblVersão.Size = new System.Drawing.Size(59, 17);
            this.lblVersão.Text = "Versão 1.0";
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastro,
            this.menuPlanosSaude,
            this.menuVerificacao,
            this.menuSobre,
            this.menuSair});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1008, 24);
            this.menuPrincipal.TabIndex = 6;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // menuCadastro
            // 
            this.menuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtsCliente,
            this.mtsVendedor,
            this.mtsPlanoSaude,
            this.mtsEmpresa,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
            this.menuCadastro.Name = "menuCadastro";
            this.menuCadastro.Size = new System.Drawing.Size(66, 20);
            this.menuCadastro.Text = "Cadastro";
            // 
            // mtsCliente
            // 
            this.mtsCliente.Image = ((System.Drawing.Image)(resources.GetObject("mtsCliente.Image")));
            this.mtsCliente.Name = "mtsCliente";
            this.mtsCliente.Size = new System.Drawing.Size(160, 22);
            this.mtsCliente.Text = "Cliente";
            this.mtsCliente.Click += new System.EventHandler(this.mtsCliente_Click);
            // 
            // mtsVendedor
            // 
            this.mtsVendedor.Image = ((System.Drawing.Image)(resources.GetObject("mtsVendedor.Image")));
            this.mtsVendedor.Name = "mtsVendedor";
            this.mtsVendedor.Size = new System.Drawing.Size(160, 22);
            this.mtsVendedor.Text = "Vendedor";
            this.mtsVendedor.Click += new System.EventHandler(this.mtsVendedor_Click);
            // 
            // mtsPlanoSaude
            // 
            this.mtsPlanoSaude.Image = ((System.Drawing.Image)(resources.GetObject("mtsPlanoSaude.Image")));
            this.mtsPlanoSaude.Name = "mtsPlanoSaude";
            this.mtsPlanoSaude.Size = new System.Drawing.Size(160, 22);
            this.mtsPlanoSaude.Text = "Planos de Saúde";
            this.mtsPlanoSaude.Click += new System.EventHandler(this.mtsPlanoSaude_Click);
            // 
            // mtsEmpresa
            // 
            this.mtsEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("mtsEmpresa.Image")));
            this.mtsEmpresa.Name = "mtsEmpresa";
            this.mtsEmpresa.Size = new System.Drawing.Size(160, 22);
            this.mtsEmpresa.Text = "Empresa";
            this.mtsEmpresa.Click += new System.EventHandler(this.mtsEmpresa_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sairToolStripMenuItem.Image")));
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // menuPlanosSaude
            // 
            this.menuPlanosSaude.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtsCadastrar});
            this.menuPlanosSaude.Name = "menuPlanosSaude";
            this.menuPlanosSaude.Size = new System.Drawing.Size(51, 20);
            this.menuPlanosSaude.Text = "Venda";
            // 
            // mtsCadastrar
            // 
            this.mtsCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("mtsCadastrar.Image")));
            this.mtsCadastrar.Name = "mtsCadastrar";
            this.mtsCadastrar.Size = new System.Drawing.Size(155, 22);
            this.mtsCadastrar.Text = "Plano de Saúde";
            this.mtsCadastrar.Click += new System.EventHandler(this.mensalidadeToolStripMenuItem_Click);
            // 
            // menuVerificacao
            // 
            this.menuVerificacao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtsGrafico});
            this.menuVerificacao.Name = "menuVerificacao";
            this.menuVerificacao.Size = new System.Drawing.Size(76, 20);
            this.menuVerificacao.Text = "Verificação";
            // 
            // mtsGrafico
            // 
            this.mtsGrafico.Image = ((System.Drawing.Image)(resources.GetObject("mtsGrafico.Image")));
            this.mtsGrafico.Name = "mtsGrafico";
            this.mtsGrafico.Size = new System.Drawing.Size(152, 22);
            this.mtsGrafico.Text = "Gráfico";
            this.mtsGrafico.Click += new System.EventHandler(this.mtsGrafico_Click);
            // 
            // menuSobre
            // 
            this.menuSobre.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtsSistema});
            this.menuSobre.Name = "menuSobre";
            this.menuSobre.Size = new System.Drawing.Size(49, 20);
            this.menuSobre.Text = "Sobre";
            // 
            // mtsSistema
            // 
            this.mtsSistema.Image = ((System.Drawing.Image)(resources.GetObject("mtsSistema.Image")));
            this.mtsSistema.Name = "mtsSistema";
            this.mtsSistema.Size = new System.Drawing.Size(152, 22);
            this.mtsSistema.Text = "Sistema";
            this.mtsSistema.Click += new System.EventHandler(this.mtsSistema_Click);
            // 
            // menuSair
            // 
            this.menuSair.Name = "menuSair";
            this.menuSair.Size = new System.Drawing.Size(38, 20);
            this.menuSair.Text = "Sair";
            this.menuSair.Click += new System.EventHandler(this.menuSair_Click);
            // 
            // btnEmpresa
            // 
            this.btnEmpresa.BackColor = System.Drawing.SystemColors.Control;
            this.btnEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("btnEmpresa.Image")));
            this.btnEmpresa.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEmpresa.Location = new System.Drawing.Point(168, 27);
            this.btnEmpresa.Name = "btnEmpresa";
            this.btnEmpresa.Size = new System.Drawing.Size(72, 93);
            this.btnEmpresa.TabIndex = 7;
            this.btnEmpresa.Text = "Empresa";
            this.btnEmpresa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnEmpresa, "Empresa");
            this.btnEmpresa.UseVisualStyleBackColor = false;
            this.btnEmpresa.Click += new System.EventHandler(this.btnEmpresa_Click);
            // 
            // btnPlanoCliente
            // 
            this.btnPlanoCliente.BackColor = System.Drawing.SystemColors.Control;
            this.btnPlanoCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnPlanoCliente.Image")));
            this.btnPlanoCliente.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPlanoCliente.Location = new System.Drawing.Point(346, 27);
            this.btnPlanoCliente.Name = "btnPlanoCliente";
            this.btnPlanoCliente.Size = new System.Drawing.Size(72, 93);
            this.btnPlanoCliente.TabIndex = 9;
            this.btnPlanoCliente.Text = "Plano Cliente";
            this.btnPlanoCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnPlanoCliente, "Cadastra Plano de Saúde ao Cliente com seu Respectivo Vendedor");
            this.btnPlanoCliente.UseVisualStyleBackColor = false;
            this.btnPlanoCliente.Click += new System.EventHandler(this.btnPlanoCliente_Click);
            // 
            // btnGraficos
            // 
            this.btnGraficos.AutoSize = true;
            this.btnGraficos.BackColor = System.Drawing.SystemColors.Control;
            this.btnGraficos.Image = ((System.Drawing.Image)(resources.GetObject("btnGraficos.Image")));
            this.btnGraficos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGraficos.Location = new System.Drawing.Point(424, 27);
            this.btnGraficos.Name = "btnGraficos";
            this.btnGraficos.Size = new System.Drawing.Size(72, 93);
            this.btnGraficos.TabIndex = 10;
            this.btnGraficos.Text = "Gráficos";
            this.btnGraficos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnGraficos, "Gráfico de Vendas");
            this.btnGraficos.UseVisualStyleBackColor = false;
            this.btnGraficos.Click += new System.EventHandler(this.btnGraficos_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(776, 554);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // frm_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnGraficos);
            this.Controls.Add(this.btnPlanoCliente);
            this.Controls.Add(this.btnEmpresa);
            this.Controls.Add(this.stsStatusPrincipal);
            this.Controls.Add(this.menuPrincipal);
            this.Controls.Add(this.btnPlanoSaude);
            this.Controls.Add(this.btnFornecedor);
            this.Controls.Add(this.btnCliente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "frm_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulário Principal - Divicom";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Principal_FormClosed);
            this.stsStatusPrincipal.ResumeLayout(false);
            this.stsStatusPrincipal.PerformLayout();
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnFornecedor;
        private System.Windows.Forms.Button btnPlanoSaude;
        private System.Windows.Forms.StatusStrip stsStatusPrincipal;
        private System.Windows.Forms.ToolStripStatusLabel lblVersão;
        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuCadastro;
        private System.Windows.Forms.ToolStripMenuItem menuSair;
        private System.Windows.Forms.ToolStripMenuItem mtsCliente;
        private System.Windows.Forms.ToolStripMenuItem mtsVendedor;
        private System.Windows.Forms.ToolStripMenuItem mtsPlanoSaude;
        private System.Windows.Forms.ToolStripMenuItem mtsEmpresa;
        private System.Windows.Forms.Button btnEmpresa;
        private System.Windows.Forms.Button btnPlanoCliente;
        private System.Windows.Forms.Button btnGraficos;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuPlanosSaude;
        private System.Windows.Forms.ToolStripMenuItem mtsCadastrar;
        private System.Windows.Forms.ToolStripMenuItem menuVerificacao;
        private System.Windows.Forms.ToolStripMenuItem mtsGrafico;
        private System.Windows.Forms.ToolStripMenuItem menuSobre;
        private System.Windows.Forms.ToolStripMenuItem mtsSistema;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

