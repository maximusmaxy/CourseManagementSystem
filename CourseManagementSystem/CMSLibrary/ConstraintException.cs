using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public abstract class ConstraintException : Exception
    {
        public ConstraintException(string message) : base(message) { }

        public abstract string Constraint { get; }
    }
}
