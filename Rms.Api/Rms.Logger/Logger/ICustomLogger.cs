using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logger
{
    public interface ICustomLogger
    {
        void Information(CustomLog log);
        void Debug(CustomLog log);
        void Warning(CustomLog log);
        void Error(CustomLog log);
    }
}
