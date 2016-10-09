using System;
using System.Runtime.Serialization;

namespace DSD.BusinessEntity
{
    [DataContract]
    public class RecargaBE
    {
        [DataMember]
        public string CodigoCliente { get; set; }

        [DataMember]
        public decimal Monto { get; set; }

        [DataMember]
        public string OperacionBanco { get; set; }

        [DataMember]
        public int Operacion { get; set; }
    }
}