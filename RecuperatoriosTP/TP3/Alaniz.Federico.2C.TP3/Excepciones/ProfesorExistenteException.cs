using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ProfesorExistenteException:Exception
    {
        public ProfesorExistenteException():base("Este profesor ya se encuentra en la universidad.")
        {

        }
    }
}
