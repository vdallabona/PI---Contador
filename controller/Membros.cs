using Model;

namespace Controller
{
    public class ControllerMembros
    {
        public static List<Membros> ListarMembros()
        {
            return Membros.ListarMembros();
        }

        public static List<Membros> Sincronizar()
        {
            return Membros.Sincronizar();
        }

        public static void AlterarMembro(string nome, string login, string senha, int indice)
        {
            Membros.AlterarMembro(nome, login, senha, indice);
        }

        public static void CriarMembro(string nome, string login, string senha)
        {
            Membros.CriarMembro(nome, login, senha);
        }

        public static void DeletarMembro(int indice)
        {
            Membros.DeletarMembro(indice);
        }
    }
}