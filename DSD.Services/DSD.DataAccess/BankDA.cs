using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSD.BusinessEntity;
using System.Data;
using System.Data.SqlClient;

namespace DSD.DataAccess
{
    public class BankDA
    {
        public UsuariosBE getUser(SqlConnection con, Nullable<Guid> gBanco, string xCodigoUsuario)
        {
            bool lError = true;
            string xRespuesta = string.Empty;
            string xMensaje = string.Empty;

            UsuariosBE oUsuarios = new UsuariosBE();
            SqlCommand cmd = new SqlCommand("spl_getUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter pr1 = cmd.Parameters.Add("@gBanco", SqlDbType.UniqueIdentifier);
            pr1.Value = gBanco;
            SqlParameter pr2 = cmd.Parameters.Add("@xCodigoUsuario", SqlDbType.VarChar, 12);
            pr2.Value = xCodigoUsuario;            
            SqlParameter pr3 = cmd.Parameters.Add("@lError", SqlDbType.Bit);
            pr3.Value = lError;
            pr3.Direction = ParameterDirection.Output;
            SqlParameter pr4 = cmd.Parameters.Add("@xRespuesta", SqlDbType.VarChar, 100);
            pr4.Value = xRespuesta;
            pr4.Direction = ParameterDirection.Output;

            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {                                
                while (drd.Read())
                {
                    if (drd.HasRows && !drd.IsDBNull(drd.GetOrdinal("xDocumento")))
                    {
                        oUsuarios.xDocumento = drd.GetString(drd.GetOrdinal("xDocumento"));
                        oUsuarios.xNombres = drd.GetString(drd.GetOrdinal("xUsuarioNombre"));
                    }
                }
                drd.NextResult();
                oUsuarios.lError = (bool)pr3.Value;
                oUsuarios.xRespuesta = pr4.Value.ToString();
                drd.Close();
            }

            return oUsuarios;
        }

        public MovimientosBE refillwallet(SqlConnection con, Nullable<Guid> gBanco, string xCodigoUsuario, string xOperacionBanco, decimal mMonto)
        {
            MovimientosBE oMovimientosBE = new MovimientosBE();
            bool lError = true;
            string xRespuesta = string.Empty;
            string xMensaje = string.Empty;

            UsuariosBE oUsuarios = new UsuariosBE();
            SqlCommand cmd = new SqlCommand("spl_refillwallet", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter pr1 = cmd.Parameters.Add("@gBanco", SqlDbType.UniqueIdentifier);
            pr1.Value = gBanco;
            SqlParameter pr2 = cmd.Parameters.Add("@xCodigoUsuario", SqlDbType.VarChar, 12);
            pr2.Value = xCodigoUsuario;
            SqlParameter pr3 = cmd.Parameters.Add("@xOperacionBanco", SqlDbType.VarChar, 50);
            pr3.Value = xOperacionBanco;
            SqlParameter pr4 = cmd.Parameters.Add("@mMonto", SqlDbType.Decimal);
            pr4.Value = mMonto;
            SqlParameter pr5 = cmd.Parameters.Add("@lError", SqlDbType.Bit);
            pr5.Value = lError;
            pr5.Direction = ParameterDirection.Output;
            SqlParameter pr6 = cmd.Parameters.Add("@xRespuesta", SqlDbType.VarChar, 100);
            pr6.Value = xRespuesta;
            pr6.Direction = ParameterDirection.Output;

            SqlDataReader drd = cmd.ExecuteReader();
            if (drd != null)
            {                
                //drd.NextResult();
                oMovimientosBE.lError = (bool)pr5.Value;
                oMovimientosBE.xRespuesta = pr6.Value.ToString();
                drd.Close();
            }            
            return oMovimientosBE;
        }
        public MovimientosBE defundwallet(SqlConnection cn, UsuariosBE oUsuariosBE)
        {
            MovimientosBE oMovimientosBE = new MovimientosBE();

            return oMovimientosBE;
        }
    }
}
