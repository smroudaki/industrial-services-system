using MediatR;
using Microsoft.EntityFrameworkCore;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IndustrialServicesSystem.Application.OrderRequests.Queries.GetMonthlyIncome
{
    public class GetMonthlyIncomeQuery : IRequest<GetMonthlyIncomeVm>
    {
        public class GetMonthlyIncomeQueryHandler : IRequestHandler<GetMonthlyIncomeQuery, GetMonthlyIncomeVm>
        {
            private readonly IIndustrialServicesSystemContext _context;

            public GetMonthlyIncomeQueryHandler(IIndustrialServicesSystemContext context)
            {
                _context = context;
            }

            public async Task<GetMonthlyIncomeVm> Handle(GetMonthlyIncomeQuery request, CancellationToken cancellationToken)
            {
                DateTime dt = DateTime.Now.AddMonths(-1);

                var orderRequests = await _context.OrderRequest
                    .Where(or => or.CreationDate >= dt)
                    .ToListAsync(cancellationToken);

                if (orderRequests.Count <= 0) return new GetMonthlyIncomeVm
                {
                    Message = "درخواست سفارشی یافت نشد",
                    State = (int)GetMonthlyIncomeState.NotAnyOrderRequestFound
                };

                List<int> incomes = new List<int>();

                while (dt.Date < DateTime.Now.Date)
                {
                    dt = dt.AddDays(1);

                    var dayOrderRequestIncome = orderRequests.Where(or => or.CreationDate.Date == dt.Date)
                        .Sum(or => or.Price);

                    incomes.Add((int)dayOrderRequestIncome);
                }

                return new GetMonthlyIncomeVm
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetMonthlyIncomeState.Success,
                    Incomes = incomes
                };
            }
        }
    }
}
