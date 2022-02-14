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

namespace IndustrialServicesSystem.Application.Posts.Commands.DeletePostComment
{
    public class DeletePostCommentCommand : IRequest<int>
    {
        public Guid PostCommentGuid { get; set; }

        public class DeletePostCommentCommandHandler : IRequestHandler<DeletePostCommentCommand, int>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public DeletePostCommentCommandHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeletePostCommentCommand request, CancellationToken cancellationToken)
            {
                var postComment = await _context.PostComment
                    .SingleOrDefaultAsync(x => x.PostCommentGuid == request.PostCommentGuid, cancellationToken);

                if (postComment != null)
                {
                    var comment = await _context.Comment
                        .SingleOrDefaultAsync(x => x.CommentGuid == postComment.PostCommentGuid, cancellationToken);

                    if (comment != null)
                    {
                        _context.PostComment.Remove(postComment);
                        _context.Comment.Remove(comment);

                        await _context.SaveChangesAsync(cancellationToken);

                        return 1;
                    }
                }

                return -1;
            }
        }
    }
}
