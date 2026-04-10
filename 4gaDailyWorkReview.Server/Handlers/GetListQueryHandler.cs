using _4gaDailyWorkReview.Server.DTOs;
using _4gaDailyWorkReview.Server.Queries;
using _4gaDailyWorkReview.Server.Repositories.Interfaces;
using MediatR;
using NuGet.Protocol.Plugins;

namespace _4gaDailyWorkReview.Server.Handlers
{
    public class GetListQueryHandler : IRequestHandler<GetListQuery, ListDTO>
    {
        private readonly IListReadRepository _repository;

        public GetListQueryHandler(IListReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<ListDTO> Handle(GetListQuery request, CancellationToken ct)
        {
            return await _repository.GetListByIdAsync(request.Id, ct);
        }
    }
}
