using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Commands.Tag
{
    public class CreateTagCommand :IRequest
    {
        public string Title { get; set; }
    }
}
