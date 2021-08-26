using Cinereview.Models.DTO;
using Cinereview.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinereview.Controllers
{
    [Route("v1/movies")]
    public class MovieController : Controller
    {
        private MovieService movieService;

        public MovieController(MovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<MovieDTO> CreateMovie([FromBody] MovieDTO movieDTO)
        {
            return await movieService.CreateMovie(movieDTO);
        }

        [HttpPatch]
        [Route("edit")]
        public async Task<MovieDTO> EditMovie([FromBody] MovieDTO movieDTO)
        {
            return await movieService.UpdateMovie(movieDTO);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task DeleteMovie(string id)
        {
            await movieService.DeleteMovie(id);
        }
                
        [HttpGet]
        [Route("list")]
        public async Task<List<MovieDTO>> GetListMovie()
        {
            return await movieService.ListMovies();
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<MovieDTO> GetMovieById(string id)
        {
            return await movieService.GetMovieById(id);
        }

        [HttpPost]
        [Route("get-name")]
        public async Task<List<MovieDTO>> GetMovieByName([FromBody] MovieDTO movieDTO)
        {
            return await movieService.GetMoviesByName(movieDTO.Name);
        }

        [HttpPost]
        [Route("get-genre")]
        public async Task<List<MovieDTO>> GetMovieByGenre([FromBody] MovieDTO movieDTO)
        {
            return await movieService.GetMoviesByGenre(movieDTO.Genre);
        }

        [HttpPost]
        [Route("get-year")]
        public async Task<List<MovieDTO>> GetMovieByYear([FromBody] MovieDTO movieDTO)
        {
            return await movieService.GetMoviesByYear(movieDTO.StartYear.Value, movieDTO.EndYear.Value);
        }
    }
}
