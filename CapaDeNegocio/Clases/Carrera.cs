using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio
{
    public class Carrera : IABMC, ICarrera
    {
        internal Singleton S { get => Singleton.GetInstance; }

        #region IID
        public int ID { get; set; }
        #endregion
        #region ICarrera

        public string nombre { get; set; }
        public string sigla { get; set; }
        public string titulo { get; set; }
        public int duracion { get; set; }

        public bool NameExists()
        {
            return S.ISC.NameExists(this); 
        }
        public bool SiglaExists()
        {
            return S.ISC.SiglaExists(this);
        }
        public string FindByID()
        {
            return S.ISC.FindById(this);
        }

        public string List()
        {
            return S.ISC.List();
        }
        #endregion
        #region IABMC
        public void Add()
        {
            S.ISC.Add(this);
        }
        public void Erase()
        {
            S.ISC.Erase(this);
        }

        public string Find()
        {
            return S.ISC.Find(this);
        }

        public void Modify()
        {
            S.ISC.Modify(this);
        }
        #endregion
    }
}
