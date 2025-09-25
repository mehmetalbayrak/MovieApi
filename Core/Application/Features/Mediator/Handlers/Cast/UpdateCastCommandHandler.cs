using Application.Features.Mediator.Commands.Cast;
using MediatR;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.Cast
{
    internal class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
    {
        private readonly MovieContext _movieContext;

        public UpdateCastCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            var value = await _movieContext.Casts.FindAsync(request.CastId,cancellationToken);
            value.ImageUrl = request.ImageUrl;
            value.Surname = request.Surname;
            value.Biography = request.Biography;
            value.Overview = request.Overview;
            value.Title = request.Title;
            value.Name = request.Name;
            await _movieContext.SaveChangesAsync();
        }
    }
}
