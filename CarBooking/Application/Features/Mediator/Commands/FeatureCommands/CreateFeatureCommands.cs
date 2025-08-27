using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Mediator.Commands.FeatureCommands
{
    public class CreateFeatureCommands : IRequest
    {
        public string Name { get; set; }
    }
}
