﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndustrialServicesSystem.Infrastructure.Identity
{
    public class JwtSettings
    {
        public string Key { get; set; }

        public string Issuer { get; set; }
    }
}
