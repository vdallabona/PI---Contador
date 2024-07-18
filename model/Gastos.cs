using Repo;

namespace Model
{
    public class Gastos
    {
        public int IdGastos {get; set;}
        public int IdUsuario {get; set;}
        public int IdCategoria {get; set;}
        public string Nome {get; set;}
        public string Valor {get; set;}
        public DateTime Data {get; set;}
        public string Categoria {get; set;}
        public string Membro {get; set;}

        public Gastos()
        {
            
        }
        public Gastos(string nome, string valor, string data, string categoria, int id, string membro)
        {
            Nome = nome;
            Valor = valor;
            Data = Convert.ToDateTime(data);
            Categoria = categoria;
            IdCategoria = id;
            Membro = membro;
            RepoGastos.CriarGasto(this);
        }

        public static List<Gastos> ListarGastos()
        {
            return RepoGastos.ListarGastos();
        }

        public static List<int> ContarMembros()
        {
            return RepoGastos.ContarMembros();
        }

        public static List<Gastos> Sincronizar()
        {
            if (RepoLogin.usuarioAtual[0].Adm == true)
            {
                return RepoGastos.SincronizarAdm();
            }
            else
            {
                return RepoGastos.SincronizarPadrao();
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