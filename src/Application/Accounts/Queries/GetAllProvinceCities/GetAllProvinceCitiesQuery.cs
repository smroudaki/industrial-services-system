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

namespace IndustrialServicesSystem.Application.Accounts.Queries.GetAllProvinceCities
{
    public class GetAllProvinceCitiesQuery : IRequest<GetAllProvinceCitiesVm>
    {
        public Guid ProvinceGuid { get; set; }

        public class GetAllProvinceCitiesQueryHandler : IRequestHandler<GetAllProvinceCitiesQuery, GetAllProvinceCitiesVm>
        {
            private readonly IIndustrialServicesSystemContext _context;
            private readonly IMapper _mapper;

            public GetAllProvinceCitiesQueryHandler(IIndustrialServicesSystemContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetAllProvinceCitiesVm> Handle(GetAllProvinceCitiesQuery request, CancellationToken cancellationToken)
            {
                var province = await _context.Province
                    .Where(x => x.ProvinceGuid == request.ProvinceGuid)
                    .SingleOrDefaultAsync(cancellationToken);

                if (province == null)
                {
                    return new GetAllProvinceCitiesVm()
                    {
                        Message = "استان مورد نظر یافت نشد",
                        State = (int)GetAllProvinceCitiesState.ProvinceNotFound
                    };
                }

                var cities = await _context.City
                    .Where(x => x.ProvinceId == province.ProvinceId)
                    .OrderBy(x => x.Name)
                    .ProjectTo<GetAllProvinceCitiesDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (cities.Count <= 0)
                {
                    return new GetAllProvinceCitiesVm()
                    {
                        Message = "موردی یافت نشد",
                        State = (int)GetAllProvinceCitiesState.ProvinceCitiesNotFound
                    };
                }

                return new GetAllProvinceCitiesVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetAllProvinceCitiesState.Success,
                    Cities = cities
                };
            }
        }
    }
}
