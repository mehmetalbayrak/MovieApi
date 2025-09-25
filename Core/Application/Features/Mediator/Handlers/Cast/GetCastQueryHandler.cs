using Application.Features.Mediator.Queries.Cast;
using Application.Features.Mediator.Results.Cast;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;


namespace Application.Features.Mediator.Handlers.Cast
{
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
    {
        private readonly MovieContext _movieContext;

        public GetCastQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            var values = await _movieContext.Casts.ToListAsync(cancellationToken);
            return values.Select(x => new GetCastQueryResult
            {
                CastId = request.CastId,
                Biography = request.Biography,
                ImageUrl = request.ImageUrl,
                Name = request.Name,
                Overview = request.Overview,
                Surname = request.Surname,
                Title = request.Title,
            }).ToList();
        }
    }
}
