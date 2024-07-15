using Model;

namespace Controller
{
    public class ControllerGastos
    {
        public static List<Gastos> ListarGastos()
        {
            return Gastos.ListarGastos();
        }

        public static List<string> ListarCategorias()
        {
            return Gastos.ListarCategorias();
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

        public static void AlterarGasto(string nome, string valor, string data, string categoria, int indice)
        {
            Gastos.AlterarGasto(nome, valor, data, categoria, indice);
        }

        public static void DeletarGasto(int indice)
        {
            Gastos.DeletarGasto(indice);
        }
    }
}