using DSD.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DSD.WCF.Services
{
    [ServiceContract]
    public interface IMonederosService
    {
        [OperationContract]
        MovimientoBE Recargar(RecargaBE recarga);

        [OperationContract]
        MovimientoBE Extornar(ExtornoBE extorno);

        [OperationContract]
        MovimientoBE Pagar(PagoBE pago);

        [OperationContract]
        MovimientoBE Saldo(SaldoBE saldo);
    }
}
