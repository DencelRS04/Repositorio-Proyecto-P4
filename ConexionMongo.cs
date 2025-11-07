using MongoDB.Driver;
using System.Configuration;

namespace WebServiceAutenticacion
{
    public static class ConexionMongo
    {
        private static readonly string cadenaConexion =
            ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;

        private static readonly string nombreBaseDatos =
            ConfigurationManager.AppSettings["MongoDatabase"];

        public static IMongoDatabase ObtenerConexion()
        {
            var cliente = new MongoClient(cadenaConexion);
            return cliente.GetDatabase(nombreBaseDatos);
        }
    }
}
