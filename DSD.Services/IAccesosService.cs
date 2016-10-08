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
    public interface IAccesosService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "accesos", ResponseFormat = WebMessageFormat.Json)]
        UsuarioBE LoginUsuario(UsuarioBE usuario);

    }
}
