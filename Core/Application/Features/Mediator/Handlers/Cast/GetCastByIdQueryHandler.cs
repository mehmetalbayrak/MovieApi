using Application.Features.Mediator.Queries.Cast;
using Application.Features.Mediator.Results.Cast;
using MediatR;
using Persistence.Context;


namespace Application.Features.Mediator.Handlers.Cast
{
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _movieContext;

        public GetCastByIdQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _movieContext.Casts.FindAsync(request.CastId,cancellationToken);
            return new GetCastByIdQueryResult
            {
                Name = value.Name,
                CastId = value.CastId,
                Biography = value.Biography,
                ImageUrl = value.ImageUrl,
                Overview = value.Overview,
                Surname = value.Surname,
                Title = value.Title
            };
        }
    }
}
