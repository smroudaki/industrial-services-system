﻿using System;
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

namespace IndustrialServicesSystem.Application.Contact.Commands.CreateSuggestion
{
    public class CreateSuggestionCommand : IRequest<CreateSuggestionVm>
    {
        public string Subject { get; set; }

        public string Description { get; set; }

        public class CreateSuggestionCommandHandler : IRequestHandler<CreateSuggestionCommand, CreateSuggestionVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUser;

            public CreateSuggestionCommandHandler(IIndustrialServicesSystemContext context, ICurrentUserService currentUser)
            {
                _context = context;
                _currentUser = currentUser;
            }

            public async Task<CreateSuggestionVm> Handle(CreateSuggestionCommand request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null) return new CreateSuggestionVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)CreateSuggestionState.UserNotFound
                };

                Suggestion suggestion = new Suggestion()
                {
                    UserId = currentUser.UserId,
                    Subject = request.Subject,
                    Description = request.Description
                };

                _context.Suggestion.Add(suggestion);

                await _context.SaveChangesAsync(cancellationToken);

                return new CreateSuggestionVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)CreateSuggestionState.Success
                };
            }
        }
    }
}
