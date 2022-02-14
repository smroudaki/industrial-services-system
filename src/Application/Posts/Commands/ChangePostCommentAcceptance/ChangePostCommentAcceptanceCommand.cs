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

namespace IndustrialServicesSystem.Application.Posts.Commands.ChangePostCommentAcceptance
{
    public class ChangePostCommentAcceptanceCommand : IRequest<int>
    {
        public Guid PostCommentGuid { get; set; }

        public bool IsAccept { get; set; }

        public class ChangePostCommentAcceptanceCommandHandler : IRequestHandler<ChangePostCommentAcceptanceCommand, int>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public ChangePostCommentAcceptanceCommandHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(ChangePostCommentAcceptanceCommand request, CancellationToken cancellationToken)
            {
                var query = await _context.PostComment.SingleOrDefaultAsync(x => x.PostCommentGuid == request.PostCommentGuid);

                if (query != null)
                {
                    query.IsAccept = request.IsAccept;

                    await _context.SaveChangesAsync(cancellationToken);

                    return 1;
                }

                return -1;
            }
        }
    }
}
