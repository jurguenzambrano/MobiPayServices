using System;

namespace DSD.BusinessEntity
{
    public class UsuariosBE:MensajesBE
    {
        public Nullable<Guid> gUsuario { get; set; }
        public string xUsuario { get; set; }
        public string xNombres { get; set; }
        public string xApellidos { get; set; }
        public string xDocumento { get; set; }
        public int iRol { get; set; }
    }
}
