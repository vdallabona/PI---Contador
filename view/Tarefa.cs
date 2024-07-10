using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class ViewContabeis : Form
    {
        private readonly Label labelTituloLogin;
        private readonly Label labelLogin;
        private readonly TextBox inputLogin;
        private readonly Label labelSenha;
        private readonly TextBox inputSenha;
        private readonly Button buttonLogar;
        private readonly Button buttonCadastrar;
        private readonly Panel PnlLogin;

        public ViewContabeis()
        {
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(800, 600);
            BackColor = Color.White;
            Text = "Login";

            labelTituloLogin = new Label
            {
                Text = "LOGIN",
                Location = new Point(150, 0),
                Font = new Font("Arial", 18),
                AutoSize = true
            };

            labelLogin = new Label
            {
                Text = "Login: ",
                Location = new Point(50, 60),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

            inputLogin = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(150, 55),
                Font = new Font("Arial", 12),
                BorderStyle = BorderStyle.FixedSingle
            };

            labelSenha = new Label
            {
                Text = "Senha: ",
                Location = new Point(50, 110),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

            inputSenha = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(150, 105),
                Font = new Font("Arial", 12),
                PasswordChar = '*',
                BorderStyle = BorderStyle.FixedSingle
            };

            buttonCadastrar = new Button
            {
                Text = "CADASTRAR",
                Location = new Point(50, 210),
                Size = new Size(120, 40),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            buttonCadastrar.Click += ClickCadastrar;

            buttonLogar = new Button
            {
                Text = "LOGAR",
                Location = new Point(230, 210),
                Size = new Size(120, 40),
                BackColor = Color.LightBlue,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            buttonLogar.Click += ClickLogar;

            PnlLogin = new Panel
            {
                MinimumSize = new Size(400, 400),
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
                Location = new Point(this.ClientSize.Width / 2 - 200, this.ClientSize.Height / 2 - 150)
            };

            Controls.Add(PnlLogin);
            PnlLogin.Controls.Add(labelTituloLogin);
            PnlLogin.Controls.Add(labelLogin);
            PnlLogin.Controls.Add(inputLogin);
            PnlLogin.Controls.Add(labelSenha);
            PnlLogin.Controls.Add(inputSenha);
            PnlLogin.Controls.Add(buttonCadastrar);
            PnlLogin.Controls.Add(buttonLogar);
        }

        private void ClickCadastrar(object? sender, EventArgs e)
        {

        }

        private void ClickLogar(object? sender, EventArgs e)
        {

        }

    }
}