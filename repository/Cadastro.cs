using Model;
using MySqlConnector;

namespace Repo {

    public class RepoCadastro {

        List<Login> usuarioAtual = RepoLogin.usuarioAtual;
        private static MySqlConnection conexao;

        private static List<Familias> familias = new List<Familias>();

        public static List<Familias> ListFamilia() {
            return familias;
        }

        private static List<Usuarios> usuarios = new List<Usuarios>();

        public static List<Usuarios> ListUsuario() {
            return usuarios;
        }

        public static void InitConexao() {
            string info = "server=localhost;database=financas; user id=root;password=''";
            conexao = new MySqlConnection(info);

            try {
                conexao.Open();
            } catch {
                MessageBox.Show("Não foi possível se conectar com o banco");
            }
        }

        public static void CloseConexao() {
            conexao.Close();
        }

        public static List<Familias> SincronizarF() {
            familias.Clear(); 
            InitConexao();
            string query = "SELECT * FROM familia";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                Familias familia = new Familias {
                    IdFamilia = Convert.ToInt32(reader["idFamilia"]),
                    Nome = reader["nomeFamilia"].ToString()
                };
                familias.Add(familia);
            }
            CloseConexao();
            return familias;
        }

        public static void CriarF(Familias familia) {
            InitConexao();
            string insert = "INSERT INTO familia (nomeFamilia) VALUES (@Nome)";
            MySqlCommand command = new MySqlCommand(insert, conexao);
            try {
                if (familia.Nome == null) {
                    MessageBox.Show("Deu ruim, favor preencher o nome");
                } else {
                    command.Parameters.AddWithValue("@Nome", familia.Nome);
                    int rowsAffected = command.ExecuteNonQuery();
                    familia.IdFamilia = Convert.ToInt32(command.LastInsertedId);

                    if (rowsAffected > 0) {
                        MessageBox.Show("Familia cadastrada com sucesso");
                        familias.Add(familia);
                    } else {
                        MessageBox.Show("Deu ruim, não deu pra adicionar");
                    }
                }
            } catch (Exception e) {
                MessageBox.Show("Deu ruim: " + e.Message);
            }

            CloseConexao();
        }

        public static List<Usuarios> SincronizarU() {
            usuarios.Clear(); 
            InitConexao();
            string query = "SELECT * FROM usuarios";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                Usuarios usuario = new Usuarios {
                    IdUsuario = Convert.ToInt32(reader["idUsuario"]),
                    IdFamilia = Convert.ToInt32(reader["idFamilia"]),
                    Nome = reader["nome"].ToString(),
                    Login = reader["login"].ToString(),
                    Senha = reader["senha"].ToString(),
                    Adm = Convert.ToBoolean(reader["adm"])
                };
                usuarios.Add(usuario);
            }
            CloseConexao();
            return usuarios;
        }

        public static void CriarU(Usuarios usuario) {
            InitConexao();
            string insert = "INSERT INTO usuarios (idFamilia, Nome, Login, Senha, Adm) VALUES (@idFamilia, @Nome, @Login, @Senha, '1')";
            MySqlCommand command = new MySqlCommand(insert, conexao);
            try {
                if (usuario.Nome == null || usuario.Login == null || usuario.Senha == null) {
                    MessageBox.Show("Deu ruim, favor preencher todas as tabelas");
                } else {   
                    command.Parameters.AddWithValue("@idFamilia", usuario.IdFamilia);
                    command.Parameters.AddWithValue("@Nome", usuario.Nome);
                    command.Parameters.AddWithValue("@Login", usuario.Login);
                    command.Parameters.AddWithValue("@Senha", usuario.Senha);
                    int rowsAffected = command.ExecuteNonQuery();
                    
                    usuario.IdUsuario = Convert.ToInt32(command.LastInsertedId);

                    if (rowsAffected > 0) {
                        MessageBox.Show("Usuario cadastrado com sucesso");
                        usuarios.Add(usuario);
                    } else {
                        MessageBox.Show("Deu ruim, não deu pra adicionar");
                    }
                }
            } catch (Exception e) {
                MessageBox.Show("Deu ruim: " + e.Message);
            }

            CloseConexao();
        }
    }
}
