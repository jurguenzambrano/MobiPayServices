using System.Configuration;

namespace DSD.Adapters
{
    public class SqlServer
    {
        public string CadenaConexion { get; set; }

        public SqlServer()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["conDSD"].ConnectionString;
        }
    }
}
