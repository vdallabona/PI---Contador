using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class ViewCategorias : Form
    {
        private readonly Label lblTituloCategorias;
        private readonly Label lblCategorias;
        private readonly TextBox inpCategorias;
        private readonly Panel PnlCategorias;
        private readonly Button btnCadastrar;
        private readonly Button btnAlterar;
        private readonly DataGridView DgvCategorias;
        





        public ViewCategorias()
        {
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(800, 600);
            BackColor = Color.White;
            Text = "Categorias";

            lblTituloCategorias = new Label
            {
                Text = "Cadastro de categorias",
                Location = new Point(200, 20),
                Font = new Font("Arial", 28),
                AutoSize = true
            };

            lblCategorias = new Label
            {
                Text = "Nome da Categoria",
                Location = new Point(210, 10),
                Font = new Font("Arial", 14),
                AutoSize = true
            };

            inpCategorias = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(400, 10),
                Font = new Font("Arial", 12),
                BorderStyle = BorderStyle.FixedSingle
            };


            btnCadastrar = new Button
            {
                Text = "Cadastrar",
                Location = new Point(270, 70),
                Size = new Size(120, 40),
                BackColor = Color.LightGray,
                Font = new Font("Arial", 10)
            };
            btnCadastrar.Click += ClickCadastrar;


            btnAlterar = new Button
            {
                Text = "Alterar",
                Location = new Point(410, 70),
                Size = new Size(120, 40),
                BackColor = Color.LightGray,
                Font = new Font("Arial", 10)
            };
            btnAlterar.Click += ClickAlterar;

            DgvCategorias = new DataGridView {
                Location = new Point(335, 200),
                Size = new Size(145, 150)
            };



             PnlCategorias = new Panel
            {
                MinimumSize = new Size(700, 700),
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
                Location = new Point(this.ClientSize.Width / 2 - 400, this.ClientSize.Height / 2 - 150)
            };





            Controls.Add(lblTituloCategorias);
            PnlCategorias.Controls.Add(lblCategorias);
            Controls.Add(PnlCategorias);
            PnlCategorias.Controls.Add(inpCategorias);
            PnlCategorias.Controls.Add(btnCadastrar);
            PnlCategorias.Controls.Add(btnAlterar);
            PnlCategorias.Controls.Add(DgvCategorias);




            


            Listar();
        }


        private void Listar() {
         
        DgvCategorias.Columns.Clear();
        DgvCategorias.AutoGenerateColumns = false;
         
        DgvCategorias.Columns.Add(new DataGridViewTextBoxColumn {
            DataPropertyName = "Descrição",
            HeaderText = "Descrição"
        });
        
    }

        private void ClickCadastrar(object? sender, EventArgs e)
        {

        }
        private void ClickAlterar(object? sender, EventArgs e)
        {

        }
    }
}