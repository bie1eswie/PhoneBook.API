﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Utilities.ErrorLogging
{
		public interface ILoggerManager
		{
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
        void LogFatal(string message);
        void LogFatal(Exception exception);
    }
}
