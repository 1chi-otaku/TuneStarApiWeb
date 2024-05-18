using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tune_Star.BLL.DTO;
using Tune_Star.BLL.Interfaces;

namespace TuneStarApiWeb.Controllers
{
    [ApiController]
    [Route("api/Administrator")]
    public class AdministratorController : Controller
    {
        private readonly IUserService userService;
        public AdministratorController(IUserService userServ)
        {
            userService = userServ;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return userService.GetUsers().Result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> DisproveUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            await userService.DeleteUser(id);
           
            return Ok(user);
        }

        // PUT: api/Students
        [HttpPut]
        public async Task<ActionResult<UserDTO>>ApproveUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user_ = await userService.GetUser(id);
          
            if (user_ == null)
            {
                return NotFound();
            }
            user_.Status = 1;
            await userService.UpdateUser(user_);


            return Ok(user_);
        }

    }
}

