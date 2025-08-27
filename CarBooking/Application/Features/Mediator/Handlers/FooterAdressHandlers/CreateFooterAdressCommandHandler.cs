using Application.Features.Mediator.Commands.FeatureCommands;
using Application.Features.Mediator.Commands.FooterAdressCommands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class CreateFooterAdressCommandHandler : IRequestHandler<CreateFooterAdressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;
        public CreateFooterAdressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateFooterAdressCommand request, CancellationToken cancellationToken)
        {
            FooterAddress footerAddress = new FooterAddress
            {
                Description = request.Description,
                Adress = request.Adress,
                Phone = request.Phone,
                Email = request.Email
            };
            await _repository.AddAsync(footerAddress);
        }
    }
}
