using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio
{
    internal interface ICarrera : IABMC
    {
        string nombre { get; set; }
        string sigla { get; set; }
        string titulo { get; set; }
        int duracion { get; set; }

        bool NameExists();
        bool SiglaExists();
        string FindByID();

    }
}
