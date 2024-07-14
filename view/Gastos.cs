using Controller;
using Model;

namespace View
{
    public class ViewGastos : Form
    {
        private readonly Panel pnlHeader;
        private readonly Panel pnlCadastro;
        private readonly ComboBox cbCategoria;
        private readonly TextBox inpValor;
        private readonly TextBox inpGasto;
        private readonly MaskedTextBox inpData;
        private readonly Label lblCategoria;
        private readonly Label lblData;
        private readonly Label lblValor;
        private readonly Label lblGasto;
        private readonly Label lblCadastro;
        private readonly Panel pnlDgv;
        private readonly Button btnDeletar;
        private readonly Button btnAlterar;
        private readonly Button btnCadastrar;
        private readonly Button btnHome;
        private readonly DataGridView dgvGastos;
        private readonly Form parentForm;

        public ViewGastos()
        {
            List<Gastos> gastos = ControllerGastos.ListarGastos();
            ControllerGastos.Sincronizar();
            // parentForm = parent;
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.lblCadastro = new System.Windows.Forms.Label();
            this.pnlCadastro = new System.Windows.Forms.Panel();
            this.lblGasto = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.inpGasto = new System.Windows.Forms.TextBox();
            this.inpValor = new System.Windows.Forms.TextBox();
            this.inpData = new System.Windows.Forms.MaskedTextBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.dgvGastos = new System.Windows.Forms.DataGridView();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            this.pnlCadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnHome);
            this.pnlHeader.Controls.Add(this.btnDeletar);
            this.pnlHeader.Controls.Add(this.btnAlterar);
            this.pnlHeader.Controls.Add(this.btnCadastrar);
            this.pnlHeader.Controls.Add(this.pnlCadastro);
            this.pnlHeader.Controls.Add(this.lblCadastro);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(897, 328);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlDgv
            // 
            this.pnlDgv.Controls.Add(this.dgvGastos);
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgv.Location = new System.Drawing.Point(0, 328);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Size = new System.Drawing.Size(897, 250);
            this.pnlDgv.TabIndex = 2;
            // 
            // lblCadastro
            // 
            this.lblCadastro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCadastro.AutoSize = true;
            this.lblCadastro.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCadastro.Location = new System.Drawing.Point(335, 9);
            this.lblCadastro.Name = "lblCadastro";
            this.lblCadastro.Size = new System.Drawing.Size(226, 27);
            this.lblCadastro.TabIndex = 0;
            this.lblCadastro.Text = "Cadastro de Gastos";
            // 
            // pnlCadastro
            // 
            this.pnlCadastro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlCadastro.BackColor = System.Drawing.Color.LightGray;
            this.pnlCadastro.Controls.Add(this.cbCategoria);
            this.pnlCadastro.Controls.Add(this.inpValor);
            this.pnlCadastro.Controls.Add(this.inpGasto);
            this.pnlCadastro.Controls.Add(this.inpData);
            this.pnlCadastro.Controls.Add(this.lblCategoria);
            this.pnlCadastro.Controls.Add(this.lblData);
            this.pnlCadastro.Controls.Add(this.lblValor);
            this.pnlCadastro.Controls.Add(this.lblGasto);
            this.pnlCadastro.Location = new System.Drawing.Point(273, 46);
            this.pnlCadastro.MinimumSize = new System.Drawing.Size(350, 200);
            this.pnlCadastro.Name = "pnlCadastro";
            this.pnlCadastro.Size = new System.Drawing.Size(350, 200);
            this.pnlCadastro.TabIndex = 1;
            // 
            // lblGasto
            // 
            this.lblGasto.AutoSize = true;
            this.lblGasto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGasto.Location = new System.Drawing.Point(11, 31);
            this.lblGasto.Name = "lblGasto";
            this.lblGasto.Size = new System.Drawing.Size(122, 18);
            this.lblGasto.TabIndex = 0;
            this.lblGasto.Text = "Nome do Gasto:";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblData.Location = new System.Drawing.Point(11, 70);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(122, 18);
            this.lblData.TabIndex = 0;
            this.lblData.Text = "Data: ";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblValor.Location = new System.Drawing.Point(11, 110);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(120, 18);
            this.lblValor.TabIndex = 0;
            this.lblValor.Text = "Valor do Gasto: ";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCategoria.Location = new System.Drawing.Point(11, 150);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(82, 18);
            this.lblCategoria.TabIndex = 0;
            this.lblCategoria.Text = "Categoria:";
            // 
            // inpGasto
            // 
            this.inpGasto.Location = new System.Drawing.Point(152, 30);
            this.inpGasto.Name = "inpGasto";
            this.inpGasto.Size = new System.Drawing.Size(188, 18);
            this.inpGasto.BorderStyle = BorderStyle.FixedSingle;
            this.inpGasto.TabIndex = 0;
            // 
            // mskData
            // 
            this.inpData.Location = new Point(152, 70);
            this.inpData.Mask = "0000/00/00";
            this.inpData.Name = "inpData";
            this.inpData.BorderStyle = BorderStyle.FixedSingle;
            this.inpData.Size = new Size(100, 18);
            this.inpData.TabIndex = 1;
            // 
            // inpValor
            // 
            this.inpValor.Location = new System.Drawing.Point(152, 110);
            this.inpValor.Name = "inpValor";
            this.inpValor.Size = new System.Drawing.Size(188, 23);
            this.inpValor.BorderStyle = BorderStyle.FixedSingle;
            this.inpValor.TabIndex = 2;
            // 
            // cbCategoria
            // 
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(152, 150);
            this.cbCategoria.FlatStyle = FlatStyle.Flat;
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(188, 23);
            this.cbCategoria.TabIndex = 3;
            // 
            // dgvGastos
            // 
            this.dgvGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGastos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGastos.Location = new System.Drawing.Point(0, 0);
            this.dgvGastos.Name = "dgvGastos";
            this.dgvGastos.RowTemplate.Height = 25;
            this.dgvGastos.Size = new System.Drawing.Size(897, 250);
            this.dgvGastos.TabIndex = 0;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCadastrar.FlatStyle = FlatStyle.Flat;
            this.btnCadastrar.BackColor = Color.LightGreen;
            this.btnCadastrar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCadastrar.Location = new System.Drawing.Point(528, 268);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(120, 40);
            this.btnCadastrar.TabIndex = 4;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += ClickCadastrar;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAlterar.FlatStyle = FlatStyle.Flat;
            this.btnAlterar.BackColor = Color.LightBlue;
            this.btnAlterar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAlterar.Location = new System.Drawing.Point(389, 268);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(120, 40);
            this.btnAlterar.TabIndex = 5;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += ClickAlterar;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeletar.FlatStyle = FlatStyle.Flat;
            this.btnDeletar.BackColor = Color.Pink;
            this.btnDeletar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeletar.Location = new System.Drawing.Point(249, 268);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(120, 40);
            this.btnDeletar.TabIndex = 6;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += ClickDeletar;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.LightGray;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHome.Location = new System.Drawing.Point(12, 9);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(120, 40);
            this.btnHome.TabIndex = 7;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += ClickHome;
            // 
            // Gastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlDgv);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Gastos";
            this.Text = "Gerenciamento de Gastos";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlDgv.ResumeLayout(false);
            this.pnlCadastro.ResumeLayout(false);
            this.pnlCadastro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos)).EndInit();
            this.ResumeLayout(false);
            Listar();
        }

        private void Listar()
        {
            List<Gastos> gastos = ControllerGastos.ListarGastos();
            List<string> categorias = ControllerGastos.ListarCategorias();

            dgvGastos.Columns.Clear();
            dgvGastos.AutoGenerateColumns = false;
            dgvGastos.DataSource = gastos;
            cbCategoria.DataSource = categorias;

            dgvGastos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nome do Gasto",
                DataPropertyName = "Nome"
            });

            dgvGastos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Valor",
                DataPropertyName = "Valor"
            });

            dgvGastos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Categoria",
                DataPropertyName = "Categoria"
            });

            dgvGastos.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Data",
                DataPropertyName = "Data"
            });

            foreach (DataGridViewColumn column in dgvGastos.Columns)
            {
                column.Width = this.ClientSize.Width / 4;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    
        private void ClickCadastrar(object? sender, EventArgs e)
        {

        }
        
        private void ClickAlterar(object? sender, EventArgs e)
        {
            int indice = dgvGastos.SelectedRows[0].Index;

            if (inpGasto.Text == "" || inpValor.Text == "" || inpData.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else
            {
                ControllerGastos.AlterarGasto(inpGasto.Text, inpValor.Text, inpData.Text, cbCategoria.Text, indice);
                inpGasto.Text = "";
                inpValor.Text = "";
                inpData.Text = "";
                cbCategoria.Text = "";
            }

            Listar();
        }
        
        private void ClickDeletar(object? sender, EventArgs e)
        {
            int indice = dgvGastos.SelectedRows[0].Index;

            ControllerGastos.DeletarGasto(indice);

            Listar();
        }
        
        private void ClickHome(object? sender, EventArgs e)
        {
            Close();

            parentForm.Show();
        }
    }
}