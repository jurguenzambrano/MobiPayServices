using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace DSD.BusinessEntity
{
    [DataContract]
    public class SaldoBE
    {
        [DataMember]
        public string CodigoCliente { get; set; }
    }
}