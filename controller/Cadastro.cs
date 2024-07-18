using Model;
using Repo;

namespace Controller{

    public class ControllerCadastro{


        public static void SincronizarF(){
            RepoCadastro.SincronizarF();
        }

        public static void CriarFamilia(
            string nomeFamilia
        ) {
           
            new Familias(
                nomeFamilia
            );
        }

        public static void SincronizarU(){
            RepoCadastro.SincronizarU();
        }

        public static void CriarUsuario(
            string nome,
            string login,
            string senha
        ){
            new Usuarios(
                nome,
                login,
                senha
            );
        }
    }
    
    

}