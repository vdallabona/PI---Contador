using Model;
using MySqlConnector;

namespace Repo
{
    public class RepoMembros
    {
        private static MySqlConnection? conexao;
        public static List<Membros> membros = [];

        public static List<Membros> ListarMembros()
        {
            return membros;
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

        public static List<Membros> SincronizarMembros()
        {
            InitConexao();

            string query = "SELECT * FROM usuarios;";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Membros membro = new Membros();
                membro.IdUsuario = Convert.ToInt32(reader["idUsuario"].ToString());
                membro.Nome = reader["nome"].ToString();
                membro.Login = Convert.ToString(reader["Login"].ToString());
                membro.Senha = reader["Senha"].ToString();
                membros.Add(membro);
            }

            CloseConexao();
            return membros;
        }

        public static void AlterarMembros(string nome, string login, string senha, int indice)
        {
            InitConexao();

            string update = "UPDATE usuarios SET Nome = @Nome, Login = @Login, Senha = @Senha WHERE idUsuario = @idUsuario";
            MySqlCommand command = new MySqlCommand(update, conexao);
            Membros membro = membros[indice];

            try
            {
                if (nome == null || login == null || senha == null)
                {
                    MessageBox.Show("Usuario não encontrada");
                }
                else
                {
                    command.Parameters.AddWithValue("@IdUsuario", membro.IdUsuario);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Senha", senha);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        membro.Nome = nome;
                        membro.Login = login;
                        membro.Senha = senha;
                        MessageBox.Show("Usuário alterado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao alterar membro");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            CloseConexao();
        }

        public static void CriarMembro(Membros membro)
        {
            InitConexao();

            string query = "INSERT INTO usuarios (idFamilia, Nome, Login, Senha, adm) VALUES ('1', @Nome, @Login, @Senha, '1');";
            MySqlCommand command = new MySqlCommand(query, conexao);

            if (membro.Nome == "" || membro.Login == "" || membro.Senha == "")
            {
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                command.Parameters.AddWithValue("@Nome", membro.Nome);
                command.Parameters.AddWithValue("@Login", membro.Login);
                command.Parameters.AddWithValue("@Senha", membro.Senha);
                membro.idFamilia = '1';
                command.ExecuteNonQuery();
                membros.Add(membro);
                MessageBox.Show("Tarefa adicionada com sucesso!");
            }

            CloseConexao();
        }

        public static void DeletarMembro(int indice)
        {
            InitConexao();

            string delete = "DELETE FROM usuarios WHERE idUsuario = @IdUsuario";
            MySqlCommand command = new MySqlCommand(delete, conexao);
            command.Parameters.AddWithValue("@IdUsuario", membros[indice].IdUsuario);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                membros.RemoveAt(indice);
                MessageBox.Show("Usuário deletado com sucesso!");
            }
            else
            {
                MessageBox.Show("Usuário não encontrado");
            }

            CloseConexao();
        }

    }
}