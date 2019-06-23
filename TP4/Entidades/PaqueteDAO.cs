using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Campos
        static SqlCommand comando;
        static SqlConnection conexion;
        
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = correo-sp-2017; Integrated Security = True");
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Recibe un paquete y lo inserta en la base 
        /// </summary>
        /// <param name="p">un paquete</param>
        /// <returns>treu si logró el insert</returns>
        static bool Insertar(Paquete p)
        {
            try
            {
                comando.CommandText = "INSERT INTO correo-sp-2017 (direccionEntrega, trackingID, alumno) VALUES('" + p.DireccionEntrega + "', '" + p.TrackingID + "', 'Federico.Alaniz')";
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Error al insertar paquete en la base.");
            }
            finally
            {
                conexion.Close();
            }
        }
        #endregion
    }
}
