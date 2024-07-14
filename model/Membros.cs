using Microsoft.VisualBasic;
using Repo;

namespace Model
{
    public class Membros
    {
        public int IdUsuario {get; set;}
        public int idFamilia {get; set;}
        public string? Nome {get; set;}
        public string? Login {get; set;}
        public string? Senha {get; set;}
        public int adm {get; set;}

        public static List<Membros> ListarMembros()
        {
            return RepoMembros.ListarMembros();
        }

        public static List<Membros> Sincronizar()
        {
            return RepoMembros.SincronizarMembros();
        }

        public static void AlterarMembro(string nome, string login, string senha, int indice)
        {
            RepoMembros.AlterarMembros(nome, login, senha, indice);
        }

        public static void DeletarMembro(int indice)
        {
            RepoMembros.DeletarMembro(indice);
        }

    }
}