using Model;
 
namespace Controller {
    public class ControllerCategorias {
 
        public static void Sincronizar(){
            Categorias.Sincronizar();
        }
        public static void CriarCategoria(
            string nome
        ) {
           
            new Categorias(
                nome
            );
        }
 
        public static List<Categorias> ListarCategorias() {
            return Categorias.ListarCategorias();
        }
 
        public static void AlterarCategoria(
            int indice,
            string nome
        ) {
            Categorias.AlterarCategorias(
                indice,
                nome
            );
        }
 
      
    }
}