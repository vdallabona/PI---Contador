using Controller;
using Model;

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
        private readonly Button btnHome;

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

            btnHome = new Button
            {
                Text = "Home",
                Location = new Point(20, 20),
                Size = new Size(100, 40),
                BackColor = Color.LightGray,
                Font = new Font("Arial", 10)
            };
            btnHome.Click += BtnHome_Click;

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

            DgvCategorias = new DataGridView
            {
                Location = new Point(80, 150),
                Size = new Size(700, 260),
                AutoGenerateColumns = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false
            };

            DgvCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nome",
                HeaderText = "Descrição",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            PnlCategorias = new Panel
            {
                MinimumSize = new Size(700, 700),
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
                Location = new Point(this.ClientSize.Width / 2 - 400, this.ClientSize.Height / 2 - 150)
            };

            Controls.Add(lblTituloCategorias);
            Controls.Add(btnHome);
            PnlCategorias.Controls.Add(lblCategorias);
            Controls.Add(PnlCategorias);
            PnlCategorias.Controls.Add(inpCategorias);
            PnlCategorias.Controls.Add(btnCadastrar);
            PnlCategorias.Controls.Add(btnAlterar);
            PnlCategorias.Controls.Add(DgvCategorias);

            ControllerCategorias.Sincronizar();
            Listar();
        }

        private void Listar()
        {
            List<Categorias> categorias = ControllerCategorias.ListarCategorias();
            DgvCategorias.DataSource = null;
            DgvCategorias.DataSource = categorias;
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            Hide();
            new ViewHomeAdm(this).Show();
        }
        

        private void ClickCadastrar(object sender, EventArgs e)
        {
            string nome = inpCategorias.Text;
            if (!string.IsNullOrWhiteSpace(nome))
            {
                ControllerCategorias.CriarCategoria(nome);
                Listar();
                inpCategorias.Clear();
            }
            else
            {
                MessageBox.Show("O nome da categoria não pode estar vazio.");
            }
        }

        private void ClickAlterar(object sender, EventArgs e)
        {
            if (DgvCategorias.SelectedRows.Count > 0)
            {
                int indice = DgvCategorias.SelectedRows[0].Index;
                string nome = inpCategorias.Text;
                if (!string.IsNullOrWhiteSpace(nome))
                {
                    ControllerCategorias.AlterarCategoria(indice, nome);
                    Listar();
                    inpCategorias.Clear();
                }
                else
                {
                    MessageBox.Show("O nome da categoria não pode estar vazio.");
                }
            }
            else
            {
                MessageBox.Show("Selecione uma categoria para alterar.");
            }
        }
    }
}