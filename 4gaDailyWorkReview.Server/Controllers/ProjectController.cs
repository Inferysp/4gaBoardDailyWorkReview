using _4gaDailyWorkReview.Server.DTOs;
using _4gaDailyWorkReview.Server.Queries;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _4gaDailyWorkReview.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET : api/project/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProduct(long id)
        {
            Console.WriteLine("GetProduct task");
            var query = new GetProjectQuery(id);
            var project = await _mediator.Send(query);
            if (project is null)
                return NotFound();
            return Ok(project);
        }
    }
}
