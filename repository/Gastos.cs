using Model;
using MySqlConnector;

namespace Repo
{
    public class RepoGastos
    {
        private static MySqlConnection conexao;
        public static List<Gastos> gastos = [];
        List<Login>usuarioAtual = RepoLogin.usuarioAtual;
        public static List<string> categorias = new List<string>{};

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

        public static List<string> ListarCategorias()
        {
            InitConexao();

            try
            {
            string nomeC = "";
            string query = "SELECT nomeCategoria FROM categorias";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                nomeC = reader["nomeCategoria"].ToString();
                categorias.Add(nomeC);
            } 
            }
            catch
            {
                MessageBox.Show("Não foi possível carregar as categorias");
            }         

            CloseConexao();
                
            return categorias;
        }

        public static List<Gastos> SincronizarAdm()
        {
            InitConexao();

            string query = "SELECT * FROM gastos, categorias WHERE idCategoria = idCategorias";
            MySqlCommand command = new MySqlCommand(query, conexao);
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
            // command.Parameters.AddWithValue("@Idusuario", usuarioAtual[0].IdUsuario);
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
                    command.Parameters.AddWithValue("@Nome", gasto.Nome);
                    command.Parameters.AddWithValue("@Valor", gasto.Valor);
                    command.Parameters.AddWithValue("@Data", gasto.Data);
                    command.Parameters.AddWithValue("@IdUsuario", 1);
                    command.Parameters.AddWithValue("@IdCategoria", 1);

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

        public static void AlterarGasto(string nome, string valor, string data, string categoria, int indice)
        {
            SincronizarIdCategoria(categoria, indice);    
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
                    command.Parameters.AddWithValue("@IdCategoria", gasto.idCategoria);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Valor", valor);
                    command.Parameters.AddWithValue("@Data", data);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        gasto.Nome = nome;
                        gasto.Valor = "R$ " + valor;
                        gasto.Data = Convert.ToDateTime(data);
                        gasto.Categoria = categoria;
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