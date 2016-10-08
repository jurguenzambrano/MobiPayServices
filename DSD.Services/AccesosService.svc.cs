using DSD.BusinessEntity;
using DSD.DataAccess;
using System.Net;
using System.ServiceModel.Web;

namespace DSD.Services
{
    public class AccesosService : IAccesosService
    {
        private UsuariosDA usuarioDao = new UsuariosDA();
        private UsuarioBE usuario = new UsuarioBE();

        public UsuarioBE LoginUsuario(UsuarioBE usuarioLogin)
        {
            usuario = usuarioDao.ObtenerPorEmail(usuarioLogin.Mail);

            if (usuario == null)
            {
                throw new WebFaultException<string>("Correo Electrónico no registrado", HttpStatusCode.InternalServerError);
            }
            else if (usuario.Estado.Equals("0"))
            {
                throw new WebFaultException<string>("Usuario no confirmado", HttpStatusCode.InternalServerError);
            }
            else if (!usuario.Clave.Equals(usuarioLogin.Clave))
            {
                throw new WebFaultException<string>("Clave incorrecta", HttpStatusCode.InternalServerError);
            }
            else
            {
                return usuario;
            }
        }
    }
}
