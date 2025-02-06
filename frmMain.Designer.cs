namespace ExportadorInventario
{
    partial class frmMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnConfig = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.cboSistema = new System.Windows.Forms.ComboBox();
            this.btnBDConfig = new System.Windows.Forms.Button();
            this.btnReadProd = new System.Windows.Forms.Button();
            this.btnGenerateInventory = new System.Windows.Forms.Button();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.lblAviso = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dirOut = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfig
            // 
            this.btnConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.btnConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnConfig.FlatAppearance.BorderSize = 0;
            this.btnConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnConfig.ForeColor = System.Drawing.Color.White;
            this.btnConfig.Location = new System.Drawing.Point(826, 12);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(146, 37);
            this.btnConfig.TabIndex = 0;
            this.btnConfig.Text = "Configurações";
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Visible = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.ForeColor = System.Drawing.SystemColors.Control;
            this.lblVersion.Location = new System.Drawing.Point(848, 534);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblVersion.Size = new System.Drawing.Size(120, 20);
            this.lblVersion.TabIndex = 21;
            this.lblVersion.Text = "version";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboSistema
            // 
            this.cboSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSistema.FormattingEnabled = true;
            this.cboSistema.Items.AddRange(new object[] {
            "VR",
            "LeCheff",
            "LeStore"});
            this.cboSistema.Location = new System.Drawing.Point(15, 21);
            this.cboSistema.Name = "cboSistema";
            this.cboSistema.Size = new System.Drawing.Size(145, 21);
            this.cboSistema.TabIndex = 22;
            this.cboSistema.SelectedIndexChanged += new System.EventHandler(this.cboSistema_SelectedIndexChanged);
            // 
            // btnBDConfig
            // 
            this.btnBDConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.btnBDConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnBDConfig.FlatAppearance.BorderSize = 0;
            this.btnBDConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnBDConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBDConfig.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnBDConfig.ForeColor = System.Drawing.Color.White;
            this.btnBDConfig.Location = new System.Drawing.Point(166, 12);
            this.btnBDConfig.Name = "btnBDConfig";
            this.btnBDConfig.Size = new System.Drawing.Size(135, 37);
            this.btnBDConfig.TabIndex = 23;
            this.btnBDConfig.Text = "Config do banco";
            this.btnBDConfig.UseVisualStyleBackColor = false;
            this.btnBDConfig.Click += new System.EventHandler(this.btnBDConfig_Click);
            // 
            // btnReadProd
            // 
            this.btnReadProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.btnReadProd.Enabled = false;
            this.btnReadProd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnReadProd.FlatAppearance.BorderSize = 0;
            this.btnReadProd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnReadProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadProd.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnReadProd.ForeColor = System.Drawing.Color.White;
            this.btnReadProd.Location = new System.Drawing.Point(307, 12);
            this.btnReadProd.Name = "btnReadProd";
            this.btnReadProd.Size = new System.Drawing.Size(119, 37);
            this.btnReadProd.TabIndex = 24;
            this.btnReadProd.Text = "Ler produtos";
            this.btnReadProd.UseVisualStyleBackColor = false;
            this.btnReadProd.Click += new System.EventHandler(this.btnReadProd_Click);
            // 
            // btnGenerateInventory
            // 
            this.btnGenerateInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.btnGenerateInventory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnGenerateInventory.FlatAppearance.BorderSize = 0;
            this.btnGenerateInventory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnGenerateInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateInventory.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnGenerateInventory.ForeColor = System.Drawing.Color.White;
            this.btnGenerateInventory.Location = new System.Drawing.Point(432, 12);
            this.btnGenerateInventory.Name = "btnGenerateInventory";
            this.btnGenerateInventory.Size = new System.Drawing.Size(146, 37);
            this.btnGenerateInventory.TabIndex = 25;
            this.btnGenerateInventory.Text = "Gerar inventário";
            this.btnGenerateInventory.UseVisualStyleBackColor = false;
            this.btnGenerateInventory.Visible = false;
            this.btnGenerateInventory.Click += new System.EventHandler(this.btnGenerateInventory_Click);
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.AllowUserToOrderColumns = true;
            this.dgvProdutos.AllowUserToResizeColumns = false;
            this.dgvProdutos.AllowUserToResizeRows = false;
            this.dgvProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvProdutos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProdutos.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvProdutos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProdutos.Location = new System.Drawing.Point(12, 121);
            this.dgvProdutos.MultiSelect = false;
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.RowHeadersVisible = false;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.ShowEditingIcon = false;
            this.dgvProdutos.ShowRowErrors = false;
            this.dgvProdutos.Size = new System.Drawing.Size(960, 410);
            this.dgvProdutos.TabIndex = 26;
            this.dgvProdutos.Visible = false;
            // 
            // lblAviso
            // 
            this.lblAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.White;
            this.lblAviso.Location = new System.Drawing.Point(12, 79);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(960, 39);
            this.lblAviso.TabIndex = 30;
            this.lblAviso.Text = "Aviso";
            this.lblAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(774, 79);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRegistros.Size = new System.Drawing.Size(198, 28);
            this.lblRegistros.TabIndex = 32;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRegistros.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(17, 79);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(228, 28);
            this.lblTotal.TabIndex = 33;
            this.lblTotal.Text = "Valor total: R$ 0,00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotal.Visible = false;
            // 
            // dirOut
            // 
            this.dirOut.SelectedPath = "C:\\Users\\DGPla\\OneDrive\\Desktop";
            this.dirOut.ShowNewFolderButton = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::ExportadorInventario.Properties.Resources.marca_dagua2;
            this.pictureBox1.Location = new System.Drawing.Point(596, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(20)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.dgvProdutos);
            this.Controls.Add(this.btnGenerateInventory);
            this.Controls.Add(this.btnReadProd);
            this.Controls.Add(this.btnBDConfig);
            this.Controls.Add(this.cboSistema);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automatec | ExportadorInventario";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ComboBox cboSistema;
        private System.Windows.Forms.Button btnBDConfig;
        private System.Windows.Forms.Button btnReadProd;
        private System.Windows.Forms.Button btnGenerateInventory;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.FolderBrowserDialog dirOut;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

