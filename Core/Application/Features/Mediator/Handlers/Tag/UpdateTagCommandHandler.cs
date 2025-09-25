using Application.Features.Mediator.Commands.Tag;
using MediatR;
using Persistence.Context;

namespace Application.Features.Mediator.Handlers.Tag
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
    {
        private readonly MovieContext _context;
        public UpdateTagCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Tags.FindAsync(request.TagId);
            values.Title = request.Title;
            await _context.SaveChangesAsync();
        }
    }
}
