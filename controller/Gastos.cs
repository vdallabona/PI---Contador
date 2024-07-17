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

        public static void CriarGasto(string nome, string valor, string data, string categoria)
        {
            new Gastos(
                nome,
                valor,
                data,
                categoria
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