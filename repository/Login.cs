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

        public static void Verificar(string user, string senha)
        {
            InitConexao();

            try
            {
                string query = "SELECT * FROM usuarios WHERE login = @User AND senha = @Senha";
                MySqlCommand command = new MySqlCommand(query, conexao);
                MessageBox.Show("1");
                MySqlDataReader reader = command.ExecuteReader();
                command.Parameters.AddWithValue("@Login", user);
                MessageBox.Show(user);
                command.Parameters.AddWithValue("@Senha", senha);
                MessageBox.Show(senha);
                Login usuario = new Login();

                usuario.IdUsuario = Convert.ToInt32(reader["idUsuario"].ToString());
                usuario.IdFamilia = Convert.ToInt32(reader["idFamilia"].ToString());
                usuario.Nome = reader["nome"].ToString();
                usuario.User = reader["login"].ToString();
                usuario.Senha = reader["senha"].ToString();
                usuario.Adm = Convert.ToBoolean(reader["adm"].ToString());

                usuarioAtual.Add(usuario);
            }
            catch
            {
                MessageBox.Show("Usuário ou senha incorretos!");
            }
            CloseConexao();
        }
    }
}