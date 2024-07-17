using Model;

namespace Controller
{
    public class ControllerLogin
    {
        public static void Verificar(string user, string senha)
        {
            Login.Verificar(user, senha);
        }
        public static List<Login> Listar()
        {
            return Login.Listar();
        }

        
    }
}