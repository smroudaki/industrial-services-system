using MediatR;
using Microsoft.EntityFrameworkCore;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Domain.Entities;
using IndustrialServicesSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IndustrialServicesSystem.Application.ContractorDocuments.Commands.CreateContractorDocument
{
    public class CreateContractorDocumentCommand : IRequest<CreateContractorDocumentVm>
    {
        public Guid TitleCodeGuid { get; set; }

        public Guid DocumentGuid { get; set; }

        public string Description { get; set; }

        public class CreateContractorDocumentCommandHandler : IRequestHandler<CreateContractorDocumentCommand, CreateContractorDocumentVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly ICurrentUserService _currentUserService;

            public CreateContractorDocumentCommandHandler(IIndustrialServicesSystemContext context,
                ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<CreateContractorDocumentVm> Handle(CreateContractorDocumentCommand request, CancellationToken cancellationToken)
            {
                var currentUser = await _context.User
                   .Where(u => u.UserGuid == Guid.Parse(_currentUserService.NameIdentifier) && !u.IsDelete)
                   .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null) return new CreateContractorDocumentVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)CreateDocumentState.UserNotFound
                };

                Contractor contractor = await _context.Contractor
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (contractor == null) return new CreateContractorDocumentVm
                {
                    Message = "سرویس دهنده مورد نظر یافت نشد",
                    State = (int)CreateDocumentState.ContractorNotFound
                };

                var titleCode = await _context.Code
                    .SingleOrDefaultAsync(c => c.CodeGuid == request.TitleCodeGuid && !c.IsDelete);

                if (titleCode == null) return new CreateContractorDocumentVm
                {
                    Message = "نام مدرک مورد نظر یافت نشد",
                    State = (int)CreateDocumentState.TitleCodeNotFound
                };

                var document = await _context.Document
                    .SingleOrDefaultAsync(d => d.DocumentGuid == request.DocumentGuid && !d.IsDelete);

                if (document == null) return new CreateContractorDocumentVm
                {
                    Message = "تصویر آپلود شده یافت نشد",
                    State = (int)CreateDocumentState.DocumentNotFound
                };

                ContractorDocument contractorDocument = new ContractorDocument
                {
                    ContractorId = contractor.ContractorId,
                    TitleCodeId = titleCode.CodeId,
                    Description = request.Description,
                    DocumentId = document.DocumentId
                };

                _context.ContractorDocument.Add(contractorDocument);

                await _context.SaveChangesAsync(cancellationToken);

                return new CreateContractorDocumentVm
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)CreateDocumentState.Success
                };
            }
        }
    }
}
