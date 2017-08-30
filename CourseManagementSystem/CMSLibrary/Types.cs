using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public class Types
    {
        public static Dictionary<string, int> GenderType { get; set; } = new Dictionary<string, int>()
        {
            ["Male"] = 1,
            ["Female"] = 2
        };
        public static Dictionary<string, int> UnitType { get; set; } = new Dictionary<string, int>()
        {
            ["Core"] = 1,
            ["Elective"] = 2
        };
        public static Dictionary<string, int> DeliveryType { get; set; } = new Dictionary<string, int>()
        {
            ["Face-To-Face"] = 1,
            ["Online"] = 2
        };
        public static Dictionary<string, int> CourseResults { get; set; } = new Dictionary<string, int>()
        {
            ["Pass"] = 1,
            ["Fail"] = 2,
            ["Not Completed"] = 3
        };
        public static Dictionary<string, int> Semester { get; set; } = new Dictionary<string, int>()
        {
            ["One"] = 1,
            ["Two"] = 2
        };
    }
}
