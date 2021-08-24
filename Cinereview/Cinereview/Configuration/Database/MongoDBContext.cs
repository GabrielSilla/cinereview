using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace Cinereview.Configuration.Database
{
    public class MongoDBContext : IDisposable
    {
        public IMongoDatabase MongoDBConexao { get; set; }
        private IMongoClient _client { get; set; }

        private readonly Configuration configuration;
        public MongoDBContext(Configuration configuration)
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(configuration.GetConnectionString()));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            _client = new MongoClient(settings);
            MongoDBConexao = _client.GetDatabase(configuration.GetDatabaseName());
        }

        public void Dispose()
        {
            MongoDBConexao = null;
            _client = null;
        }
    }
}
