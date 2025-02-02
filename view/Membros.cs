using Controller;
using Model;

namespace View
{
    public class ViewMembros : Form
    {
        private readonly Label lblTituloMembros;
        private readonly Label lblUsuario;
        private readonly TextBox inpUsuario;
        private readonly Label lblLogin;
        private readonly TextBox inpLogin;
        private readonly Label lblSenha;
        private readonly TextBox inpSenha;
        private readonly Button btnAlterar;
        private readonly Button btnCadastrar;
        private readonly Button btnDeletar;
        private readonly Button btnHomepage;
        private readonly Panel PnlLogin;
        private readonly Panel PnlGrid;
        private readonly DataGridView DataGridListar;

        public ViewMembros()
        {

            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(800, 600);
            BackColor = Color.White;
            Text = "Cadastro de Membros";

            lblTituloMembros = new Label
            {
                Text = "Cadastro De Membros",
                Location = new Point(80, 0),
                Font = new Font("Arial", 18),
                AutoSize = true
            };

            lblUsuario = new Label
            {
                Text = "Nome de Usuário: ",
                Location = new Point(20, 70),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

            inpUsuario = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(170, 65),
                Font = new Font("Arial", 12),
                BorderStyle = BorderStyle.FixedSingle
            };

            lblLogin = new Label
            {
                Text = "Login: ",
                Location = new Point(20, 115),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

            inpLogin = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(170, 110),
                Font = new Font("Arial", 12),
                BorderStyle = BorderStyle.FixedSingle
            };

            lblSenha = new Label
            {
                Text = "Senha: ",
                Location = new Point(20, 160),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

            inpSenha = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(170, 155),
                Font = new Font("Arial", 12),
                PasswordChar = '*',
                BorderStyle = BorderStyle.FixedSingle
            };

            btnCadastrar = new Button
            {
                Text = "CADASTRAR",
                Location = new Point(270, 210),
                Size = new Size(120, 40),
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnCadastrar.Click += ClickCadastrar;

            btnAlterar = new Button
            {
                Text = "ALTERAR",
                Location = new Point(145, 210),
                Size = new Size(120, 40),
                BackColor = Color.LightBlue,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnAlterar.Click += ClickAlterar;

            btnDeletar = new Button
            {
                Text = "DELETAR",
                Location = new Point(20, 210),
                Size = new Size(120, 40),
                BackColor = Color.Pink,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnDeletar.Click += ClickDeletar;

            btnHomepage = new Button
            {
                Text = "HOME",
                Location = new Point(10, 10),
                Size = new Size(120, 40),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnHomepage.Click += ClickHomepage;

            PnlLogin = new Panel
            {
                MinimumSize = new Size(400, 250),
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.Top,
                Location = new Point(this.ClientSize.Width / 2 - 200, this.ClientSize.Height / 3 - 150)
            };

            PnlGrid = new Panel
            {
                Size = new Size(800, 800),
                Location = new Point(0, 300),
                AutoScroll = true
            };

            DataGridListar = new DataGridView {
                AutoGenerateColumns = false,
                Width = 750,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false
            };

            DataGridListar.Columns.Add(new DataGridViewTextBoxColumn{
                HeaderText = "Nome",
                DataPropertyName = "Nome",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            DataGridListar.Columns.Add(new DataGridViewTextBoxColumn{
                HeaderText = "Login",
                DataPropertyName = "Login",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            DataGridListar.Columns.Add(new DataGridViewTextBoxColumn{
                HeaderText = "Senha",
                DataPropertyName = "Senha",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            Controls.Add(PnlLogin);
            Controls.Add(PnlGrid);
            PnlLogin.Controls.Add(lblTituloMembros);
            PnlLogin.Controls.Add(lblUsuario);
            PnlLogin.Controls.Add(inpUsuario);
            PnlLogin.Controls.Add(lblLogin);
            PnlLogin.Controls.Add(inpLogin);
            PnlLogin.Controls.Add(lblSenha);
            PnlLogin.Controls.Add(inpSenha);
            PnlLogin.Controls.Add(btnCadastrar);
            PnlLogin.Controls.Add(btnAlterar);
            PnlLogin.Controls.Add(btnDeletar);
            Controls.Add(btnHomepage);
            PnlGrid.Controls.Add(DataGridListar);
            ControllerMembros.Sincronizar();
            List<Membros> membros = ControllerMembros.ListarMembros();
            if (membros.Count > 0)
            {
                Listar();
            }
        }

        private void Listar() {
            List<Membros> membros = ControllerMembros.ListarMembros();
            DataGridListar.DataSource = null;
            DataGridListar.DataSource = membros;
        }

        private void ClickCadastrar(object? sender, EventArgs e)
        {
            ControllerMembros.CriarMembro(inpUsuario.Text, inpLogin.Text, inpSenha.Text);
            Listar();
            inpUsuario.Text = ""; 
            inpLogin.Text = "";
            inpSenha.Text = "";
        }
        private void ClickAlterar(object? sender, EventArgs e)
        {
            int indice = DataGridListar.SelectedRows[0].Index;

            if (inpUsuario.Text == "" || inpLogin.Text == "" || inpSenha.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else
            {
                ControllerMembros.AlterarMembro(inpUsuario.Text, inpLogin.Text, inpSenha.Text, indice);
                Listar();
                inpUsuario.Text = "";
                inpLogin.Text = "";
                inpSenha.Text = "";
            }

        }
        private void ClickDeletar(object? sender, EventArgs e)
        {
            int indice = DataGridListar.SelectedRows[0].Index;
            ControllerMembros.DeletarMembro(indice);
            Listar();
        }
        private void ClickHomepage(object? sender, EventArgs e)
        {
            Hide();
            new ViewHomeAdm(this).Show();
        }
    }
}