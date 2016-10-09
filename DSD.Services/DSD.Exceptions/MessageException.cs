using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace DSD.Exceptions
{
        [DataContract]
        public class MessageException
        {
            [DataMember]
            public string Codigo { get; set; }

            [DataMember]
            public string Error { get; set; }

            [DataMember]
            public string Descripcion { get; set; }
        }
}