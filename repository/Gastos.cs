using Model;
using MySqlConnector;

namespace Repo
{
    public class RepoGastos
    {
        private static MySqlConnection conexao;
        public static List<Gastos> gastos = [];
        public static List<Categorias>categorias = RepoCategoria.ListCategorias();
        public static List<Login> usuarioAtual = RepoLogin.Listar();
        public static List<Membros> membros = RepoMembros.ListarMembros();

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
            gastos.Clear();
            InitConexao();

            string query = "SELECT * FROM gastos, categorias WHERE idCategoria = idCategorias AND idUsuario = @IdUsuario";
            MySqlCommand command = new MySqlCommand(query, conexao);
            command.Parameters.AddWithValue("@IdUsuario", usuarioAtual[0].IdUsuario);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Gastos gasto = new Gastos();
                gasto.IdGastos = Convert.ToInt32(reader["idGastos"].ToString());
                gasto.IdUsuario = Convert.ToInt32(reader["idUsuario"].ToString());
                gasto.idCategoria = Convert.ToInt32(reader["idCategoria"].ToString());
                gasto.Nome = reader["nome"].ToString();
                gasto.Valor = "R$ " + Convert.ToString(reader["valor"].ToString());
                gasto.Data = Convert.ToDateTime(reader["data"].ToString());
                gasto.Categoria = reader["nomeCategoria"].ToString();
                gastos.Add(gasto);
            }

            CloseConexao();
            return gastos;
        }

        public static List<Gastos> SincronizarPadrão()
        {
            InitConexao();
            string query = "SELECT * FROM gastos, categorias WHERE idCategoria = idCategorias AND idUsuario = @IdUsuario";
            MySqlCommand command = new MySqlCommand(query, conexao);
            command.Parameters.AddWithValue("@IdUsuario", usuarioAtual[0].IdUsuario);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Gastos gasto = new Gastos();
                gasto.IdGastos = Convert.ToInt32(reader["idGastos"].ToString());
                gasto.IdUsuario = Convert.ToInt32(reader["idUsuario"].ToString());
                gasto.idCategoria = Convert.ToInt32(reader["idCategoria"].ToString());
                gasto.Nome = reader["nome"].ToString();
                gasto.Valor = "R$ " + Convert.ToString(reader["valor"].ToString());
                gasto.Data = Convert.ToDateTime(reader["data"].ToString());
                gasto.Categoria = reader["nomeCategoria"].ToString();

                gastos.Add(gasto);
            }

            CloseConexao();
            return gastos;
        }

        public static void CriarGasto(Gastos gasto)
        {
            InitConexao();

            string insert = "INSERT INTO gastos(idUsuario, idCategoria, nome, valor, data) VALUES(@IdUsuario, @IdCategoria, @Nome, @Valor, @Data)";
            MySqlCommand command = new MySqlCommand(insert, conexao);

            try
            {
                if (gasto.Nome == null || gasto.Valor == null || gasto.Data == null || gasto.Categoria == null)
                {
                    MessageBox.Show("Preencha todos os campos");
                }
                else
                {
                    for (int i = 0; i < categorias.Count; i++)
                    {
                        if (categorias[i].Nome == gasto.Categoria)
                        {  
                            command.Parameters.AddWithValue("@IdCategoria", categorias[i].IdCategorias);
                        }
                    }
                    command.Parameters.AddWithValue("@Nome", gasto.Nome);
                    command.Parameters.AddWithValue("@Valor", gasto.Valor);
                    command.Parameters.AddWithValue("@Data", gasto.Data);
                    command.Parameters.AddWithValue("@IdUsuario", usuarioAtual[0].IdUsuario);

                    int rowsAffected = command.ExecuteNonQuery();
                    gasto.IdGastos = Convert.ToInt32(command.LastInsertedId);
                    gasto.Valor = "R$ " + gasto.Valor;

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Gasto cadastrado com sucesso!");
                        gastos.Add(gasto);
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível cadastrar o gasto");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            CloseConexao();
        }

        public static void SincronizarIdCategoria(string categoria, int indice)
        {
            InitConexao();

            string query = "SELECT idCategorias FROM categorias WHERE nomeCategoria = @Categoria";
            MySqlCommand command = new MySqlCommand(query, conexao);
            command.Parameters.AddWithValue("@Categoria", categoria);
            MySqlDataReader reader = command.ExecuteReader();
            Gastos gasto = gastos[indice];

            while (reader.Read())
            {
                gasto.idCategoria = Convert.ToInt32(reader["idCategorias"].ToString());
            }

            CloseConexao();
        }

        public static void AlterarGasto(string nome, string valor, string data, int id, int indice)
        {
            // SincronizarIdCategoria(categoria, indice);    
            InitConexao();       


            string update = "UPDATE gastos SET idCategoria = @IdCategoria, nome = @Nome, valor = @Valor, data = @Data WHERE idGastos = @IdGastos";
            MySqlCommand command = new MySqlCommand(update, conexao);
            Gastos gasto = gastos[indice];

            try
            {
                if (nome == null || data == null || valor == null)
                {
                    MessageBox.Show("Gasto não encontrado");
                }
                else
                {
                    command.Parameters.AddWithValue("@IdUsuario", gasto.IdUsuario);
                    command.Parameters.AddWithValue("@IdGastos", gasto.IdGastos);
                    command.Parameters.AddWithValue("@IdCategoria", id);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Valor", valor);
                    command.Parameters.AddWithValue("@Data", data);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        gasto.Nome = nome;
                        gasto.Valor = "R$ " + valor;
                        gasto.Data = Convert.ToDateTime(data);
                        gasto.Categoria = categorias[id - 1].Nome;
                        gasto.idCategoria = id;

                        MessageBox.Show("Gasto alterado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show(rowsAffected.ToString());
                    }
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