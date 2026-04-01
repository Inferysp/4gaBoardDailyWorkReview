using _4gaDailyWorkReview.Server.DTOs;
using _4gaDailyWorkReview.Server.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _4gaDailyWorkReview.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardController(IMediator mediator) {
            _mediator = mediator;
        }

        //GET : api/card/4232665651264512354
        [HttpGet("{id}")]
        public async Task<ActionResult<CardDTO>> GetCard(long id)
        {
            var query = new GetCardQuery(id);

            var x = await _mediator.Send(query);

            if (x == null)
                return NotFound();

            return Ok(new CardDTO
            {
                Id = x.Id.ToString(),
                Name = x.Name,
                Description = x.Description,
                UpdatedById = x.UpdatedById.ToString(),
                BoardId = x.BoardId.ToString(),
                CreatedById = x.CreatedById.ToString(),
                ListId = x.ListId.ToString(),
                Timer = x.Timer,
                DueDate = x.DueDate,
                UpdatedAt = x.UpdatedAt,
                CreatedAt = x.CreatedAt
            });
         }
    }
}
