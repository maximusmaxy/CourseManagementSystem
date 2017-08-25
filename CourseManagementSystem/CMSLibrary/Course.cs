using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public class Course : IData
    {
        public static string Table { get; set; } = "Courses";

        private int id;
        private string name;
        private double cost;
        private int deliveryType;
        private DateTime startDate;
        private DateTime endDate;
        private int locationId;
        private string areaOfStudy;
        private string courseDescription;

        public Course() { }

        public Course(int id)
        {
            this.id = id;
        }

        public Course(int id, string name, double cost, int deliveryType, DateTime startDate, DateTime endDate, int locationId, string areaOfStudy, string courseDescription)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.deliveryType = deliveryType;
            this.startDate = startDate;
            this.endDate = endDate;
            this.locationId = locationId;
            this.areaOfStudy = areaOfStudy;
            this.courseDescription = courseDescription;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public double Cost
        {
            get
            {
                return cost;
            }

            set
            {
                cost = value;
            }
        }

        public int DeliveryType
        {
            get
            {
                return deliveryType;
            }

            set
            {
                deliveryType = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
            }
        }

        public int LocationId
        {
            get
            {
                return locationId;
            }

            set
            {
                locationId = value;
            }
        }

        public string AreaOfStudy
        {
            get
            {
                return areaOfStudy;
            }
            set
            {
                areaOfStudy = value;
            }
        }

        public string CourseDescription
        {
            get
            {
                return courseDescription;
            }
            set
            {
                courseDescription = value;
            }
        }

        public bool Add()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool Search()
        {
            throw new NotImplementedException();
        }
    }
}
