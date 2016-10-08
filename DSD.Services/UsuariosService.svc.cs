using DSD.BusinessEntity;
using DSD.DataAccess;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;

namespace DSD.Services
{
    public class UsuariosService : IUsuariosService
    {
        private UsuariosDA usuarioDao = new UsuariosDA();

        public UsuarioBE CrearUsuario(UsuarioBE usuarioACrear)
        {
            if (usuarioDao.Obtener(usuarioACrear.Dni) != null)
            {
                throw new WebFaultException<string>("Número de DNI ya registrado", HttpStatusCode.InternalServerError);
            }

            if (usuarioDao.ObtenerPorEmail(usuarioACrear.Mail) != null)
            {
                throw new WebFaultException<string>("Correo electrónico ya registrado", HttpStatusCode.InternalServerError);
            }

            /*
            NotificacionService ns = new NotificacionService();
            string mensajeConfirmacion = "Hola " + usuarioACrear.Nombres + " " + usuarioACrear.Apellidos;
            mensajeConfirmacion = mensajeConfirmacion + "<br/><br/>";
            mensajeConfirmacion = mensajeConfirmacion + "Confirma la creación de tu cuenta ingresando al <a href=\"www.google.com\" target=\"_blank\">siguiente enlace</a>.";
            mensajeConfirmacion = mensajeConfirmacion + "<br/><br/>MobiPay";
            ns.EnviarCorreo(usuarioACrear.Mail, "Confirma tu cuenta", mensajeConfirmacion);
            */
            return usuarioDao.Crear(usuarioACrear);
        }

        public UsuarioBE ObtenerUsuario(string dni)
        {
            UsuarioBE usuario = usuarioDao.Obtener(dni);
            if (usuario == null)
            {
                throw new WebFaultException<string>("Usuario no registrado", HttpStatusCode.InternalServerError);
            }
            else
            {
                return usuario;
            }
        }

        public UsuarioBE ModificarUsuario(UsuarioBE usuarioAModificar)
        {
            if (usuarioDao.Obtener(usuarioAModificar.Dni) == null)
            {
                throw new WebFaultException<string>("Usuario no existe", HttpStatusCode.InternalServerError);
            }
            else
            {
                return usuarioDao.Modificar(usuarioAModificar);
            }
        }

        public void EliminarUsuario(string dni)
        {
            if (usuarioDao.Obtener(dni) == null)
            {
                throw new WebFaultException<string>("Usuario no existe", HttpStatusCode.InternalServerError);
            }
            else
            {
                usuarioDao.Eliminar(dni);
            }
        }

        public List<UsuarioBE> ListarUsuario()
        {
            return usuarioDao.Listar();
        }
    }
}
