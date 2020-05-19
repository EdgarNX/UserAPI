using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Entity;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository ??
                throw new ArgumentNullException(nameof(userRepository));

        }

        [HttpGet]
        [Route("{userName}")]
        public IActionResult GetUser(string userName)
        {
            var userFromRepo = _userRepository.GetUser(userName);
            if (userFromRepo == null)
                return NotFound();

            return Ok(userFromRepo);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (_userRepository.UserExists(user.Name))
                return Ok("User already exists!");

            _userRepository.AddUser(user);
            _userRepository.Save();

            return Ok("User was added successfully!");
        }

        [HttpPut]
        [Route("{userName}")]
        public ActionResult UpdateUser(string userName, [FromBody] User user)
        {
            if (!_userRepository.UserExists(userName))
                return NotFound();

            var userFromRepo = _userRepository.GetUser(userName);
            if (userFromRepo == null)
                return NotFound();

            userFromRepo.Name = user.Name;
            userFromRepo.Password = user.Password;

            _userRepository.UpdateUser(userFromRepo);
            _userRepository.Save();

            return NoContent();
        }

        [HttpDelete]
        [Route("{userName}")]
        public IActionResult DeleteUser(string userName)
        {
            var userToDelete = _userRepository.GetUser(userName);

            if (userToDelete == null)
                return NotFound();

            _userRepository.DeleteUser(userToDelete);
            _userRepository.Save();

            return NoContent();
        }
    }
}
