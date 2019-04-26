using System;
using Archivos;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Agencia agencia1 = new Agencia("Agencia");
            Agencia agencia2;
            Xml<Agencia> xml = new Xml<Agencia>();

            //Pasajero pasajero = new Pasajero("FEDE", "ALANIZ", "34556987");
            //DateTime fecha = DateTime.Today;
            //Pasaje pasaje = new PasajeMicro ("ORIGEN", "DESTINO", pasajero, 120, fecha,Servicio.Comun);
            //agencia1 += pasaje;

            xml.Guardar("Agencia.xml", agencia1);
            agencia2 = xml.Leer("Agencia.xml");

            if ((agencia1.Nombre == agencia2.Nombre) && (agencia1.PasajesVendidos == agencia2.PasajesVendidos))
            {
                Assert.IsTrue(true);
            }
        }
    }
}
