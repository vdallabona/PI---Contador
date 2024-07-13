using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class ViewContador : Form
    {
        private readonly Label lblTituloLogin;
        private readonly Label lblLogin;
        private readonly TextBox inpLogin;
        private readonly Label lblSenha;
        private readonly TextBox inpSenha;
        private readonly Button btnLogar;
        private readonly Button btnCadastrar;
        private readonly Panel PnlLogin;

        public ViewContador()
        {
            
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(800, 600);
            BackColor = Color.White;
            Text = "Login";

            lblTituloLogin = new Label
            {
                Text = "LOGIN",
                Location = new Point(150, 0),
                Font = new Font("Arial", 18),
                AutoSize = true
            };

            lblLogin = new Label
            {
                Text = "Login: ",
                Location = new Point(50, 60),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

            inpLogin = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(150, 55),
                Font = new Font("Arial", 12),
                BorderStyle = BorderStyle.FixedSingle
            };

            lblSenha = new Label
            {
                Text = "Senha: ",
                Location = new Point(50, 110),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

            inpSenha = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(150, 105),
                Font = new Font("Arial", 12),
                PasswordChar = '*',
                BorderStyle = BorderStyle.FixedSingle
            };

            btnCadastrar = new Button
            {
                Text = "CADASTRAR",
                Location = new Point(50, 210),
                Size = new Size(120, 40),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnCadastrar.Click += ClickCadastrar;

            btnLogar = new Button
            {
                Text = "LOGAR",
                Location = new Point(230, 210),
                Size = new Size(120, 40),
                BackColor = Color.LightBlue,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnLogar.Click += ClickLogar;

            PnlLogin = new Panel
            {
                MinimumSize = new Size(400, 400),
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
                Location = new Point(this.ClientSize.Width / 2 - 200, this.ClientSize.Height / 2 - 150)
            };

            Controls.Add(PnlLogin);
            PnlLogin.Controls.Add(lblTituloLogin);
            PnlLogin.Controls.Add(lblLogin);
            PnlLogin.Controls.Add(inpLogin);
            PnlLogin.Controls.Add(lblSenha);
            PnlLogin.Controls.Add(inpSenha);
            PnlLogin.Controls.Add(btnCadastrar);
            PnlLogin.Controls.Add(btnLogar);
        }

        private void ClickCadastrar(object? sender, EventArgs e)
        {
            
            Hide();
            new ViewCadastro(this).Show();
            

            
            

        }

        private void ClickLogar(object? sender, EventArgs e)
        {
            if(inpLogin.Text == ""){
                MessageBox.Show("Input login não pode ser vazio");
                return;
            }
            
            if(inpSenha.Text ==""){
                MessageBox.Show("Input senha não pode ser vazio");
                return;
            }

            Hide();
            new ViewHome(this).Show();

        }

    }
}