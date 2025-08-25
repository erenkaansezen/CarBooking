using Application.Features.CQRS.Commands.BrandCommands;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;
        public CreateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateBrandCommand command)
        {
            Brand brand = new Brand
            {
                Name = command.Name,

            };
            await _repository.AddAsync(brand);
        }
    }
}
