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

namespace IndustrialServicesSystem.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<int>
    {
        public Guid CategoryGuid { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public UpdateCategoryCommandHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                var query = await _context.Category
                    .SingleOrDefaultAsync(x => x.CategoryGuid == request.CategoryGuid && !x.IsDelete);

                if (query != null)
                {
                    query.DisplayName = request.Name;
                    query.Sort = request.Order;
                    query.ModifiedDate = DateTime.Now;

                    await _context.SaveChangesAsync(cancellationToken);

                    return 1;
                }

                return -1;
            }
        }
    }
}
