using Cinereview.Models.DTO;
using Cinereview.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinereview.Controllers
{
    [Route("v1/users")]
    public class UserController : Controller
    {
        private UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<UserDTO> CreateUser([FromBody] UserDTO userDTO)
        {
            return await userService.CreateUser(userDTO);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task DeleteUser(string id)
        {
            await userService.DeleteUser(id);
        }

        [HttpPatch]
        [Route("edit")]
        public async Task<UserDTO> EditUser([FromBody] UserDTO userDTO)
        {
            return await userService.UpdadeUser(userDTO);
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<UserDTO>> ListUsers()
        {
            return await userService.GetList();
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<UserDTO> GetUserById(string id)
        {
            return await userService.GetById(id);
        }
    }
}
