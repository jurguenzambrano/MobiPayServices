using System;
using System.Runtime.Serialization;

namespace DSD.BusinessEntity
{

    [DataContract]
    public class MensajesBE
    {

        [DataMember]
        public string xRespuesta { get; set; }

        [DataMember]
        public bool lError { get; set; }

        [DataMember]
        public string xMensaje { get; set; }
    }
}
