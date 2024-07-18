using Model;

namespace Controller
{
    public class ControllerLogin
    {
        public static void Verificar(string login, string senha)
        {
            Login.Verificar(login, senha);
        }
        public static List<Login> Listar()
        {
            return Login.Listar();
        }

        
    }
}