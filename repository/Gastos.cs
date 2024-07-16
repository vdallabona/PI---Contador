using Model;
using MySqlConnector;

namespace Repo
{
    public class RepoGastos
    {
        private static MySqlConnection conexao;
        public static List<Gastos> gastos = [];

        public static List<Gastos> ListarGastos()
        {
            return gastos;
        }
        public static void InitConexao()
        {
            string info = "server=localhost;database=financas; user id=root;password=''";
            conexao = new MySqlConnection(info);

            try
            {
                conexao.Open();
            }
            catch
            {
                MessageBox.Show("Não foi possível se conectar com o banco");
            }
        }

        public static void CloseConexao()
        {
            conexao.Close();
        }

        public static List<Gastos> SincronizarAdm()
        {
            InitConexao();

            string query = "SELECT * FROM gastos;";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Gastos gasto = new Gastos();

                gasto.IdGastos = Convert.ToInt32(reader["idGastos"].ToString());
                gasto.IdUsuario = Convert.ToInt32(reader["idUsuario"].ToString());
                gasto.idCategoria = Convert.ToInt32(reader["idCategoria"].ToString());
                gasto.Nome = reader["nome"].ToString();
                gasto.Valor = Convert.ToString(reader["valor"].ToString());
                gasto.Data = Convert.ToDateTime(reader["data"].ToString());
                gasto.Categoria = "";
                gastos.Add(gasto);
            }

            CloseConexao();
            return gastos;
        }

        public static List<Gastos> SincronizarCategoria()
        {
            // InitConexao();
            // string query = "SELECT nome FROM categorias WHERE idCategorias = @IdCategoria";
            // MySqlCommand command = new MySqlCommand(query, conexao);
            // MySqlDataReader reader = command.ExecuteReader();
            // for (int i = 0; i < gastos.Count; i++)
            // {
            //     command.Parameters.AddWithValue("@IdCategoria", gastos[i].idCategoria);

            //     while (reader.Read())
            //     {
            //         gastos[i].Categoria = reader["nome"].ToString();   
            //     }
            // }

            // CloseConexao();
            return gastos;
        }

        public static void AlterarGasto(string nome, string valor, string data, string categoria, int indice)
        {
            InitConexao();

            string update = "UPDATE gastos SET nome = @Nome, valor = @Valor, data = @Data WHERE idGastos = @IdGastos";
            MySqlCommand command = new MySqlCommand(update, conexao);
            Gastos gasto = gastos[indice];

            try
            {
                if (nome == null || data == null || valor == null)
                {
                    MessageBox.Show("Gasto não encontrada");
                }
                else
                {
                    command.Parameters.AddWithValue("@IdUsuario", gasto.IdUsuario);
                    command.Parameters.AddWithValue("@IdGastos", gasto.IdGastos);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Valor", valor);
                    command.Parameters.AddWithValue("@Data", data);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        gasto.Nome = nome;
                        gasto.Valor = valor;
                        gasto.Data = Convert.ToDateTime(data);
                    }
                    else
                    {
                        MessageBox.Show(rowsAffected.ToString());
                    }
                    MessageBox.Show("Gasto alterado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            CloseConexao();
        }

        public static void DeletarGasto(int indice)
        {
            InitConexao();

            string delete = "DELETE FROM gastos WHERE idGastos = @IdGastos";
            MySqlCommand command = new MySqlCommand(delete, conexao);
            command.Parameters.AddWithValue("@IdGastos", gastos[indice].IdGastos);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                gastos.RemoveAt(indice);
                MessageBox.Show("Gasto deletado com sucesso!");
            }
            else
            {
                MessageBox.Show("Gasto não encontrado");
            }

            CloseConexao();
        }

    }
}