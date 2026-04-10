using _4gaDailyWorkReview.Server.DTOs;
using _4gaDailyWorkReview.Server.Queries;
using _4gaDailyWorkReview.Server.Repositories;
using MediatR;
using NuGet.Protocol.Plugins;

namespace _4gaDailyWorkReview.Server.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDTO>
    {
        private readonly IUserReadRepository _repository;

        public GetUserQueryHandler(IUserReadRepository userAccountReadRepository)
        {
             _repository = userAccountReadRepository;
        }

        public async Task<UserDTO> Handle(GetUserQuery request, CancellationToken ct)
        {
            return await _repository.GetUserByIdAsync(request.Id, ct);
        }
    }
}
