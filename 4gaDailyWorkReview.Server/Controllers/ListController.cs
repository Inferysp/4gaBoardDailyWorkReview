using _4gaDailyWorkReview.Server.DTOs;
using _4gaDailyWorkReview.Server.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _4gaDailyWorkReview.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //GET : api/List/42412253252
        [HttpGet("{id}")]
        public async Task<ActionResult<ListDTO>> GetList(long id)
        {
            var query = new GetListQuery(id);
            var list = await _mediator.Send(query);
            if (list is null)
                return NotFound();

            return Ok(new ListDTO 
            { 
                Id = list.Id.ToString(), 
                Name = list.Name
            });
        }
    }
}
