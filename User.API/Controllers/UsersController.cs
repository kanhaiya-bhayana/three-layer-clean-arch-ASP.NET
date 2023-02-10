using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using User.Application;
using User.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        public UsersController(IUserService service)
        {
            _userService = (UserService)service;
        }

        [HttpGet]
        public ActionResult<List<Userd>> Get()
        {
            var userFromServices = _userService.GetAllUsers();
            return Ok(userFromServices);
        }

        [HttpPost]
        public ActionResult<Userd> Post(Userd userd)
        {
            var result = _userService.AddUser(userd);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult<Userd>? Put(Userd userd,int id)
        {
            var result =  _userService.UpdateUser(userd,id);
            if (result is null)
                return NotFound("User not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var result = _userService.DeleteUser(id);
            if (result is null)
                return NotFound("User not found.");

            return Ok(result);
        }

    }
}
