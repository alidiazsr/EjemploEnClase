using EjemploEnClase.EjemploConDY;


namespace EjemploEnClase.EjemploConDY
{
    public class UsuarioServiceconDY
    {
        private IEmailServiceconDY _emailServiceconDY;

        public UsuarioServiceconDY(IEmailServiceconDY emailServiceconDY)
        {
            _emailServiceconDY = emailServiceconDY;

        }

        public bool EnviarNotificacionUsuarioconDY(string email)
        {
            _emailServiceconDY.Enviar(email, "Notificacion");
            return true;
        }
    }
}
