using Cinereview.Configuration.Database;
using Cinereview.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinereview.Repository
{
    public class UserRepository
    {
        private String collection = "User";
        private MongoDBContext mongoDBContext;

        public UserRepository(MongoDBContext mongoDBContext)
        {
            this.mongoDBContext = mongoDBContext;
        }

        public async Task<User> InsertAsync(User user)
        {
            var userCollection = mongoDBContext.MongoDBConexao.GetCollection<User>(collection);

            userCollection.InsertOne(user);
            return user;
        }

        public async Task<List<User>> GetListAsync() 
        {
            var userCollection = mongoDBContext.MongoDBConexao.GetCollection<User>(collection);

            var retorno = await userCollection.FindAsync<User>(new BsonDocument());
            return retorno.ToList();
        }

        public async Task<User> GetByIdAsync(Guid id) 
        {
            var userCollection = mongoDBContext.MongoDBConexao.GetCollection<User>(collection);

            var filterB = Builders<User>.Filter;
            var filter = filterB.Eq(u => u.Id, id);

            var retorno = await userCollection.FindAsync(filter);
            return retorno.FirstOrDefault();
        }

        public async Task<User> UpdateUserAsync(User user) 
        {
            var userCollection = mongoDBContext.MongoDBConexao.GetCollection<User>(collection);

            var retorno = await userCollection.ReplaceOneAsync(u => u.Id == user.Id, user);

            return user; 
        }

        public async Task DeleteUserAsync(Guid id) 
        {
            var userCollection = mongoDBContext.MongoDBConexao.GetCollection<User>(collection);

            var filterB = Builders<User>.Filter;
            var filter = filterB.Eq(u => u.Id, id);

            var retorno = await userCollection.DeleteOneAsync(filter);
            return;
        }
    }
}
