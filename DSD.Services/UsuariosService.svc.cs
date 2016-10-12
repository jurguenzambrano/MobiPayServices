using DSD.BusinessEntity;
using DSD.DataAccess;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;
using System;
using RabbitMQ.Client;
using RabbitMQ.Client.MessagePatterns;
using System.Text;
using System.Web.Script.Serialization;
using RabbitMQ.Client.Events;

namespace DSD.Services
{
    public class UsuariosService : IUsuariosService
    {
        private UsuariosDA usuarioDao = new UsuariosDA();
        private MovimientosDA movimientoDao = new MovimientosDA();

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

        public UsuarioBE ObtenerUsuario(string codigoCliente)
        {
            UsuarioBE usuario = usuarioDao.ObtenerUsuarioPorCodigoCliente(codigoCliente);
            if (usuario == null)
            {
                throw new WebFaultException<string>("Usuario no registrado", HttpStatusCode.InternalServerError);
            }
            else
            {
                return usuario;
            }
        }

        public UsuarioBE ObtenerUsuarioPorCodigoCliente(string codigoCliente) {

            UsuarioBE usuario = usuarioDao.ObtenerUsuarioPorCodigoCliente(codigoCliente);
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
            UsuarioBE usuario = usuarioDao.Obtener(usuarioAModificar.Dni);
            if (usuario == null)
            {
                throw new WebFaultException<string>("Usuario no registrado", HttpStatusCode.InternalServerError);
            }
            if(usuario.Clave != usuarioAModificar.Clave)
            {
                throw new WebFaultException<string>("La clave no coincide", HttpStatusCode.InternalServerError);
            }
            usuarioAModificar.Estado = usuario.Estado;
            usuarioAModificar.MontoMaximo = usuario.MontoMaximo;
            return usuarioDao.Modificar(usuarioAModificar);
        }

        public void EliminarUsuario(string dni)
        {
            if (usuarioDao.Obtener(dni) == null)
            {
                throw new WebFaultException<string>("Usuario no registrado", HttpStatusCode.InternalServerError);
            }
            else
            {
                usuarioDao.Eliminar(dni);
            }
        }

        public List<UsuarioBE> Listar()
        {
            return usuarioDao.Listar();
        }

        public List<MovimientoBE> ListarMovimientos(string codigoCliente)
        {
            UsuarioBE usuario = usuarioDao.ObtenerUsuarioPorCodigoCliente(codigoCliente);
            if (usuario == null)
            {
                throw new WebFaultException<string>("Usuario no registrado", HttpStatusCode.InternalServerError);
            }

            // Rabbit
            ConnectionFactory connFactory = new ConnectionFactory
            {
                Uri = "amqp://qvirgsox:vqt2pyCczubvjAU_QtYB5aEQYUOGOj8D@wildboar.rmq.cloudamqp.com/qvirgsox"
            };
            
            using (var conn = connFactory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                channel.QueueDeclare("RECARGAS"+ codigoCliente, false, false, false, null);

                var subscription = new Subscription(channel, "RECARGAS"+ codigoCliente);
                
                while (true)
                {
                    BasicDeliverEventArgs eventArgs;
                    var gotMessage = subscription.Next(250, out eventArgs);

                    if (gotMessage)
                    {
                        var text = Encoding.UTF8.GetString(eventArgs.Body);
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        MovimientoBE movimientoCola = js.Deserialize<MovimientoBE>(text);

                        movimientoDao.Crear(movimientoCola);
                        if (eventArgs == null)
                        {
                            continue;
                        }
                        subscription.Ack();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            
            return movimientoDao.ListarPorCodigoCliente(codigoCliente);
        }
    }
}
