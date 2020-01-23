﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask06.ClassesOfUniversity.ExceptionsClasses
{
    /// <summary>
    /// Exception For Session class
    /// </summary>
    public class SessionException : UniversityException
    {
        public SessionException() : base()
        {
        }

        public SessionException(string message) : base(message)
        {
        }

    }
}
