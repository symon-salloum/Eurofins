﻿using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DatabaseFactory
{
    public interface IDatabaseFactory : IDisposable
    {
        DatabaseContext GetDatabaseContext();
    }
}
