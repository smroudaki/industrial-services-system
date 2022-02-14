using IndustrialServicesSystem.Application.Common.Interfaces;
using System;

namespace IndustrialServicesSystem.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
