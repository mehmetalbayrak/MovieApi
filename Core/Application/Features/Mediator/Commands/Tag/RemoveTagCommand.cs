using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Commands.Tag
{
    public class RemoveTagCommand :IRequest
    {
        public int TagId { get; set; }

        public RemoveTagCommand(int tagId)
        {
            TagId = tagId;
        }
    }
}
