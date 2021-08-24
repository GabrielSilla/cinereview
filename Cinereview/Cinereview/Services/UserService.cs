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
    public class UserService
    {
        private UserRepository userRepository;
        private IMapper mapper;
        public UserService(UserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<UserDTO> CreateUser(UserDTO userDTO)
        {
            User user = mapper.Map<User>(userDTO);
            User inserted = await userRepository.InsertAsync(user);

            return mapper.Map<UserDTO>(inserted);
        }
    }
}
