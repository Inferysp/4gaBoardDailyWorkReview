using _4gaDailyWorkReview.Server.DTOs;
using _4gaDailyWorkReview.Server.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _4gaDailyWorkReview.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BoardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //GET : api/board/4
        [HttpGet("{id}")]
        public async Task<ActionResult<BoardDTO>> GetBoard(long id)
        {
            Console.WriteLine($"GetBoard Task for id = {id}");
            var query = new GetBoardQuery(id);
            var board = await _mediator.Send(query);
            if (board is null)
                return NotFound();
            return Ok(board);
        }
    }
}
