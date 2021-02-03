using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestExecutor.Commands
{
    public interface ICommand
    {
        void Execute();
    }
}
