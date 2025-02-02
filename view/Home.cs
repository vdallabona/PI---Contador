using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class ViewHome : Form
    {
    
        private readonly Label lblTituloHome;
        private readonly Button btnGastos;
        private readonly Button btnSair;
        private readonly Button btnEstatistica;
        private readonly Panel PnlLogin;
        private readonly Form ParentForm;

        public ViewHome(Form parent)
        {
            ParentForm = parent;
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(800, 600);
            BackColor = Color.White;
            Text = "Home";

            lblTituloHome = new Label
            {
                Text = "Gerenciador de gastos",
                Location = new Point(10, 0),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 28),
                AutoSize = true
            };

            btnGastos = new Button
            {
                Text = "Gastos",
                Location = new Point(150, 100),
                Size = new Size(120, 40),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnGastos.Click += ClickGastos;

           
            btnEstatistica = new Button
            {
                Text = "Estatistica",
                Location = new Point(150, 150),
                Size = new Size(120, 40),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnEstatistica.Click += ClickEstatistica;

            btnSair = new Button
            {
                Text = "Sair",
                Location = new Point(150, 200),
                Size = new Size(120, 40),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnSair.Click += ClickSair;

            PnlLogin = new Panel
            {
                MinimumSize = new Size(400, 400),
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.None,
                Location = new Point(this.ClientSize.Width / 2 - 200, this.ClientSize.Height / 2 - 150)
            };

            Controls.Add(PnlLogin);

            PnlLogin.Controls.Add(lblTituloHome);
            PnlLogin.Controls.Add(btnGastos);
            PnlLogin.Controls.Add(btnEstatistica);
            PnlLogin.Controls.Add(btnSair);
        }

        private void ClickGastos(object? sender, EventArgs e)
        {
            var viewGastos = new ViewGastos();
            // Verifica se já existe uma instância de ViewGastos
            if (viewGastos == null || viewGastos.IsDisposed)
            {
                viewGastos = new ViewGastos();
            }

            

            // Oculta o formulário atual
            this.Hide();

            // Exibe o formulário de Gastos
            viewGastos.Show();
        }
        private void ClickEstatistica(object? sender, EventArgs e)
     
        {
            MessageBox.Show("Área ainda não disponivel");
        
        }

        private void ClickSair(object? sender, EventArgs e)
        {
            // Fecha todos os formulários abertos
            foreach (Form form in Application.OpenForms)
            {
                form.Close();
            }
        }

    }

}