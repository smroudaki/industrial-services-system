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

namespace IndustrialServicesSystem.Application.Posts.Commands.ChangePostInSliderStatus
{
    public class ChangePostInSliderStatusCommand : IRequest<ChangePostInSliderStatusVm>
    {
        public Guid PostGuid { get; set; }

        public Guid? SliderCodeGuid { get; set; }

        public class ChangePostIsInSliderStatusCommandHandler : IRequestHandler<ChangePostInSliderStatusCommand, ChangePostInSliderStatusVm>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public ChangePostIsInSliderStatusCommandHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<ChangePostInSliderStatusVm> Handle(ChangePostInSliderStatusCommand request, CancellationToken cancellationToken)
            {
                Post post = await _context.Post
                    .SingleOrDefaultAsync(x => x.PostGuid == request.PostGuid && !x.IsDelete);

                if (post == null) return new ChangePostInSliderStatusVm
                {
                    Message = "پست مورد نظر یافت نشد",
                    State = (int)ChangePostInSliderStatusState.PostNotFound
                };

                DateTime now = DateTime.Now;

                if (request.SliderCodeGuid == null)
                {
                    post.SliderCodeId = null;
                }
                else
                {
                    Code sliderCode = await _context.Code
                        .SingleOrDefaultAsync(x => x.CodeGuid == request.SliderCodeGuid && !x.IsDelete);

                    if (sliderCode == null) return new ChangePostInSliderStatusVm
                    {
                        Message = "اسلایدر مورد نظر یافت نشد",
                        State = (int)ChangePostInSliderStatusState.SliderNotFound
                    };

                    Post recentPostWithTheSliderGiven = await _context.Post
                        .FirstOrDefaultAsync(x => x.SliderCodeId == sliderCode.CodeId);

                    if (recentPostWithTheSliderGiven != null)
                    {
                        recentPostWithTheSliderGiven.SliderCodeId = null;
                        recentPostWithTheSliderGiven.ModifiedDate = now;
                    }

                    post.SliderCodeId = sliderCode.CodeId;
                }

                post.ModifiedDate = now;

                await _context.SaveChangesAsync(cancellationToken);

                return new ChangePostInSliderStatusVm
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)ChangePostInSliderStatusState.Success
                };
            }
        }
    }
}
