using Application.Features.Mediator.Queries.Tag;
using Application.Features.Mediator.Results.Tag;
using MediatR;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.Tag
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult>
    {
        private readonly MovieContext _context;
        public GetTagByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Casts.FindAsync(request.TagId);
            return new GetTagByIdQueryResult
            {
                Title = value.Title
            };
        }
    }
}
