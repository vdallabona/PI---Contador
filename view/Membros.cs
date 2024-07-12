using System;
using System.Drawing;
using System.Windows.Forms;

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
        private readonly Panel PnlLogin;
        private readonly DataGridView DataGridListar;

        public ViewMembros()
        {
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(800, 600);
            BackColor = Color.White;
            Text = "Login";

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
                Location = new Point(20, 65),
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
                Location = new Point(20, 110),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

            inpLogin = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(170, 105),
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

            PnlLogin = new Panel
            {
                MinimumSize = new Size(400, 250),
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
                Location = new Point(this.ClientSize.Width / 2 - 200, this.ClientSize.Height / 3 - 150)
            };

            DataGridListar = new DataGridView {
                Location = new Point(0, 300),
                Size = new Size(800, 600)
            };

            Controls.Add(PnlLogin);
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
            Controls.Add(DataGridListar);
            //Listar();
        }

        private void Listar() {
            // List<Tarefa> tarefas = ControllerTarefa.ListarTarefa();
            // DataGridListar.Columns.Clear();
            // DataGridListar.AutoGenerateColumns = false;
            // DataGridListar.DataSource = tarefas;

            DataGridListar.Columns.Add(new DataGridViewTextBoxColumn{
                HeaderText = "ID",
                DataPropertyName = "idTarefa"
            });

            DataGridListar.Columns.Add(new DataGridViewTextBoxColumn{
                HeaderText = "Nome",
                DataPropertyName = "Nome"
            });

            DataGridListar.Columns.Add(new DataGridViewTextBoxColumn{
                HeaderText = "Data",
                DataPropertyName = "Data"
            });

            DataGridListar.Columns.Add(new DataGridViewTextBoxColumn{
                HeaderText = "Hora",
                DataPropertyName = "Hora"
            });

            DataGridListar.Columns.Add(new DataGridViewTextBoxColumn{
                HeaderText = "Status",
                DataPropertyName = "Concluida"
            });
        }

        private void ClickCadastrar(object? sender, EventArgs e)
        {

        }

        private void ClickAlterar(object? sender, EventArgs e)
        {

        }
        private void ClickDeletar(object? sender, EventArgs e)
        {

        }

    }
}