using AutoMapper;
using Cinereview.Models;
using Cinereview.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinereview.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieDTO, Movie>();
        }        
    }
}
