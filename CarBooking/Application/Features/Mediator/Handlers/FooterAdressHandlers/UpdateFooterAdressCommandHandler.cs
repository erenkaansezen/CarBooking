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
    public class UpdateFooterAdressCommandHandler: IRequestHandler<UpdateFooterAdressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAdressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAdressCommand request, CancellationToken cancellationToken)
        {
            var footerAdress = await _repository.GetByIdAsync(request.FooterAddressID);
            if (footerAdress != null)
            {
                footerAdress.Description = request.Description;
                footerAdress.Adress = request.Adress;
                footerAdress.Phone = request.Phone;
                footerAdress.Email = request.Email;
                await _repository.UpdateAsync(footerAdress);
            }
        }
    }
}
