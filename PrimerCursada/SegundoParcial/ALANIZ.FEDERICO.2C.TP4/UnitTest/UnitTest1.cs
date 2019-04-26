using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        ///  Verifica que no se puedan cargar dos Paquetes con el mismo Tracking ID.
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            Correo c = new Correo();
            Paquete a = new Paquete("Prueba 1", "asd");
            Paquete b = new Paquete("Prueba 2", "asd");

            try
            {
                c += a;
                c += b;
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(TrackingIdRepetidaException));
            }
        }
        /// <summary>
		/// Test que verifica que se inicialice la lista de paquetes
		/// </summary>
		[TestMethod]
        public void TestMethod1()
        {
            Correo c = new Correo();
            if (c.Paquetes != null)
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);
        }

    }
}
