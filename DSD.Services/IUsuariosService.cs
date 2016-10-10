﻿using DSD.BusinessEntity;
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
        [WebInvoke(Method = "GET", UriTemplate = "usuarios/{codigoCliente}", ResponseFormat = WebMessageFormat.Json)]
        UsuarioBE ObtenerUsuario(string codigoCliente);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "usuarios", ResponseFormat = WebMessageFormat.Json)]
        UsuarioBE ModificarUsuario(UsuarioBE usuarioAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "usuarios/{dni}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarUsuario(string dni);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "usuarios/{codigoCliente}/movimientos", ResponseFormat = WebMessageFormat.Json)]
        List<MovimientoBE> ListarMovimientos(string codigoCliente);

        [OperationContract]
        List<UsuarioBE> Listar();
    }
}
