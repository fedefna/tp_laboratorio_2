using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class UsuarioDAO
    {
        #region campos
        static public string cadenaConexion= "Data Source =.\\SQLEXPRESS; Initial Catalog = correo-sp-2017; Integrated Security = True";
        static SqlCommand comando;
        static SqlConnection conexion;
        #endregion

        #region metodos
        /// <summary>
        /// Constructor por defecto, inicializa SqlCommand y SqlConnection
        /// </summary>
        private UsuarioDAO()
        {
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        /// <summary>
        /// Recibe un usuairo y lo guarda en la tabla dbo.Usuarios
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public bool Guardar(Usuario u)
        {
            try
            {
                comando.CommandText = "INSERT INTO dbo.Usuarios (nombre, clave) VALUES ('" + u.Nombre + "', '" + u.Clave + "')";
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        /// <summary>
        /// Busca un registro de un usuario en la tabla y lo devuelve como un objeto usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        public Usuario Leer(string usuario, string clave)
        {
            try
            {
                comando.CommandText = "SELECT nombre,clave FROM dbo.Usuarios where nombre='" + usuario + "' AND clave='" + clave + "'";
                conexion.Open();

                Usuario aux=null;
                SqlDataReader oDr = comando.ExecuteReader();
                if (oDr.Read())
                {
                    aux = new Usuario(usuario, clave);
                }
                conexion.Close();
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        #endregion
    }
}
