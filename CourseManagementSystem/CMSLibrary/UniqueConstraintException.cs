﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public class UniqueConstraintException : Exception
    {
        private static Regex uniqueConstraintRegex = new Regex(@"^Violation of UNIQUE KEY constraint '([^']+?)'");

        public string UniqueConstraint { get; private set; }

        public UniqueConstraintException(string message) : base(message)
        {
            UniqueConstraint = uniqueConstraintRegex.Match(message).Groups[1].Value;
        }
    }
}