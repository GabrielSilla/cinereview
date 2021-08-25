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
            user.Id = Guid.NewGuid();

            User inserted = await userRepository.InsertAsync(user);

            return mapper.Map<UserDTO>(inserted);
        }

        public async Task<List<UserDTO>> GetList() 
        {
            List<User> lista = await userRepository.GetListAsync();

            return mapper.Map<List<UserDTO>>(lista);
        }

        public async Task<UserDTO> GetById(string id)
        {
            Guid userId = Guid.Parse(id);
            User user = await userRepository.GetByIdAsync(userId);

            return mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UpdadeUser(UserDTO userDTO)
        {
            User user = mapper.Map<User>(userDTO);

            User updated = await userRepository.UpdateUserAsync(user);

            return mapper.Map<UserDTO>(updated);
        }

        public async Task DeleteUser(string id)
        {
            Guid userId = Guid.Parse(id);
            await userRepository.DeleteUserAsync(userId);

            return;
        }
    }
}
