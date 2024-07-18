using System;
using System.Drawing;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public class ViewCadastro : Form
    {
        
        private readonly Form ParentForm;
        private readonly Label lblTituloCadastro;
        
        private readonly Label lblNomeFam;        

        private readonly Label lblNomeUser;

        private readonly Label lblLoginAdm;
        private readonly Label lblSenhaAdm;
        private readonly TextBox inpNomeFam;

        private readonly TextBox inpNomeUser;
        private readonly TextBox inpLoginAdm;

        private readonly TextBox inpSenhaAdm;
        
        private readonly Button btnCadastrar;
        private readonly Button btnLogar;


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

            

            lblNomeUser= new Label
            {
                Text = "Nome Usuário",
                Location = new Point(0, 120),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

             lblLoginAdm = new Label
            {
                Text = "Login do Adm",
                Location = new Point(0, 180),
                Font = new Font("Arial", 12),
                AutoSize = true
            };

            lblSenhaAdm = new Label
            {
                Text = "Senha do Adm",
                Location = new Point(0, 240),
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


            inpNomeUser = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(150, 120),
                Font = new Font("Arial", 12),
                BorderStyle = BorderStyle.FixedSingle
            };

            inpLoginAdm = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(150, 180),
                Font = new Font("Arial", 12),
                BorderStyle = BorderStyle.FixedSingle
            };

            inpSenhaAdm = new TextBox
            {
                Size = new Size(200, 30),
                Location = new Point(150, 240),
                Font = new Font("Arial", 12),
                PasswordChar = '*',
                BorderStyle = BorderStyle.FixedSingle
            };




            btnCadastrar = new Button
            {
                Text = "CADASTRAR",
                Location = new Point(50, 310),
                Size = new Size(120, 40),
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnCadastrar.Click += ClickCadastrar;

            btnLogar = new Button
            {
                Text = "LOGAR",
                Location = new Point(230, 310),
                Size = new Size(120, 40),
                BackColor = Color.LightBlue,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnLogar.Click += ClickLogar;


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
            PnlLogin.Controls.Add(lblNomeUser);
            PnlLogin.Controls.Add(lblLoginAdm);
            PnlLogin.Controls.Add(lblSenhaAdm);
            PnlLogin.Controls.Add(inpNomeFam);
            PnlLogin.Controls.Add(inpNomeUser);
            PnlLogin.Controls.Add(inpLoginAdm);
            PnlLogin.Controls.Add(inpSenhaAdm);
            PnlLogin.Controls.Add(btnCadastrar);
            PnlLogin.Controls.Add(btnLogar);

        }

        private void ClickCadastrar(object? sender, EventArgs e)
        {
            string nomeFamilia = inpNomeFam.Text;
            if(inpNomeFam.Text == ""  || inpNomeUser.Text == "" || inpLoginAdm.Text == "" || inpSenhaAdm.Text == ""){
                MessageBox.Show("Por favor, preencha todos os campos");
            }
            
            if (!string.IsNullOrWhiteSpace(nomeFamilia))
            {
                ControllerCadastro.CriarFamilia(nomeFamilia);
                inpNomeFam.Clear();

            }
            else
            {
                MessageBox.Show("O nome da família não pode estar vazio.");
            }

            string nome = inpNomeUser.Text;
            string login = inpLoginAdm.Text;
            string senha = inpSenhaAdm.Text;
            if (!string.IsNullOrWhiteSpace(nome) && !string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(senha))
            {
                ControllerCadastro.CriarUsuario(nome, login, senha);
                inpNomeUser.Clear();
                Hide();
                new ViewLogin().Show();
            }
            else
            {
                MessageBox.Show("Todos os campos devem estar preenchidos.");
            }
        
        }

        private void ClickLogar(object? sender, EventArgs e)
        {
            Hide();
            new ViewLogin().Show();

        }

    }
}