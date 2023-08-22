using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using registrationTask.DTO;
using registrationTask.Models;
using registrationTask.repository;

namespace registrationTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var user = await userRepository.GetAll();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(userDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Age = userDto.Age,
                Phone = userDto.Phone,
            };
            userRepository.Add(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> UpdateUser(int id, userDto dto)
        {
            var user = await userRepository.FindById(id);

            if (user == null)
            {
                return NotFound($"Not user found by this Id");
            }

            user.Name = dto.Name;
            user.Email = dto.Email;
            user.Age = dto.Age;
            user.Phone = dto.Phone;

            userRepository.update(user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            var user = await userRepository.FindById(id);

            if (user == null)
            {
                return NotFound($"Not user found by this Id");
            }

            userRepository.Delete(user);
            return Ok(user);
        }
    }
}
