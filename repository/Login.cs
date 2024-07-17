using Model;
using MySqlConnector;

namespace Repo
{
    public class RepoLogin
    {
        private static MySqlConnection conexao;
        public static List<Login> usuarioAtual = [];

        public static List<Login> Listar()
        {
            return usuarioAtual;
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

        public static void Verificar(string login, string senha)
        {
            InitConexao();

            try
            {
                string query = "SELECT * FROM usuarios WHERE login = @Login AND senha = @Senha";
                MySqlCommand command = new MySqlCommand(query, conexao);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Senha", senha);
                MySqlDataReader reader = command.ExecuteReader();
                Login usuario = new Login();

                while (reader.Read())
                {
                usuario.IdUsuario = Convert.ToInt32(reader["idUsuario"].ToString());
                usuario.IdFamilia = Convert.ToInt32(reader["idFamilia"].ToString());
                usuario.Nome = reader["nome"].ToString();
                usuario.User = reader["login"].ToString();
                usuario.Senha = reader["senha"].ToString();
                usuario.Adm = Convert.ToBoolean(reader["adm"].ToString());
                usuarioAtual.Add(usuario);
                }

                if (usuario.IdUsuario > 0)
                {
                    MessageBox.Show("Seja bem vindo!");
                }
                else
                {
                    MessageBox.Show("Usuário ou senha incorretos!");
                }
            }
            catch
            {
            }
            CloseConexao();
        }
    }
}