using AutoMapper;
using Cinereview.Models;
using Cinereview.Models.DTO;
using Cinereview.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinereview.Services
{
    public class MovieService
    {
        private MovieRepository movieRepository;
        private IMapper mapper;
        public MovieService(MovieRepository movieRepository, IMapper mapper)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }


        public async Task<MovieDTO> GetMovieById(string id)
        {
            Guid movieId = Guid.Parse(id);
            Movie movie = await movieRepository.GetByIdAsync(movieId);

            return mapper.Map<MovieDTO>(movie);
        }

        public async Task<List<MovieDTO>> ListMovies()
        {
            List<Movie> lista = await movieRepository.GetListAsync();

            return mapper.Map<List<MovieDTO>>(lista);
        }

        public async Task<MovieDTO> UpdateMovie(MovieDTO movieDTO)
        {
            Movie movie = mapper.Map<Movie>(movieDTO);

            Movie updated = await movieRepository.UpdateAsync(movie);

            return mapper.Map<MovieDTO>(updated);
        }

        public async Task<MovieDTO> CreateMovie(MovieDTO movieDTO)
        {
            Movie movie = mapper.Map<Movie>(movieDTO);
            movie.Id = Guid.NewGuid();

            Movie inserted = await movieRepository.InsertAsync(movie);

            return mapper.Map<MovieDTO>(inserted);
        }

        public async Task DeleteMovie(string id)
        {
            Guid movieId = Guid.Parse(id);
            await movieRepository.DeleteAsync(movieId);

            return;
        }

        public async Task<List<MovieDTO>> GetMoviesByName(string name)
        {            
            List<Movie> movieList = await movieRepository.GetMoviesWhereContainsNameAsync(name);

            return mapper.Map<List<MovieDTO>>(movieList);
        }

        public async Task<List<MovieDTO>> GetMoviesByGenre(string genre)
        {
            List<Movie> movieList = await movieRepository.GetMoviesWhereContainsGenreAsync(genre);

            return mapper.Map<List<MovieDTO>>(movieList);
        }

        public async Task<List<MovieDTO>> GetMoviesByYear(int startYear, int endYear)
        {
            List<Movie> movieList = await movieRepository.GetMoviesByYear(startYear, endYear);

            return mapper.Map<List<MovieDTO>>(movieList);
        }
    }
}
