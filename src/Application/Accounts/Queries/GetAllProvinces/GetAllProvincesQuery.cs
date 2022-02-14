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
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace IndustrialServicesSystem.Application.Accounts.Queries.GetAllProvinces
{
    public class GetAllProvincesQuery : IRequest<GetAllProvincesVm>
    {
        public class GetAllProvincesQueryHandler : IRequestHandler<GetAllProvincesQuery, GetAllProvincesVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly IMapper _mapper;

            public GetAllProvincesQueryHandler(IIndustrialServicesSystemContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetAllProvincesVm> Handle(GetAllProvincesQuery request, CancellationToken cancellationToken)
            {
                var provinces = await _context.Province
                    .OrderBy(x => x.Name)
                    .ProjectTo<GetAllProvincesDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (provinces == null)
                {
                    return new GetAllProvincesVm()
                    {
                        Message = "عملیات موفق آمیز",
                        State = (int)GetAllProvincesState.ProvinceNotFound
                    };
                }

                return new GetAllProvincesVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetAllProvincesState.Success,
                    Provinces = provinces
                };
            }
        }
    }
}
