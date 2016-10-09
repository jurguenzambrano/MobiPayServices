using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace DSD.BusinessEntity
{
    [DataContract]
    public class PagoBE
    {
        [DataMember]
        public string CodigoCliente { get; set; }

        [DataMember]
        public string OperacionBanco { get; set; }

        [DataMember]
        public decimal Monto { get; set; }
    }
}