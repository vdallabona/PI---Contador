using Repo;

namespace Model
{
    public class Login
    {
        public int IdUsuario {get; set;}
        public int IdFamilia {get; set;}
        public string? Nome {get; set;}
        public string? User {get; set;}
        public string? Senha {get; set;}
        public bool Adm {get; set;}

        public static void Verificar(string login, string senha)
        {
            RepoLogin.Verificar(login, senha);
        }
        public static List<Login> Listar()
        {
            return RepoLogin.Listar();
        }

    }
}