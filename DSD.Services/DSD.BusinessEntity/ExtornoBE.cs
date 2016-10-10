using System;
using System.Runtime.Serialization;

namespace DSD.BusinessEntity
{
    [DataContract]
    public class ExtornoBE
    {
        [DataMember]
        public string CodigoCliente { get; set; }

        [DataMember]
        public string OperacionBancoExtorno { get; set; }

        [DataMember]
        public decimal Monto { get; set; }

        [DataMember]
        public string OperacionBanco { get; set; }
    }
}