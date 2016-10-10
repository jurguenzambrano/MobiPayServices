using DSD.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DSD.DataAccess
{
    public class MovimientosDA
    {
        private string cadenaConexion = "Server=84f2f108-f1ef-481c-a84a-a67f016e94e3.sqlserver.sequelizer.com;Database=db84f2f108f1ef481ca84aa67f016e94e3;User ID=opjckhddqfloqdsl;Password=qJPpHN35stUAP4gNNhN6oZ8q5VFKSx3bj8Ue8ND4RzUfDQzSgU2DBUnyJysUhqk3;";

        public MovimientoBE Crear(MovimientoBE movimientoACrear)
        {
            MovimientoBE movimientoCreado = null;
            string sql = "INSERT INTO TB_MOVIMIENTO (codigocliente, tipo, monto, operacionbanco) VALUES (@CodigoCliente, @Tipo, @Monto, @OperacionBanco)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@CodigoCliente", movimientoACrear.CodigoCliente));
                    comando.Parameters.Add(new SqlParameter("@Tipo", movimientoACrear.Tipo));
                    comando.Parameters.Add(new SqlParameter("@Monto", movimientoACrear.Monto));
                    comando.Parameters.Add(new SqlParameter("@OperacionBanco", movimientoACrear.OperacionBanco));
                    comando.ExecuteNonQuery();
                }
            }
            movimientoCreado = Obtener(movimientoACrear.OperacionBanco);
            return movimientoCreado;
        }

        public MovimientoBE Obtener(string operacionBanco)
        {
            MovimientoBE movimientoEncontrado = null;
            string sql = "SELECT * FROM VW_MOVIMIENTO WHERE OPERACIONBANCO = @OperacionBanco";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@OperacionBanco", operacionBanco));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            movimientoEncontrado = new MovimientoBE()
                            {
                                CodigoCliente = (string)resultado["CodigoCliente"],
                                Tipo = (string)resultado["Tipo"],
                                Fecha = (string)resultado["Fecha"],
                                Monto = (decimal)resultado["Monto"],
                                OperacionBanco = (string)resultado["OperacionBanco"],
                                Operacion = (int)resultado["Operacion"]
                            };

                        }
                    }
                }
            }
            return movimientoEncontrado;
        }

        public MovimientoBE ObtenerPorClienteOperacion(string codigoCliente, string operacionBanco)
        {
            MovimientoBE movimientoEncontrado = null;
            string sql = "SELECT * FROM VW_MOVIMIENTO WHERE CODIGOCLIENTE =@CodigoCliente AND OPERACIONBANCO = @OperacionBanco";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@CodigoCliente", codigoCliente));
                    comando.Parameters.Add(new SqlParameter("@OperacionBanco", operacionBanco));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            movimientoEncontrado = new MovimientoBE()
                            {
                                CodigoCliente = (string)resultado["CodigoCliente"],
                                Tipo = (string)resultado["Tipo"],
                                Fecha = (string)resultado["Fecha"],
                                Monto = (decimal)resultado["Monto"],
                                OperacionBanco = (string)resultado["OperacionBanco"],
                                Operacion = (int)resultado["Operacion"]
                            };

                        }
                    }
                }
            }
            return movimientoEncontrado;
        }

        public List<MovimientoBE> ListarPorDni(String dni)
        {
            List<MovimientoBE> usuariosEncontrados = new List<MovimientoBE>();
            MovimientoBE usuarioEncontrado = null;
            string sql = "SELECT * FROM VW_MOVIMIENTO WHERE DNI = @dni ORDER BY FECHA DESC, OPERACION DESC";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", dni));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            usuarioEncontrado = new MovimientoBE()
                            {
                                Tipo = (string)resultado["Tipo"],
                                CodigoCliente = (string)resultado["CodigoCliente"],
                                Fecha = (string)resultado["Fecha"],
                                Monto = (decimal)resultado["Monto"],
                                Operacion = (int)resultado["Operacion"],
                                OperacionBanco = (string)resultado["OperacionBanco"]
                            };
                            usuariosEncontrados.Add(usuarioEncontrado);
                        }
                    }
                }
            }
            return usuariosEncontrados;
        }

        public List<MovimientoBE> ListarPorCodigoCliente(String codigoCliente)
        {
            List<MovimientoBE> usuariosEncontrados = new List<MovimientoBE>();
            MovimientoBE usuarioEncontrado = null;
            string sql = "SELECT * FROM VW_MOVIMIENTO WHERE CODIGOCLIENTE = @codigoCliente ORDER BY FECHA DESC, OPERACION DESC";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigoCliente", codigoCliente));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            usuarioEncontrado = new MovimientoBE()
                            {
                                Tipo = (string)resultado["Tipo"],
                                CodigoCliente = (string)resultado["CodigoCliente"],
                                Fecha = (string)resultado["Fecha"],
                                Monto = (decimal)resultado["Monto"],
                                Operacion = (int)resultado["Operacion"],
                                OperacionBanco = (string)resultado["OperacionBanco"]
                            };
                            usuariosEncontrados.Add(usuarioEncontrado);
                        }
                    }
                }
            }
            return usuariosEncontrados;
        }
    }
}