﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.Server.HandlerServices.Interfaces
{
    public interface IHandlerService<T1, T2>
    {
        Task<T2> ExecuteAsync(T1 model);
    }
}
