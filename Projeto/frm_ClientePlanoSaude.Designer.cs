namespace Projeto
{
    partial class frm_ClientePlanoSaude
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ClientePlanoSaude));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCliente = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLimparVida = new System.Windows.Forms.Button();
            this.btnPesquisaVida = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPlanoSaude = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colemissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvMensalidade = new System.Windows.Forms.DataGridView();
            this.CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODIGOVENDEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMEVEND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCadPlanoCliente = new System.Windows.Forms.Button();
            this.btnMensalidade = new System.Windows.Forms.Button();
            this.btnDelMens = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanoSaude)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMensalidade)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCod
            // 
            this.txtCod.Enabled = false;
            this.txtCod.Location = new System.Drawing.Point(9, 32);
            this.txtCod.MaxLength = 20;
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(58, 20);
            this.txtCod.TabIndex = 0;
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Location = new System.Drawing.Point(73, 32);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(328, 20);
            this.txtNome.TabIndex = 1;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cod";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvCliente);
            this.groupBox1.Controls.Add(this.btnLimparVida);
            this.groupBox1.Controls.Add(this.btnPesquisaVida);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCod);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 278);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // dgvCliente
            // 
            this.dgvCliente.AllowUserToAddRows = false;
            this.dgvCliente.AllowUserToDeleteRows = false;
            this.dgvCliente.AllowUserToResizeColumns = false;
            this.dgvCliente.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCliente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCliente.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvCliente.Location = new System.Drawing.Point(8, 66);
            this.dgvCliente.MultiSelect = false;
            this.dgvCliente.Name = "dgvCliente";
            this.dgvCliente.ReadOnly = true;
            this.dgvCliente.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.dgvCliente.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCliente.Size = new System.Drawing.Size(465, 206);
            this.dgvCliente.TabIndex = 39;
            this.dgvCliente.SelectionChanged += new System.EventHandler(this.dgvCliente_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Codigo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nome";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nome";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 238;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Email";
            this.dataGridViewTextBoxColumn3.HeaderText = "Email";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 130;
            // 
            // btnLimparVida
            // 
            this.btnLimparVida.AutoSize = true;
            this.btnLimparVida.FlatAppearance.BorderSize = 0;
            this.btnLimparVida.Image = ((System.Drawing.Image)(resources.GetObject("btnLimparVida.Image")));
            this.btnLimparVida.Location = new System.Drawing.Point(439, 23);
            this.btnLimparVida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLimparVida.Name = "btnLimparVida";
            this.btnLimparVida.Size = new System.Drawing.Size(35, 36);
            this.btnLimparVida.TabIndex = 38;
            this.btnLimparVida.UseVisualStyleBackColor = true;
            this.btnLimparVida.Click += new System.EventHandler(this.btnLimparVida_Click);
            // 
            // btnPesquisaVida
            // 
            this.btnPesquisaVida.AutoSize = true;
            this.btnPesquisaVida.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisaVida.Image")));
            this.btnPesquisaVida.Location = new System.Drawing.Point(407, 28);
            this.btnPesquisaVida.Name = "btnPesquisaVida";
            this.btnPesquisaVida.Size = new System.Drawing.Size(26, 26);
            this.btnPesquisaVida.TabIndex = 37;
            this.btnPesquisaVida.UseVisualStyleBackColor = true;
            this.btnPesquisaVida.Click += new System.EventHandler(this.btnPesquisaVida_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPlanoSaude);
            this.groupBox2.Location = new System.Drawing.Point(12, 296);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(486, 162);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Plano de Saúde do Cliente Selecionado ";
            // 
            // dgvPlanoSaude
            // 
            this.dgvPlanoSaude.AllowUserToAddRows = false;
            this.dgvPlanoSaude.AllowUserToDeleteRows = false;
            this.dgvPlanoSaude.AllowUserToResizeColumns = false;
            this.dgvPlanoSaude.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPlanoSaude.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPlanoSaude.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPlanoSaude.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPlanoSaude.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanoSaude.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colNome,
            this.colEmail,
            this.colemissao,
            this.colValor});
            this.dgvPlanoSaude.Location = new System.Drawing.Point(6, 19);
            this.dgvPlanoSaude.MultiSelect = false;
            this.dgvPlanoSaude.Name = "dgvPlanoSaude";
            this.dgvPlanoSaude.ReadOnly = true;
            this.dgvPlanoSaude.RowHeadersVisible = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.dgvPlanoSaude.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPlanoSaude.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanoSaude.Size = new System.Drawing.Size(465, 124);
            this.dgvPlanoSaude.TabIndex = 5;
            this.dgvPlanoSaude.SelectionChanged += new System.EventHandler(this.dgvPlanoSaude_SelectionChanged);
            // 
            // colCodigo
            // 
            this.colCodigo.DataPropertyName = "CodigoPlanoSaude";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.colCodigo.DefaultCellStyle = dataGridViewCellStyle5;
            this.colCodigo.HeaderText = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCodigo.Width = 60;
            // 
            // colNome
            // 
            this.colNome.DataPropertyName = "Nome";
            this.colNome.HeaderText = "Nome";
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            this.colNome.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNome.Width = 190;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Vigencia";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEmail.DefaultCellStyle = dataGridViewCellStyle6;
            this.colEmail.HeaderText = "Vigencia";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEmail.Width = 70;
            // 
            // colemissao
            // 
            this.colemissao.DataPropertyName = "Emissao";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colemissao.DefaultCellStyle = dataGridViewCellStyle7;
            this.colemissao.HeaderText = "Emissao";
            this.colemissao.Name = "colemissao";
            this.colemissao.ReadOnly = true;
            this.colemissao.Width = 70;
            // 
            // colValor
            // 
            this.colValor.DataPropertyName = "Valor";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.colValor.DefaultCellStyle = dataGridViewCellStyle8;
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
            this.colValor.Width = 70;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvMensalidade);
            this.groupBox3.Location = new System.Drawing.Point(504, 52);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(203, 317);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mensalidade Paga";
            // 
            // dgvMensalidade
            // 
            this.dgvMensalidade.AllowUserToAddRows = false;
            this.dgvMensalidade.AllowUserToDeleteRows = false;
            this.dgvMensalidade.AllowUserToResizeColumns = false;
            this.dgvMensalidade.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMensalidade.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvMensalidade.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMensalidade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMensalidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMensalidade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODIGO,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.CODIGOVENDEDOR,
            this.NOMEVEND});
            this.dgvMensalidade.Location = new System.Drawing.Point(6, 19);
            this.dgvMensalidade.MultiSelect = false;
            this.dgvMensalidade.Name = "dgvMensalidade";
            this.dgvMensalidade.ReadOnly = true;
            this.dgvMensalidade.RowHeadersVisible = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dgvMensalidade.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvMensalidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMensalidade.Size = new System.Drawing.Size(191, 292);
            this.dgvMensalidade.TabIndex = 40;
            this.dgvMensalidade.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvMensalidade_MouseDoubleClick);
            // 
            // CODIGO
            // 
            this.CODIGO.DataPropertyName = "Codigo";
            this.CODIGO.HeaderText = "Codigo";
            this.CODIGO.Name = "CODIGO";
            this.CODIGO.ReadOnly = true;
            this.CODIGO.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DataPagamento";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle11.NullValue = null;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn4.HeaderText = "Pagamento";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Valor";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "C2";
            dataGridViewCellStyle12.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn5.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CODIGOVENDEDOR
            // 
            this.CODIGOVENDEDOR.DataPropertyName = "CodigoVendedor";
            this.CODIGOVENDEDOR.HeaderText = "CodVendedor";
            this.CODIGOVENDEDOR.Name = "CODIGOVENDEDOR";
            this.CODIGOVENDEDOR.ReadOnly = true;
            this.CODIGOVENDEDOR.Visible = false;
            // 
            // NOMEVEND
            // 
            this.NOMEVEND.DataPropertyName = "NomeVendedor";
            this.NOMEVEND.HeaderText = "NomeVendedor";
            this.NOMEVEND.Name = "NOMEVEND";
            this.NOMEVEND.ReadOnly = true;
            this.NOMEVEND.Visible = false;
            // 
            // btnCadPlanoCliente
            // 
            this.btnCadPlanoCliente.AutoSize = true;
            this.btnCadPlanoCliente.Location = new System.Drawing.Point(510, 375);
            this.btnCadPlanoCliente.Name = "btnCadPlanoCliente";
            this.btnCadPlanoCliente.Size = new System.Drawing.Size(197, 23);
            this.btnCadPlanoCliente.TabIndex = 40;
            this.btnCadPlanoCliente.Text = "Cadastrar Plano de Saúde ao Cliente";
            this.btnCadPlanoCliente.UseVisualStyleBackColor = true;
            this.btnCadPlanoCliente.Click += new System.EventHandler(this.btnCadPlanoCliente_Click);
            // 
            // btnMensalidade
            // 
            this.btnMensalidade.AutoSize = true;
            this.btnMensalidade.Location = new System.Drawing.Point(510, 404);
            this.btnMensalidade.Name = "btnMensalidade";
            this.btnMensalidade.Size = new System.Drawing.Size(197, 23);
            this.btnMensalidade.TabIndex = 42;
            this.btnMensalidade.Text = "Cadastrar Pagamento de Mensalidade";
            this.btnMensalidade.UseVisualStyleBackColor = true;
            this.btnMensalidade.Click += new System.EventHandler(this.btnMensalidade_Click);
            // 
            // btnDelMens
            // 
            this.btnDelMens.AutoSize = true;
            this.btnDelMens.Location = new System.Drawing.Point(544, 18);
            this.btnDelMens.Name = "btnDelMens";
            this.btnDelMens.Size = new System.Drawing.Size(114, 23);
            this.btnDelMens.TabIndex = 43;
            this.btnDelMens.Text = "Deletar Mensalidade";
            this.btnDelMens.UseVisualStyleBackColor = true;
            this.btnDelMens.Click += new System.EventHandler(this.btnDelMens_Click);
            // 
            // frm_ClientePlanoSaude
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 474);
            this.Controls.Add(this.btnDelMens);
            this.Controls.Add(this.btnMensalidade);
            this.Controls.Add(this.btnCadPlanoCliente);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ClientePlanoSaude";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planos de Saúde do Cliente";
            this.Load += new System.EventHandler(this.frm_ClientePlanoSaude_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanoSaude)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMensalidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btnLimparVida;
        internal System.Windows.Forms.Button btnPesquisaVida;
        private System.Windows.Forms.DataGridView dgvCliente;
        private System.Windows.Forms.DataGridView dgvPlanoSaude;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvMensalidade;
        private System.Windows.Forms.Button btnCadPlanoCliente;
        private System.Windows.Forms.Button btnMensalidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colemissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGOVENDEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMEVEND;
        private System.Windows.Forms.Button btnDelMens;
    }
}