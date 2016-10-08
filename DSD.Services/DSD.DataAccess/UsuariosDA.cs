using DSD.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DSD.DataAccess
{
    public class UsuariosDA
    {
        private string cadenaConexion = "Server=84f2f108-f1ef-481c-a84a-a67f016e94e3.sqlserver.sequelizer.com;Database=db84f2f108f1ef481ca84aa67f016e94e3;User ID=opjckhddqfloqdsl;Password=qJPpHN35stUAP4gNNhN6oZ8q5VFKSx3bj8Ue8ND4RzUfDQzSgU2DBUnyJysUhqk3;";

        public UsuarioBE Crear(UsuarioBE usuarioACrear)
        {
            UsuarioBE usuarioCreado = null;
            string sql = "INSERT INTO TB_USUARIO (dni,apellidos,nombres,direccion,celular,mail,estado,clave) VALUES (@Dni, @Apellidos, @Nombres, @Direccion, @Celular, @Mail, @Estado, @Clave)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Dni", usuarioACrear.Dni));
                    comando.Parameters.Add(new SqlParameter("@Apellidos", usuarioACrear.Apellidos));
                    comando.Parameters.Add(new SqlParameter("@Nombres", usuarioACrear.Nombres));
                    //comando.Parameters.Add(new SqlParameter("@FechaEmision", usuarioACrear.FechaEmision));
                    comando.Parameters.Add(new SqlParameter("@Direccion", usuarioACrear.Direccion));
                    comando.Parameters.Add(new SqlParameter("@Celular", usuarioACrear.Celular));
                    comando.Parameters.Add(new SqlParameter("@Mail", usuarioACrear.Mail));
                    comando.Parameters.Add(new SqlParameter("@Estado", "0"));
                    comando.Parameters.Add(new SqlParameter("@Clave", usuarioACrear.Clave));
                    comando.ExecuteNonQuery();
                }
            }
            usuarioCreado = Obtener(usuarioACrear.Dni);
            return usuarioCreado;
        }

        public UsuarioBE Obtener(string dni)
        {
            UsuarioBE usuarioEncontrado = null;
            string sql = "SELECT * FROM TB_USUARIO WHERE DNI = @Dni";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Dni", dni));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            usuarioEncontrado = new UsuarioBE()
                            {
                                Dni = (string)resultado["dni"],
                                Apellidos = (string)resultado["apellidos"],
                                Nombres = (string)resultado["Nombres"],
                                //FechaEmision = (DateTime) resultado["FechaEmision"],
                                Direccion = (string)resultado["Direccion"],
                                Celular = (string)resultado["Celular"],
                                Mail = (string)resultado["Mail"],
                                Estado = (string)resultado["Estado"],
                                Clave = (string)resultado["Clave"]
                            };

                        }
                    }
                }
            }

            return usuarioEncontrado;
        }

        public UsuarioBE ObtenerPorEmail(string email)
        {
            UsuarioBE usuarioEncontrado = null;
            string sql = "SELECT * FROM TB_USUARIO WHERE MAIL = @Mail";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Mail", email));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            usuarioEncontrado = new UsuarioBE()
                            {
                                Dni = (string)resultado["dni"],
                                Apellidos = (string)resultado["apellidos"],
                                Nombres = (string)resultado["Nombres"],
                                //FechaEmision = (DateTime) resultado["FechaEmision"],
                                Direccion = (string)resultado["Direccion"],
                                Celular = (string)resultado["Celular"],
                                Mail = (string)resultado["Mail"],
                                Estado = (string)resultado["Estado"],
                                Clave = (string)resultado["Clave"]
                            };

                        }
                    }
                }
            }

            return usuarioEncontrado;
        }

        public UsuarioBE Modificar(UsuarioBE usuarioAModificar)
        {
            UsuarioBE usuarioModificado = null;
            string sql = "UPDATE TB_USUARIO set Apellidos = @Apellidos, Nombres = @Nombres, Direccion = @Direccion, Celular = @Celular, Mail = @Mail, Clave = @Clave, Estado = @Estado WHERE dni = @Dni";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Dni", usuarioAModificar.Dni));
                    comando.Parameters.Add(new SqlParameter("@Apellidos", usuarioAModificar.Apellidos));
                    comando.Parameters.Add(new SqlParameter("@Nombres", usuarioAModificar.Nombres));
                    //comando.Parameters.Add(new SqlParameter("@FechaEmision", usuarioAModificar.FechaEmision));
                    comando.Parameters.Add(new SqlParameter("@Direccion", usuarioAModificar.Direccion));
                    comando.Parameters.Add(new SqlParameter("@Celular", usuarioAModificar.Celular));
                    comando.Parameters.Add(new SqlParameter("@Mail", usuarioAModificar.Mail));
                    comando.Parameters.Add(new SqlParameter("@Estado", usuarioAModificar.Estado));
                    comando.Parameters.Add(new SqlParameter("@Clave", usuarioAModificar.Clave));
                    comando.ExecuteNonQuery();
                }
            }
            usuarioModificado = Obtener(usuarioAModificar.Dni);
            return usuarioModificado;
        }
        public void Eliminar(string dni)
        {
            string sql = "DELETE TB_USUARIO WHERE DNI = @Dni";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Dni", dni));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<UsuarioBE> Listar()
        {
            List<UsuarioBE> usuariosEncontrados = new List<UsuarioBE>();
            UsuarioBE usuarioEncontrado = null;
            string sql = "SELECT * FROM TB_USUARIO";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            usuarioEncontrado = new UsuarioBE()
                            {
                                Dni = (string)resultado["dni"],
                                Apellidos = (string)resultado["dni"],
                                Nombres = (string)resultado["Nombres"],
                                //FechaEmision = (DateTime)resultado["FechaEmision"],
                                Direccion = (string)resultado["Direccion"],
                                Celular = (string)resultado["Celular"],
                                Mail = (string)resultado["Mail"]
                            };
                            usuariosEncontrados.Add(usuarioEncontrado);
                        }
                    }
                }
            }
            return usuariosEncontrados;
        }

        public List<UsuarioBE> ListarPorDni(String dni)
        {
            List<UsuarioBE> usuariosEncontrados = new List<UsuarioBE>();
            UsuarioBE usuarioEncontrado = null;
            string sql = "SELECT * FROM TB_USUARIO WHERE DNI = @dni";
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
                            usuarioEncontrado = new UsuarioBE()
                            {
                                Dni = (string)resultado["dni"],
                                Apellidos = (string)resultado["dni"],
                                Nombres = (string)resultado["Nombres"],
                                //FechaEmision = (DateTime)resultado["FechaEmision"],
                                Direccion = (string)resultado["Direccion"],
                                Celular = (string)resultado["Celular"],
                                Mail = (string)resultado["Mail"],
                                Estado = (string)resultado["Estado"],
                                Clave = (string)resultado["Clave"]
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
