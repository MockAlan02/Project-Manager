﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Interfaz
{
    public interface IDatabaseProviderStrategy
    {
        void Configure(DbContextOptionsBuilder optionsBuilder, string connectionString);
    }
}