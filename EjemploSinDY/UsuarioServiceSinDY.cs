namespace EjemploEnClase.EjemploSinDY
{
    public class UsuarioServiceSinDY // clase que llama al metodo de enviar email
    {
        // propiedad que es un objeto en el constructor
        public EmailServiceSinDY emailServiceSinDY { get; set; }

        public UsuarioServiceSinDY()
        {
            // se instancia el objeto, aqui se esta creando una dependencia
            // inicializamos el objeto y luego puedo accesder a los metodos de la
            // clase EmailServiceSinDY que es Enviar y enviarNotificacion
            emailServiceSinDY = new EmailServiceSinDY();
            // this.Enviar(email, "notificación"); cuando invocamos al metodo en la misma clase
            // pero se hace inmantenible el codigo

        }
        //metodo que llama al metodo de enviar email
        public bool EnviarNotificacionUsuario(string email)
        {
            
            emailServiceSinDY.Enviar(email, "notificación");
            return true;
        }

        // Podria no tener la clase EmailService y tener el metodo Enviar en esta clase
        // pero no es lo correcto, ya que se esta violando el principio de responsabilidad
        // unica, ya que esta clase deberia tener solo la responsabilidad de enviar notificaciones
        // y no de enviar emails en general

        // public bool Enviar(string email, string subject)
        // {
        //     // Aquí iría la lógica para enviar un email
        //     // se envia el mail de notificacion  
        //     return true;
        // }

        // En este metodo tendria que tener todo lo referido al usuario
        // cambio de contraseña, cambio de email, etc
        // pero no la funcionalidad de enviar email
        // para eso tengo la clase EmailService que se encarga de enviar emails

        // Se deben independizar las clases cada una con su responsabilidad



    }
}
