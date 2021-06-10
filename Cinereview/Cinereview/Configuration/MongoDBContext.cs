using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace Cinereview.Configuration
{
    public class MongoDBContext : IDisposable
    {
        public IMongoDatabase MongoDBConexao { get; set; }
        private IMongoClient _client { get; set; }

        private readonly Settings _settings;
        public MongoDBContext(IOptions<Settings> options)
        {
            //Propriedades da classe Settings
            _settings = options.Value;

            //Conectar na url ao appSettings: **mongodb://127.0.0.1:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false**
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(_settings.ConnectionString));

            //Camada de segurança do banco de dados
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            //Criando o cliente responsavel por abrir conexão
            _client = new MongoClient(settings);

            //Buscar o banco de dados: **Cinereview**
            MongoDBConexao = _client.GetDatabase(_settings.Database);
        }

        public void Dispose()
        {
            //Fechar conexão com o banco de Dados
            MongoDBConexao = null;
            _client = null;
        }
    }
}
