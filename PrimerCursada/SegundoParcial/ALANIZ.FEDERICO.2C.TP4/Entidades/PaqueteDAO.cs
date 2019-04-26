using System;
using System.Collections.Generic;
using System.Data;
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
            conexion = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True");
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Recibe un paquete y lo inserta en la base 
        /// </summary>
        /// <param name="p">un paquete</param>
        /// <returns>treu si logró el insert</returns>
        public static bool Insertar(Paquete p)
        {
            try
            {
                conexion.Open(); // Se inicia la conexión
                comando = new SqlCommand("INSERT INTO dbo.Paquetes(direccionEntrega, trackingID, alumno) VALUES('" + p.DireccionEntrega + "','" + p.TrackingID + "','" + "Alaniz Federico" + "')", conexion);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Error al insertar paquete en la base.");
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
        #endregion
    }
}
