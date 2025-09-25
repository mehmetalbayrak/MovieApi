using Application.Features.Mediator.Queries.Tag;
using Application.Features.Mediator.Results.Tag;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.Tag
{
    public class GetTagQueryHandler : IRequestHandler<GetTagQuery, List<GetTagQueryResult>>
    {
        private readonly MovieContext _context;
        public GetTagQueryHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Tags.ToListAsync();
            return values.Select(x => new GetTagQueryResult
            {
                TagId = x.TagId,
                Title = x.Title
            }).ToList();
        }
    }
}
