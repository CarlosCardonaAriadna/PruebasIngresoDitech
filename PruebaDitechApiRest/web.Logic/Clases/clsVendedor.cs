using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.Logic.Clases
{
    public class clsVendedor
    {
        public virtual int CODIGO { get; set; }
        public virtual string NOMBRE { get; set; }
        public virtual string APELLIDO { get; set; }
        public virtual string NUMERO_IDENTIFICACION { get; set; }
        public virtual int CODIGO_CIUDAD { get; set; }
    }
}
