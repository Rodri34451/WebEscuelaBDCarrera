using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio
{
    internal partial class Singleton : ISingletonCarrera
    {
        public ISingletonCarrera ISC { get => this; }

        #region IGenericSingletonCarrera
        void IGenericSingleton<Carrera>.Add(Carrera Data)
        {
            if (Data.NameExists()) throw new Exception("");
            if (Data.SiglaExists()) throw new Exception("");

            IConnection.CreateCommand("Carreras_Insert", "Carreras");
            IConnection.ParameterAddVarChar("Nombre", Data.nombre);
            IConnection.ParameterAddVarChar("Sigla", Data.sigla);
            IConnection.ParameterAddVarChar("Titulo", Data.titulo);
            IConnection.ParameterAddInt("Duracion", Data.duracion);
            Data.ID = IConnection.Insert();
        }

        void IGenericSingleton<Carrera>.Erase(Carrera Data)
        {
            IConnection.CreateCommand("Carreras_Delete", "Carreras");
            IConnection.ParameterAddInt("ID", Data.ID);
            IConnection.Delete();
        }

        string IGenericSingleton<Carrera>.Find(Carrera Data)
        {
            IConnection.CreateCommand("Carreras_Find", "Carreras");
            IConnection.ParameterAddInt("ID", Data.ID);
            DataRow Dr = IConnection.Find();
            return IJsonConverter.RowToJson(Dr);
        }

        void IGenericSingleton<Carrera>.Modify(Carrera Data)
        {
            if (Data.NameExists()) throw new Exception("");
            if (Data.SiglaExists()) throw new Exception("");

            IConnection.CreateCommand("Carreras_Update", "Carreras");
            IConnection.ParameterAddInt("ID", Data.ID);
            IConnection.ParameterAddVarChar("Nombre", Data.nombre);
            IConnection.ParameterAddVarChar("Sigla", Data.sigla);
            IConnection.ParameterAddVarChar("Titulo", Data.titulo);
            IConnection.ParameterAddInt("Duracion", Data.duracion);
            IConnection.Update();
        }
        #endregion

        #region SingletonCarrera

        public string FindById(Carrera Data)
        {
            IConnection.CreateCommand("Carreras_FindById", "Carrera");
            IConnection.ParameterAddInt("ID", Data.ID);
            DataRow Dr = IConnection.Find();
            return IJsonConverter.RowToJson(Dr);
        }

        string ISingletonCarrera.List()
        {
            try
            {
                IConnection.CreateCommand("Carreras_List", "Carreras");
                DataTable Dt = IConnection.List();
                return IJsonConverter.TableToJson(Dt);
            }
            catch (Exception)
            {
                throw new Exception("ERROR: No se pudo listar las carreras");
            }
        }

        string ISingletonCarrera.Login(Carrera Data)
        {
            throw new NotImplementedException();
        }

        bool ISingletonCarrera.NameExists(Carrera Data)
        {
            IConnection.CreateCommand("Carreras_NameExists", "Carreras");
            IConnection.ParameterAddInt("ID", Data.ID);
            IConnection.ParameterAddVarChar("Nombre", Data.nombre);
            return IConnection.Exists();
        }
        bool ISingletonCarrera.SiglaExists(Carrera Data)
        {
            IConnection.CreateCommand("Carreras_SiglaExists", "Carreras");
            IConnection.ParameterAddInt("ID", Data.ID);
            IConnection.ParameterAddVarChar("Sigla", Data.sigla);
            return IConnection.Exists();
        }
        #endregion
    }
}
