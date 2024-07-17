using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySqlConnector;
using Model;

namespace Repo
{
    public class RepoCategoria
    {
        private static MySqlConnection conexao;
        private static List<Categorias> categorias = new List<Categorias>();

        public static List<Categorias> ListCategorias()
        {
            return categorias;
        }

        public static Categorias? ListarCategoria(int index)
        {
            if (index < 0 || index >= categorias.Count)
            {
                return null;
            }
            else
            {
                return categorias[index];
            }
        }

        public static void InitConexao()
        {
            string info = "server=localhost;database=financas;user id=root;password=''";
            conexao = new MySqlConnection(info);
            try
            {
                conexao.Open();
            }
            catch
            {
                MessageBox.Show("Não deu, foi mal");
            }
        }

        public static void CloseConexao()
        {
            conexao.Close();
        }

        public static List<Categorias> Sincronizar()
        {
            categorias.Clear(); 
            InitConexao();
            string query = "SELECT * FROM categorias";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Categorias categoria = new Categorias
                {
                    IdCategorias = Convert.ToInt32(reader["idCategorias"]),
                    Nome = reader["nome"].ToString()
                };
                categorias.Add(categoria);
            }
            CloseConexao();
            return categorias;
        }

        public static void Criar(Categorias categoria)
        {
            InitConexao();
            string insert = "INSERT INTO categorias (nome) VALUES (@Nome)";
            MySqlCommand command = new MySqlCommand(insert, conexao);
            try
            {
                if (categoria.Nome == null)
                {
                    MessageBox.Show("Deu ruim, favor preencher a categoria");
                }
                else
                {
                    command.Parameters.AddWithValue("@Nome", categoria.Nome);
                    int rowsAffected = command.ExecuteNonQuery();
                    categoria.IdCategorias = Convert.ToInt32(command.LastInsertedId);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Categoria cadastrada com sucesso");
                        categorias.Add(categoria);
                    }
                    else
                    {
                        MessageBox.Show("Deu ruim, não deu pra adicionar");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Deu ruim: " + e.Message);
            }

            CloseConexao();
        }

        public static void UpdateCategoria(int indice, string nome)
        {
            InitConexao();
            string query = "UPDATE categorias SET nome = @Nome WHERE IdCategorias = @IdCategorias";
            MySqlCommand command = new MySqlCommand(query, conexao);
            Categorias categoria = categorias[indice];
            try
            {
                if (nome != null)
                {
                    command.Parameters.AddWithValue("@IdCategorias", categoria.IdCategorias);
                    command.Parameters.AddWithValue("@Nome", nome);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        categoria.Nome = nome;
                    }
                    else
                    {
                        MessageBox.Show(rowsAffected.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro durante a execução do comando: " + ex.Message);
            }
            CloseConexao();
        }
    }
}
