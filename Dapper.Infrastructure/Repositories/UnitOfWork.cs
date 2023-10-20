﻿using Dapper.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IProductRepsoitory productRepsoitory)
        {
                Product = productRepsoitory;
        }
        public IProductRepsoitory Product { get; private set; }
    }
}
