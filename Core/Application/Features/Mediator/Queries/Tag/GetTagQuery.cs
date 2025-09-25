using Application.Features.Mediator.Results.Tag;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Queries.Tag
{
    public class GetTagQuery :IRequest<List<GetTagQueryResult>>
    {
    }
}
