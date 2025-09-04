using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureAvaibleToTrueCommand : IRequest
    {
        public int Id { get; set; }
        public UpdateCarFeatureAvaibleToTrueCommand(int id)
        {
            Id = id;
        }
    }
}
