using Repo;

namespace Model
{
    public class Gastos
    {
        public int IdGastos {get; set;}
        public int IdUsuario {get; set;}
        public int idCategoria {get; set;}
        public string Nome {get; set;}
        public string Valor {get; set;}
        public string Data {get; set;}

        public static List<Gastos> ListarGastos()
        {
            return RepoGastos.ListarGastos();
        }

        public static List<Gastos> Sincronizar()
        {
            return RepoGastos.Sincronizar();
        }

    }
}