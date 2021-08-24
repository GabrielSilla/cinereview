using Cinereview.Configuration.Database;
using Cinereview.Models;
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
    }
}
