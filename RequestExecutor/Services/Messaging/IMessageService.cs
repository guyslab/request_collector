﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestExecutor.Services
{
    public interface IMessageService
    {
        bool Enqueue(string message);
    }
}
