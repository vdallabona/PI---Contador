using Model;
using Repo;

namespace Controller {

    public class ControllerCadastro {
        private static int ultimoIdFamiliaInserida;

        public static void SincronizarF() {
            RepoCadastro.SincronizarF();
        }

        public static void CriarFamilia(string nomeFamilia) {
            var familia = new Familias(nomeFamilia);
            ultimoIdFamiliaInserida = familia.IdFamilia;
        }

        public static void SincronizarU() {
            RepoCadastro.SincronizarU();
        }

        public static void CriarUsuario(string nome, string login, string senha) {
            new Usuarios(nome, login, senha, ultimoIdFamiliaInserida);
        }
    }
}
