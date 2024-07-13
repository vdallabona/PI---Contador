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
            string info = "server=localhost;database=pi; user id=root;password=''";
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

        public static List<Gastos> Sincronizar()
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
                gasto.Valor = "R$ " + reader["valor"].ToString();
                gasto.Data = reader["data"].ToString();
                gastos.Add(gasto);
            }

            CloseConexao();
            return gastos;
        }

    }
}