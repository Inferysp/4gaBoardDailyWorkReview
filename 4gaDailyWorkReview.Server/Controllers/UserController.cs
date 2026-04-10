using _4gaDailyWorkReview.Server.DTOs;
using _4gaDailyWorkReview.Server.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _4gaDailyWorkReview.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediar;
        public UserController(IMediator mediar)
        {
            _mediar = mediar;
        }

        //GET : api/user/32452523556
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(long id)
        {
            var query = new GetUserQuery(id);
            var user = await _mediar.Send(query);

            if (user == null)
                return NotFound();

            return Ok(new UserDTO() { Id = user.Id.ToString(), Name = user.Name }) ;
        }

    }
}
