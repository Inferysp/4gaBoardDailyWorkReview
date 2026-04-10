using _4gaDailyWorkReview.Server.DTOs;
using _4gaDailyWorkReview.Server.Queries;
using _4gaDailyWorkReview.Server.Repositories.Interfaces;
using MediatR;

namespace _4gaDailyWorkReview.Server.Handlers
{
    public class GetCardQueryHandler : IRequestHandler<GetCardQuery, CardDTO>
    {
        private readonly ICardReadRepository _repository;

        public GetCardQueryHandler(ICardReadRepository repository )
        {
            _repository = repository;
        }

        public async Task<CardDTO> Handle(GetCardQuery request, CancellationToken ct)
        {
            return await _repository.GetCardByIdAsync(request.id, ct);
        }
    }
}
