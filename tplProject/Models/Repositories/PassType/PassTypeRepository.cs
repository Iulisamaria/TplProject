﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.Models;

namespace tplProject.Models.Repositories
{
    public class PassTypeRepository:IPassType
    {
        private readonly tpl_databaseContext _DatabaseContext;
        public PassTypeRepository(tpl_databaseContext DatabaseContext)
        {
            _DatabaseContext = DatabaseContext;
        }
    }
}
