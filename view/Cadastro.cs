<<<<<<< HEAD
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class ViewCadastro : Form
    {
        
        private readonly Form ParentForm;
        private readonly Label lblTituloCadastro;
        
        private readonly Label lblNomeFam;
        private readonly Label lblLoginFam;

        private readonly Label lblSenhaFam;
        private readonly Label lblLoginAdm;

        private readonly Label lblSenhaAdm;
        private readonly TextBox inpNomeFam;
        private readonly TextBox inpLoginFam;

        private readonly TextBox inpSenhaFam;
        private readonly TextBox inpLoginAdm;

        private readonly TextBox inpSenhaAdm;
        
        private readonly Button btnCadastrar;

        private readonly Panel PnlLogin;

        public ViewCadastro(Form parent)
        {
            ParentForm = parent;
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(800, 600);
            BackColor = Color.White;
            Text = "Login";

            lblTituloCadastro = new Label{
                Text = "Cadastro de Família",
                Location = new Point (110, 0),
                Font = new Font("Arial", 18),
                AutoSize = true,
            };
            
            
            
            
            
            lblNomeFam = new Label
            {
                Text = "Nome da Família",
                Location = new Point(0, 60),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

            lblLoginFam = new Label
            {
                Text = "Login da Família",
                Location = new Point(0, 120),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

             lblSenhaFam = new Label
            {
                Text = "Senha da Família",
                Location = new Point(0, 180),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

             lblLoginAdm = new Label
            {
                Text = "Login do Adm",
                Location = new Point(0, 240),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

             lblSenhaAdm = new Label
            {
                Text = "Senha do Adm",
                Location = new Point(0, 300),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

            inpNomeFam = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(150, 60),
                Font = new Font("Arial", 12),
                BorderStyle = BorderStyle.FixedSingle
            };


            inpLoginFam = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(150, 120),
                Font = new Font("Arial", 12),
                PasswordChar = '*',
                BorderStyle = BorderStyle.FixedSingle
            };

            inpSenhaFam = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(150, 180),
                Font = new Font("Arial", 12),
                PasswordChar = '*',
                BorderStyle = BorderStyle.FixedSingle
            };


            inpLoginAdm = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(150, 240),
                Font = new Font("Arial", 12),
                PasswordChar = '*',
                BorderStyle = BorderStyle.FixedSingle
            };

            inpSenhaAdm = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(150, 300),
                Font = new Font("Arial", 12),
                PasswordChar = '*',
                BorderStyle = BorderStyle.FixedSingle
            };



            btnCadastrar = new Button
            {
                Text = "CADASTRAR",
                Location = new Point(150, 360),
                Size = new Size(120, 40),
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnCadastrar.Click += ClickCadastrar;


            PnlLogin = new Panel
            {
                MinimumSize = new Size(600, 600),
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
                Location = new Point(this.ClientSize.Width / 2 - 200, this.ClientSize.Height / 2 - 150)
            };

            Controls.Add(PnlLogin);
            PnlLogin.Controls.Add(lblTituloCadastro);
            PnlLogin.Controls.Add(lblNomeFam);
            PnlLogin.Controls.Add(lblLoginFam);
            PnlLogin.Controls.Add(lblSenhaFam);
            PnlLogin.Controls.Add(lblLoginAdm);
            PnlLogin.Controls.Add(lblSenhaAdm);
            PnlLogin.Controls.Add(inpNomeFam);
            PnlLogin.Controls.Add(inpLoginFam);
            PnlLogin.Controls.Add(inpSenhaFam);
            PnlLogin.Controls.Add(inpLoginAdm);
            PnlLogin.Controls.Add(inpSenhaAdm);
            PnlLogin.Controls.Add(btnCadastrar);
        }

        private void ClickCadastrar(object? sender, EventArgs e)
        {
            if(inpNomeFam.Text == "" || inpLoginFam.Text == "" || inpSenhaFam.Text == "" || inpLoginAdm.Text == "" || inpSenhaAdm.Text == ""){
                MessageBox.Show("Por favor, preencha todos os campos");
        }else{
        

        }
        }

        private void ClickLogar(object? sender, EventArgs e)
        {

        }

    }
=======
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class ViewCadastro : Form
    {
        
        private readonly Form ParentForm;
        private readonly Label lblTituloCadastro;
        
        private readonly Label lblNomeFam;
        private readonly Label lblLoginFam;

        private readonly Label lblSenhaFam;
        private readonly Label lblLoginAdm;

        private readonly Label lblSenhaAdm;
        private readonly TextBox inpNomeFam;
        private readonly TextBox inpLoginFam;

        private readonly TextBox inpSenhaFam;
        private readonly TextBox inpLoginAdm;

        private readonly TextBox inpSenhaAdm;
        
        private readonly Button btnCadastrar;

        private readonly Panel PnlLogin;

        public ViewCadastro(Form parent)
        {
            ParentForm = parent;
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(800, 600);
            BackColor = Color.White;
            Text = "Login";

            lblTituloCadastro = new Label{
                Text = "Cadastro de Família",
                Location = new Point (110, 0),
                Font = new Font("Arial", 18),
                AutoSize = true,
            };
            
            
            
            
            
            lblNomeFam = new Label
            {
                Text = "Nome da Família",
                Location = new Point(0, 60),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

            lblLoginFam = new Label
            {
                Text = "Login da Família",
                Location = new Point(0, 120),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

             lblSenhaFam = new Label
            {
                Text = "Senha da Família",
                Location = new Point(0, 180),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

             lblLoginAdm = new Label
            {
                Text = "Login do Adm",
                Location = new Point(0, 240),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

             lblSenhaAdm = new Label
            {
                Text = "Senha do Adm",
                Location = new Point(0, 300),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

            inpNomeFam = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(150, 60),
                Font = new Font("Arial", 12),
                BorderStyle = BorderStyle.FixedSingle
            };


            inpLoginFam = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(150, 120),
                Font = new Font("Arial", 12),
                PasswordChar = '*',
                BorderStyle = BorderStyle.FixedSingle
            };

            inpSenhaFam = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(150, 180),
                Font = new Font("Arial", 12),
                PasswordChar = '*',
                BorderStyle = BorderStyle.FixedSingle
            };


            inpLoginAdm = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(150, 240),
                Font = new Font("Arial", 12),
                PasswordChar = '*',
                BorderStyle = BorderStyle.FixedSingle
            };

            inpSenhaAdm = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(150, 300),
                Font = new Font("Arial", 12),
                PasswordChar = '*',
                BorderStyle = BorderStyle.FixedSingle
            };



            btnCadastrar = new Button
            {
                Text = "CADASTRAR",
                Location = new Point(150, 360),
                Size = new Size(120, 40),
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnCadastrar.Click += ClickCadastrar;


            PnlLogin = new Panel
            {
                MinimumSize = new Size(600, 600),
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
                Location = new Point(this.ClientSize.Width / 2 - 200, this.ClientSize.Height / 2 - 150)
            };

            Controls.Add(PnlLogin);
            PnlLogin.Controls.Add(lblTituloCadastro);
            PnlLogin.Controls.Add(lblNomeFam);
            PnlLogin.Controls.Add(lblLoginFam);
            PnlLogin.Controls.Add(lblSenhaFam);
            PnlLogin.Controls.Add(lblLoginAdm);
            PnlLogin.Controls.Add(lblSenhaAdm);
            PnlLogin.Controls.Add(inpNomeFam);
            PnlLogin.Controls.Add(inpLoginFam);
            PnlLogin.Controls.Add(inpSenhaFam);
            PnlLogin.Controls.Add(inpLoginAdm);
            PnlLogin.Controls.Add(inpSenhaAdm);
            PnlLogin.Controls.Add(btnCadastrar);
        }

        private void ClickCadastrar(object? sender, EventArgs e)
        {
            if(inpNomeFam.Text == "" || inpLoginFam.Text == "" || inpSenhaFam.Text == "" || inpLoginAdm.Text == "" || inpSenhaAdm.Text == ""){
                MessageBox.Show("Por favor, preencha todos os campos");
        }else{
        

        }
        }

        private void ClickLogar(object? sender, EventArgs e)
        {

        }

    }
>>>>>>> dad9419a33ba67bf1b4fba913663c0093ec3724d
}