using MongoDB.Driver;
using System.Configuration;

namespace WebServiceAutenticacion
{
    public static class ConexionMongo
    {
        private static IMongoDatabase _database;

        public static IMongoDatabase ObtenerConexion()
        {
            if (_database == null)
            {
                // Obtiene la cadena de conexión y la base de datos del archivo Web.config
                var connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
                var databaseName = ConfigurationManager.AppSettings["MongoDatabase"];

                var cliente = new MongoClient(connectionString);
                _database = cliente.GetDatabase(databaseName);
            }

            return _database;
        }
    }
}
