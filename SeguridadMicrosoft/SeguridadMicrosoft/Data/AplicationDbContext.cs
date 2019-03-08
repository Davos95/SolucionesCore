﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeguridadMicrosoft.Data
{
    public class AplicationDbContext: IdentityDbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options) { }
    }
}
