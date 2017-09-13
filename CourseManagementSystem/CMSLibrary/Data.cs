using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public class Data<T>
    {
        private string display;
        private T value;

        public string Display { get { return display; } }
        public T Value { get { return value; } }

        public Data(string display, T value)
        {
            this.display = display;
            this.value = value;
        }
    }

    public class Data : Data<string>
    {
        public Data(string display, string value) : base(display, value) { }
    }
}
