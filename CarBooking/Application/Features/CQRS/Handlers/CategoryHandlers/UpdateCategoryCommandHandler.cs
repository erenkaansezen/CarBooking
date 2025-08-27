using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Interfaces;
using Web.Domain.Entities;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;
        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCategoryCommand command)
        {
            var category = await _repository.GetByIdAsync(command.Id);
            if (category != null)
            {
                category.Name = command.Name;
                await _repository.UpdateAsync(category);
            }
        }
    }
}
