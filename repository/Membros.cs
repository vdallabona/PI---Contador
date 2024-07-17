using System.Runtime.InteropServices.Marshalling;
using Model;
using MySqlConnector;

namespace Repo
{
    public class RepoMembros
    {
        private static MySqlConnection? conexao;
        public static List<Membros> membros = [];
        List<Login>usuarioAtual = RepoLogin.usuarioAtual;
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
            membros.Clear();
            InitConexao();

            string query = "SELECT * FROM usuarios WHERE idFamilia = @idFamilia;";
            MySqlCommand command = new MySqlCommand(query, conexao);
            command.Parameters.AddWithValue("@idFamilia", RepoLogin.usuarioAtual[0].IdFamilia);
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

        public static void LoginExiste(Membros membro){
            InitConexao();
            string checkQuery = "SELECT COUNT(*) FROM usuarios WHERE Login = @Login;";
            MySqlCommand checkCommand = new MySqlCommand(checkQuery, conexao);
            checkCommand.Parameters.AddWithValue("@Login", membro.Login);
            int count = Convert.ToInt32(checkCommand.ExecuteScalar());
            if (count > 0)
            {
                MessageBox.Show("Login já existe, por favor escolha outro login.");
                return;
            }else{
                CriarMembro(membro);
            }
            CloseConexao();
        }
        public static void LoginExisteAlt(string nome, string login, string senha, int indice){
            InitConexao();
            string checkQuery = "SELECT COUNT(*) FROM usuarios WHERE Login = @Login;";
            MySqlCommand checkCommand = new MySqlCommand(checkQuery, conexao);
            checkCommand.Parameters.AddWithValue("@Login", login);
            int count = Convert.ToInt32(checkCommand.ExecuteScalar());
            if (count > 0)
            {
                MessageBox.Show("Login já existe, por favor escolha outro login.");
                return;
            }else{
                AlterarMembros(nome, login, senha, indice);
            }
            CloseConexao();
        }

        public static void CriarMembro(Membros membro)
        {
            InitConexao();
            if (membro.Nome == "" || membro.Login == "" || membro.Senha == "")
            {
                MessageBox.Show("Preencha todos os campos");
            }
            else
            { 
                string query = "INSERT INTO usuarios (idFamilia, Nome, Login, Senha, adm) VALUES (@idFamilia, @Nome, @Login, @Senha, '1');";
                MySqlCommand command = new MySqlCommand(query, conexao);
                command.Parameters.AddWithValue("@Nome", membro.Nome);
                command.Parameters.AddWithValue("@Login", membro.Login);
                command.Parameters.AddWithValue("@Senha", membro.Senha);
                membro.idFamilia = RepoLogin.usuarioAtual[0].IdFamilia;
                command.Parameters.AddWithValue("@idFamilia", membro.idFamilia);
                command.ExecuteNonQuery();
                membros.Add(membro);
                MessageBox.Show("Tarefa adicionada com sucesso!");
            }
            CloseConexao();
        }

        public static void DeletarMembro(int indice)
        {
            InitConexao();

            string delete = "UPDATE usuarios SET Login = 'USUARIO DELETADO', Senha = '' WHERE idUsuario = @idUsuario";
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