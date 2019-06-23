using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using Clases_Abstractas;
using Clases_Instanciables;
using Excepciones;

namespace Test_Unitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test para validar que se carguen bien los DNI
        /// </summary>
        [TestMethod]
        public void TestNumerico()
        {
            Alumno alu1 = new Alumno(1, "Pepe", "Argento", "37.007.258", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Alumno alu2 = new Alumno(1, "Pepe", "Argento", "98.007.258", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);

            Assert.IsTrue(37007258==alu1.Dni);
            Assert.IsTrue(98007258==alu2.Dni);
        }

        /// <summary>
        /// Test para que los alumnos, instructores y las jornadas de una universidad no sean null
        /// </summary>
        [TestMethod]
        public void AlumnosDeJornadaNoNull()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Alumnos);
            Assert.IsNotNull(uni.Instructores);
            Assert.IsNotNull(uni.Jornadas);
        }

        /// <summary>
        /// Test de DniInvalidoException
        /// </summary>
        [TestMethod]
        public void TestDniInvalidoException()
        {
            try
            {
                string dato1 = "-1";
                Alumno alu1 = new Alumno(1, "Pepe", "Argento", dato1, Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(DniInvalidoException));
            }
        }


        /// <summary>
        /// Test de AlumnoExistenteException
        /// </summary>
        [TestMethod]
        public void TestAlumnoExistenteException()
        {
            Universidad uni = new Universidad();

            Alumno alu1 = new Alumno(1, "Pepe", "Argento", "37556985", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Alumno alu2 = new Alumno(2, "Roberto", "Rodriguez", "90845556", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            
            try
            {
                uni += alu1;
                uni += alu2;
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(AlumnoExistenteException));
            }

            try
            {
                uni += alu1;
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoExistenteException));
            }
        }
    }
}
