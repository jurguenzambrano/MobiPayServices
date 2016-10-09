using DSD.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DSD.Services
{
    [ServiceContract]
    public interface IUsuariosService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "usuarios", ResponseFormat = WebMessageFormat.Json)]
        UsuarioBE CrearUsuario(UsuarioBE usuarioACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "usuarios/{dni}", ResponseFormat = WebMessageFormat.Json)]
        UsuarioBE ObtenerUsuario(string dni);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "usuarios", ResponseFormat = WebMessageFormat.Json)]
        UsuarioBE ModificarUsuario(UsuarioBE usuarioAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "usuarios/{dni}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarUsuario(string dni);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "usuarios/{dni}/movimientos", ResponseFormat = WebMessageFormat.Json)]
        List<MovimientoBE> ListarMovimientos(string dni);

        [OperationContract]
        List<UsuarioBE> Listar();
    }
}
