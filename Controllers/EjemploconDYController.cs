using EjemploEnClase.EjemploConDY;
using EjemploEnClase.EjemploSinDY;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEnClase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjemploconDYController : ControllerBase
    {
        private IEmailServiceconDY _emailServiceconDY;

        public EjemploconDYController(IEmailServiceconDY emailServiceconDY)
        {
            _emailServiceconDY = emailServiceconDY;
        }

        [HttpGet]
        public bool EnviarMail([FromQuery] string email)
        {
            UsuarioServiceconDY usuarioServiceconDY = new UsuarioServiceconDY(_emailServiceconDY);
            return usuarioServiceconDY.EnviarNotificacionUsuarioconDY(email);

            // controller ---> new UsuarioServiceSinDY ---> new EmailServiceSinDY ---> enviar ... 
            // llamamos a cada clase que tiene una responsabilidad
        }
    }
}
