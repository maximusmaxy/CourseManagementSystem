using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public class Data
    {
        private string display;
        private string value;

        public string Display { get { return display; } }
        public string Value { get { return value; } }

        public Data(string display, string value)
        {
            this.display = display;
            this.value = value;
        }
    }
}
