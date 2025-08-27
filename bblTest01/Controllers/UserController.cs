using Microsoft.AspNetCore.Mvc;

namespace bblTest01.Controllers
{
    public class UserController : Controller
    {
        [ApiController]
        [Route("users")]
        public class UsersController : ControllerBase
        {
            [HttpGet]
            public ActionResult<List<User>> GetAllUsers() => Ok(UserRepository.GetAll());

            [HttpGet("{id}")]
            public ActionResult<User> GetUser(long id)
            {
                var user = UserRepository.GetById(id);
                return user != null ? Ok(user) : NotFound($"User with ID {id} not found.");
            }

            [HttpPost]
            public ActionResult<User> CreateUser([FromBody] User user)
            {
                if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Email))
                    return BadRequest("Name, Username, and Email are required.");

                UserRepository.Add(user);
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }

            [HttpPut("{id}")]
            public IActionResult UpdateUser(long id, [FromBody] User user)
            {
                if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Email))
                    return BadRequest("Name, Username, and Email are required.");

                var updated = UserRepository.Update(id, user);
                return updated ? Ok(user) : NotFound($"User with ID {id} not found.");
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteUser(long id)
            {
                var deleted = UserRepository.Delete(id);
                return deleted ? NoContent() : NotFound($"User with ID {id} not found.");
            }
        }
    }
}
