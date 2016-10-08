using DSD.Adapters;
using DSD.BusinessEntity;
using DSD.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSD.BusinessLogic
{
    public class BankBL : SqlServer
    {
        public UsuariosBE getUser(Nullable<Guid> gBanco, string xCodigoUsuario)
        {
            UsuariosBE oUsuarios = new UsuariosBE();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    BankDA oBankDA = new BankDA();
                    oUsuarios = oBankDA.getUser(con, gBanco, xCodigoUsuario);
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException(ex.ToString());
                }
            }
            return oUsuarios;
        }

        public MovimientosBE refillwallet(Nullable<Guid> gBanco, string xCodigoUsuario, string xOperacionBanco, decimal mMonto)
        {
            MovimientosBE oMovimientosBE = new MovimientosBE();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    BankDA oBankDA = new BankDA();
                    oMovimientosBE = oBankDA.refillwallet(con, gBanco,xCodigoUsuario,xOperacionBanco,mMonto);
                }
                catch (Exception ex)
                {
                    //Log.grabarLog(ex);
                    throw new NotImplementedException(ex.ToString());
                }
            }
            return oMovimientosBE;
        }
        public MovimientosBE defundwallet(UsuariosBE oUsuariosBE)
        {
            MovimientosBE oMovimientosBE = new MovimientosBE();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    BankDA oBankDA = new BankDA();
                    oMovimientosBE = oBankDA.defundwallet(con, oUsuariosBE);
                }
                catch (Exception ex)
                {
                    //Log.grabarLog(ex);
                    throw new NotImplementedException(ex.ToString());
                }
            }
            return oMovimientosBE;
        }
    }
}
