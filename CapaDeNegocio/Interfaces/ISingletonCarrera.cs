using CapaDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio
{
    public interface ISingletonCarrera : IGenericSingleton<Carrera>
    {
        bool NameExists(Carrera data);
        bool SiglaExists(Carrera data);
        string FindById(Carrera data);
        string Login(Carrera data);
        string List();
    }
}
