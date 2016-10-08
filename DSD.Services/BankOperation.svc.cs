using System;
using DSD.BusinessLogic;
using DSD.BusinessEntity;

namespace DSD.Services
{
    public class BankOperation : IBankOperation
    {
        public UsuariosBE getUser(Nullable<Guid> gBanco, string xCodigoUsuario)
        {
            UsuariosBE oUsuariosBE = new UsuariosBE();
            oUsuariosBE = new BankBL().getUser(gBanco, xCodigoUsuario);
            return oUsuariosBE;
        }
        public MovimientosBE refillwallet(Nullable<Guid> gBanco, string xCodigoUsuario, string xOperacionBanco, decimal mMonto)
        {
            MovimientosBE oMovimientosBE = new MovimientosBE();
            oMovimientosBE = new BankBL().refillwallet(gBanco, xCodigoUsuario, xOperacionBanco, mMonto);
            return oMovimientosBE;
        }
    }
}
