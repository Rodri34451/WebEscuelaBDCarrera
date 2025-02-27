using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public interface IBasicconnection
    {
        SqlConnection MyConnection { get; set; }
        SqlCommand MyCommand { get; set; }
        string Referente { get; set; }
        string ConnectionString { get; set; }
        void OpenConnection();
    }
}
