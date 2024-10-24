using System.Net;
using INTELLISTOCKS.MODELS.user;
using INTELLISTOCKS.REPOSITORY.user;
using Microsoft.AspNetCore.Mvc;

namespace INTELLISTOCKS.API.controller
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null.");
            }

            try
            {
                var createdUser = await _userRepository.Create(user);
                var uri = Url.Action("GetUserById", new { id = createdUser.ID });
                return Created(uri, createdUser);
            }
            catch (Exception error)
            {
                return StatusCode(500, "Internal server error: " + error.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userRepository.GetAll();
                return Ok(users);
            }
            catch (Exception error)
            {
                return StatusCode(500, "Internal server error: " + error.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userRepository.GetById(id);
                if (user == null)
                    return NotFound("User not found with id: " + id);
                return Ok(user);
            }
            catch (Exception error)
            {
                return StatusCode(500, "Internal server error: " + error.Message);
            }
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null.");
            }

            try
            {
                var foundUser = await _userRepository.GetById(id);
                if (foundUser == null)
                    return NotFound("User not found with id: " + id);

                // Update only relevant fields
                foundUser.Name = user.Name;
                foundUser.Email = user.Email;

                var updatedUser = await _userRepository.Update(foundUser);
                return Ok(updatedUser);
            }
            catch (Exception error)
            {
                return StatusCode(500, "Internal server error: " + error.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _userRepository.GetById(id);
                if (user == null)
                    return NotFound("User not found with id: " + id);

                await _userRepository.Delete(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return StatusCode(500, "Internal server error: " + error.Message);
            }
        }
    }
}
