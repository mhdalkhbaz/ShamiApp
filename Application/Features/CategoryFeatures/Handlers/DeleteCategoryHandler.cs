using Application.Features.CategoryFeatures.Commands;
using Application.Features.CategoryFeatures.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Material;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Handlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryService _categoryService;
        private readonly IRepository<Category, int> _repository;
        private readonly IMapper _mapper;
        public DeleteCategoryHandler(ICategoryService categoryService, IMapper mapper, IRepository<Category, int> repository)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);
            _repository.SoftDelete(category);
            return Unit.Value;
        }
    }
}
