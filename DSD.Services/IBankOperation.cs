using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DSD.Adapters;
using DSD.BusinessEntity;

namespace DSD.Services
{    
    [ServiceContract]
    public interface IBankOperation
    {
        [OperationContract]
        UsuariosBE getUser(Nullable<Guid> gBanco, string xCodigoUsuario);

        [OperationContract]
        MovimientosBE refillwallet(Nullable<Guid> gBanco, string xCodigoUsuario, string xOperacionBanco, decimal mMonto);
    }
}
