using Application.Features.Mediator.Results.Cast;
using Application.Features.Mediator.Results.Tag;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Queries.Tag
{
    public class GetTagByIdQuery : IRequest<GetTagByIdQueryResult>
    {
        public int TagId { get; set; }

        public GetTagByIdQuery(int tagId)
        {
            TagId = tagId;
        }
    }
}
