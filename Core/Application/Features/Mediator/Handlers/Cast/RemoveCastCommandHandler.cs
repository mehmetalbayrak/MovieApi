using Application.Features.Mediator.Commands.Cast;
using MediatR;
using Persistence.Context;

namespace Application.Features.Mediator.Handlers.Cast
{
    public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommand>
    {
        private readonly MovieContext _movieContext;

        public RemoveCastCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
        {
            var value = await _movieContext.Casts.FindAsync(request.CastId, cancellationToken);
            _movieContext.Casts.Remove(value);
            await _movieContext.SaveChangesAsync();
        }
    }
}
