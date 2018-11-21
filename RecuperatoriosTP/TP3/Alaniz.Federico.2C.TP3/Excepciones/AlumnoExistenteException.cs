using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoExistenteException:Exception
    {
        public AlumnoExistenteException():base("Este alumno ya esta registrado en la universidad.")
        {

        }
    }
}
