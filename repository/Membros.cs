using Model;
using MySqlConnector;

namespace Repo{
    public class RepoMembros {
        private static MySqlConnection conexao;
        static public List<Usuarios> usuarios = new List<Usuarios>();

        public static void InitConexao(){
            conexao = new MySqlConnection("server=localhost;database=financas;user id=root;password=''");
            try{
                conexao.Open();
            }
            catch{
                MessageBox.Show("Não foi possível estabelecer conexão com banco de dados");
            }
        }
        public static void CloseConexao(){
            conexao.Close();
        }

        public static void Sincronizar(){
            InitConexao();
            string query = "SELECT * FROM usuarios WHERE adm = 0";
            MySqlCommand command = new MySqlCommand(query, conexao);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read()){
                Tarefa usuario = new Tarefa();
                usuario.Nome = reader["nome"].ToString() ?? "";
                usuario.Data = reader["login"].ToString() ?? "";
                usuario.Hora = reader["senha"].ToString() ?? "";
                tarefas.Add(usuario);
            }
            CloseConexao();
        }
        public static void Delete(int index){
            InitConexao();
            string delete = "DELETE FROM usuario WHERE idUsuario = @idUsuario";
            MySqlCommand command = new MySqlCommand(delete, conexao);
            command.Parameters.AddWithValue("@idUsuario", usuarios[index].idUsuario);

            int rowsAffected = command.ExecuteNonQuery();
            if(rowsAffected > 0){
                usuarios.RemoveAt(index);
                MessageBox.Show("Deletado com sucesso");
            }else{
                MessageBox.Show("Pessoa não encontrada");
            }
            CloseConexao();
        }
        public static void Add(int idUsuario, int idFamilia, string Nome, string Login, string Senha, int adm){
            InitConexao();
            string adicionar = "INSERT INTO usuarios (idUsuario, idFamilia, Nome, Login, Senha, adm) VALUES ('', @nome, @data, @hora);";
            MySqlCommand command = new MySqlCommand(adicionar, conexao);
            command.Parameters.AddWithValue("@idUsuario", idusuario);
            command.Parameters.AddWithValue("@idFamilia", idFamilia);
            command.Parameters.AddWithValue("@Nome", Nome);
            command.Parameters.AddWithValue("@Login", Login);
            command.Parameters.AddWithValue("@Senha", Senha);
            command.Parameters.AddWithValue("@adm", adm);

            usuarios.Add();
            CloseConexao();
        }
    }
}