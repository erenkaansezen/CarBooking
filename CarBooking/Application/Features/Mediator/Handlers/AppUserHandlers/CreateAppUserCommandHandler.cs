using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Enums;
using Application.Features.Mediator.Commands.AppUserCommands;
using Application.Interfaces;
using MediatR;
using Web.Domain.Entities;

namespace Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;
        public CreateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(new AppUser
            {
                Password = request.Password,
                UserName = request.UserName,
                AppRoleId = (int)RolesType.Member,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname
            });
        }
    }
}
