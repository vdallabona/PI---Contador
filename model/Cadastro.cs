using Repo;

namespace Model{

    public class Familias{
        public int IdFamilia { get; set; }
        public string Nome { get; set; }

        public Familias() {}

        public Familias(string nomeFamilia) {
            Nome = nomeFamilia;
            RepoCadastro.CriarF(this);
        }

        public static List<Familias> Sincronizar() {
            return RepoCadastro.SincronizarF();
        }
    }

    public class Usuarios{
        public int IdUsuario { get; set; }
        public int IdFamilia { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Adm { get; set; }

        public Usuarios() {}

        public Usuarios(string nome, string login, string senha, int idFamilia) {
            Nome = nome;
            Login = login;
            Senha = senha;
            IdFamilia = idFamilia;

            RepoCadastro.LoginExisteCad(this);
        }

        public static List<Usuarios> Sincronizar() {
            return RepoCadastro.SincronizarU();
        }
    }
}
