using System;
using System.Collections.Generic;
using System.Text;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using IndustrialServicesSystem.Domain.Enums;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace IndustrialServicesSystem.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryVm>
    {
        public Guid? CategoryGuid { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryVm>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public CreateCategoryCommandHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<CreateCategoryVm> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var parent = await _context.Category
                    .Where(x => x.CategoryGuid == request.CategoryGuid)
                    .SingleOrDefaultAsync(cancellationToken);

                if (parent == null) return new CreateCategoryVm()
                {
                    Message = "دسته بندی پدر یافت نشد",
                    State = (int)CreateCategoryState.ParentNotFound
                };

                var category = new Category
                {
                    ParentCategoryId = parent.CategoryId,
                    DisplayName = request.Name,
                    Sort = request.Order,
                };

                _context.Category.Add(category);

                await _context.SaveChangesAsync(cancellationToken);

                return new CreateCategoryVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)CreateCategoryState.Success
                };
            }
        }
    }
}
