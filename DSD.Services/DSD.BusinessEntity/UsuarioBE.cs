using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Web;

namespace DSD.BusinessEntity
{
    [DataContract]
    public class UsuarioBE
    {
        [DataMember]
        public string Dni { get; set; }

        [DataMember]
        public string Apellidos { get; set; }

        [DataMember]
        public string Nombres { get; set; }

        [DataMember]
        public string Direccion { get; set; }

        [DataMember]
        public string Celular { get; set; }

        [DataMember]
        public string Mail { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public string Clave { get; set; }
    }
}
