using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class ViewHomeAdm : Form
    {
        private readonly Form ParentForm;
        private readonly Label lblTituloHomePage;
        private readonly Button btnMembros;
        private readonly Button btnCategorias;
        private readonly Button btnGastos;
        private readonly Button btnEstatisticas;
        private readonly Button btnSair;

        public ViewHomeAdm(Form parent)
        {
            ParentForm = parent;
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(800, 600);
            BackColor = Color.White;
            Text = "Home Page";

            lblTituloHomePage = new Label
            {
                Text = "Home Page",
                Location = new Point(315, 40),
                Font = new Font("Arial", 22),
                AutoSize = true
            };

            btnMembros = new Button
            {
                Text = "Gerenciar Membros",
                Location = new Point(300, 100),
                Size = new Size(200, 50),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnMembros.Click += ClickMembros;

            btnCategorias = new Button
            {
                Text = "Gerenciar Categorias",
                Location = new Point(300, 200),
                Size = new Size(200, 50),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnCategorias.Click += ClickCategorias;


            btnGastos = new Button
            {
                Text = "Gerenciar Gastos",
                Location = new Point(300, 300),
                Size = new Size(200, 50),
                BackColor = Color.LightGray,
                Font = new Font("Arial", 10)
            };
            btnGastos.Click += ClickGastos;

            btnEstatisticas = new Button
            {
                Text = "Estatísticas",
                Location = new Point(300, 400),
                Size = new Size(200, 50),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnEstatisticas.Click += ClickEstatisticas;

            btnSair = new Button
            {
                Text = "Sair",
                Location = new Point(300, 500),
                Size = new Size(200, 50),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10)
            };
            btnSair.Click += ClickSair;

            Controls.Add(lblTituloHomePage);
            Controls.Add(btnMembros);
            Controls.Add(btnCategorias);
            Controls.Add(btnGastos);
            Controls.Add(btnEstatisticas);
            Controls.Add(btnSair);
        }

        private void ClickMembros(object? sender, EventArgs e)
        {
            
        }

        private void ClickCategorias(object? sender, EventArgs e)
        {

        }

        private void ClickGastos(object? sender, EventArgs e)
        {

        }

        private void ClickEstatisticas(object? sender, EventArgs e)
        {
            
        }

        private void ClickSair(object? sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja sair?", "Sair");
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }

        }
    }
}
