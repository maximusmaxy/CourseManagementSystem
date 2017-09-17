using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public interface ISearchControl
    {
        void Reset();
        bool ValidateControl();
        void Append(StringBuilder sb);
    }
}
