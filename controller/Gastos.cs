using Model;

namespace Controller
{
    public class ControllerGastos
    {
        public static List<Gastos> ListarGastos()
        {
            return Gastos.ListarGastos();
        }

        public static List<Gastos> Sincronizar()
        {
            return Gastos.Sincronizar();
        }

        public static List<int> ContarMembros()
        {
            return Gastos.ContarMembros();
        }

        public static void CriarGasto(string nome, string valor, string data, string categoria, int id, string membro)
        {
            new Gastos(
                nome,
                valor,
                data,
                categoria,
                id,
                membro
            );
        }

        public static void AlterarGasto(string nome, string valor, string data, int id, int indice)
        {
            Gastos.AlterarGasto(nome, valor, data, id, indice);
        }

        public static void DeletarGasto(int indice)
        {
            Gastos.DeletarGasto(indice);
        }
    }
}