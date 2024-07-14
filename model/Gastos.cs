using Microsoft.VisualBasic;
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
        public DateTime Data {get; set;}
        public string Categoria {get; set;}

        public static List<Gastos> ListarGastos()
        {
            return RepoGastos.ListarGastos();
        }

        public static List<string> ListarCategorias()
        {
            return RepoGastos.ListarCategorias();
        }

        public static List<Gastos> Sincronizar()
        {
            return RepoGastos.SincronizarAdm();
        }

        public static void AlterarGasto(string nome, string valor, string data, string categoria, int indice)
        {
            RepoGastos.AlterarGasto(nome, valor, data, categoria, indice);
        }

        public static void DeletarGasto(int indice)
        {
            RepoGastos.DeletarGasto(indice);
        }

    }
}