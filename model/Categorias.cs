
using Repo;

namespace Model {
    public class Categorias {
        public int IdCategorias { get; set; }
        public string Nome { get; set; }
      

        public Categorias() {}

        public Categorias(string nome) {
            Nome = nome;
           

            RepoCategoria.Criar(this);
        }

        public static List<Categorias> Sincronizar() {
            return RepoCategoria.Sincronizar();
        }

        public static List<Categorias> ListarCategorias() {
            return RepoCategoria.ListCategorias();
        }

        public static void AlterarCategorias(
            int indice,
            string nome
        ){  
            RepoCategoria.UpdateCategoria(indice, nome);
        }

       
 
    }
}