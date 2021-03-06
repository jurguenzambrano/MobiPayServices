﻿using System;
using System.Runtime.Serialization;

namespace DSD.BusinessEntity
{
    [DataContract]
    public class MovimientosBE:MensajesBE
    {
        [DataMember]
        public string CodigoCliente { get; set; }

        [DataMember]
        public string Tipo { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public decimal Monto { get; set; }

        [DataMember]
        public string OperacionBanco { get; set; }

        [DataMember]
        public int Operacion { get; set; }
    }
}
