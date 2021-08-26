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
    public class MovieRepository
    {
        private String collection = "Movie";
        private MongoDBContext mongoDBContext;

        public MovieRepository(MongoDBContext mongoDBContext)
        {
            this.mongoDBContext = mongoDBContext;
        }

        public async Task<Movie> InsertAsync(Movie movie)
        {
            var movieCollection = mongoDBContext.MongoDBConexao.GetCollection<Movie>(collection);

            movieCollection.InsertOne(movie);
            return movie;
        }

        public async Task<Movie> UpdateAsync(Movie movie)
        {
            var movieCollection = mongoDBContext.MongoDBConexao.GetCollection<Movie>(collection);

            var retorno = await movieCollection.ReplaceOneAsync(u => u.Id == movie.Id, movie);

            return movie;
        }

        public async Task<List<Movie>> GetListAsync() 
        {
            var movieCollection = mongoDBContext.MongoDBConexao.GetCollection<Movie>(collection);

            var retorno = await movieCollection.FindAsync<Movie>(new BsonDocument());
            return retorno.ToList();
        }

        public async Task<Movie> GetByIdAsync(Guid id) 
        {
            var movieCollection = mongoDBContext.MongoDBConexao.GetCollection<Movie>(collection);

            var filterB = Builders<Movie>.Filter;
            var filter = filterB.Eq(u => u.Id, id);

            var retorno = await movieCollection.FindAsync(filter);
            return retorno.FirstOrDefault();
        }
        
        public async Task DeleteAsync(Guid id) 
        {
            var movieCollection = mongoDBContext.MongoDBConexao.GetCollection<Movie>(collection);

            var filterB = Builders<Movie>.Filter;
            var filter = filterB.Eq(u => u.Id, id);

            var retorno = await movieCollection.DeleteOneAsync(filter);
            return;
        }

        public async Task<List<Movie>> GetMoviesWhereContainsNameAsync(string name)
        {
            var movieCollection = mongoDBContext.MongoDBConexao.GetCollection<Movie>(collection);

            var filterB = Builders<Movie>.Filter;
            var filter = filterB.Where(m => m.Name.ToUpper().Contains(name.ToUpper()));

            var retorno = await movieCollection.FindAsync(filter);
            return retorno.ToList();
        }

        public async Task<List<Movie>> GetMoviesWhereContainsGenreAsync(string genre)
        {
            var movieCollection = mongoDBContext.MongoDBConexao.GetCollection<Movie>(collection);

            var filterB = Builders<Movie>.Filter;
            var filter = filterB.Where(m => m.Genre.ToUpper().Contains(genre.ToUpper()));

            var retorno = await movieCollection.FindAsync(filter);
            return retorno.ToList();
        }

        public async Task<List<Movie>> GetMoviesByYear(int startYear, int endYear)
        {
            var movieCollection = mongoDBContext.MongoDBConexao.GetCollection<Movie>(collection);

            var filterB = Builders<Movie>.Filter;
            var filter = filterB.Where(m => m.Year >= startYear && m.Year <= endYear);

            var retorno = await movieCollection.FindAsync(filter);
            return retorno.ToList();
        }
    }
}
