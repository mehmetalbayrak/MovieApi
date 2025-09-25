using Application.Features.Mediator.Commands.Tag;
using MediatR;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.Tag
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand>
    {
        private readonly MovieContext _context;
        public CreateTagCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            await _context.Tags.AddAsync(new Domain.Entities.Tag
            {
                Title = request.Title
            });
            await _context.SaveChangesAsync();
        }
    }
}
