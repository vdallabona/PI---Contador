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

        public Gastos()
        {
            
        }
        public Gastos(string nome, string valor, string data, string categoria)
        {
            Nome = nome;
            Valor = valor;
            Data = Convert.ToDateTime(data);
            Categoria = categoria;
            RepoGastos.CriarGasto(this);
        }

        public static List<Gastos> ListarGastos()
        {
            return RepoGastos.ListarGastos();
        }

        public static List<Gastos> Sincronizar()
        {
            if (RepoLogin.usuarioAtual[0].Adm == true)
            {
                return RepoGastos.SincronizarAdm();    
            }
            else
            {
                return RepoGastos.SincronizarPadrão();
            }

        }

        public static void AlterarGasto(string nome, string valor, string data, int id, int indice)
        {
            RepoGastos.AlterarGasto(nome, valor, data, id, indice);
        }

        public static void DeletarGasto(int indice)
        {
            RepoGastos.DeletarGasto(indice);
        }

    }
}