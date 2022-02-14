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

namespace IndustrialServicesSystem.Application.Posts.Commands.LikePost
{
    public class LikePostCommand : IRequest<int>
    {
        public Guid PostGuid { get; set; }

        public class LikePostCommandHandler : IRequestHandler<LikePostCommand, int>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public LikePostCommandHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(LikePostCommand request, CancellationToken cancellationToken)
            {
                var query = await _context.Post
                    .SingleOrDefaultAsync(x => x.PostGuid == request.PostGuid && !x.IsDelete);

                if (query != null)
                {
                    query.LikeCount += 1;
                    query.ModifiedDate = DateTime.Now;

                    await _context.SaveChangesAsync(cancellationToken);

                    return 1;
                }

                return -1;
            }
        }
    }
}
