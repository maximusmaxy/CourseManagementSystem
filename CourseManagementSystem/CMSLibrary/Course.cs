using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public class Course : IData
    {
        private int id;
        private string name;
        private double cost;
        private int deliveryType;
        private DateTime startDate;
        private DateTime endDate;
        private int locationId;
        private string areaOfStudy;
        private string description;

        public Course() { }

        public Course(int id)
        {
            this.id = id;
        }

        public Course(int id, string name, double cost, int deliveryType, DateTime startDate, DateTime endDate, int locationId, string areaOfStudy, string description)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.deliveryType = deliveryType;
            this.startDate = startDate;
            this.endDate = endDate;
            this.locationId = locationId;
            this.areaOfStudy = areaOfStudy;
            this.description = description;
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

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public bool Add()
        {
            return Database.Add("courses", out id, name, cost, deliveryType, startDate, endDate, locationId, areaOfStudy, Description);
        }

        public bool Update()
        {
            return Database.Update("courses", "courseid", id,
                "courseName", name,
                "coursecost", cost,
                "coursedeliverytype", deliveryType,
                "coursestartdate", startDate,
                "courseenddate", endDate,
                "locationId", locationId,
                "areaofstudy", areaOfStudy,
                "coursedescription", description);
        }

        public bool Delete()
        {
            return Database.Delete("courses", "courseid", id);
        }

        public bool Search()
        {
            return Search("courseid", id);
        }

        public bool Search(params object[] values)
        {
            DataRow dataRow;
            if (Database.Search("courses", out dataRow, values))
            {
                name = Convert.ToString(dataRow[1]);
                cost = Convert.ToDouble(dataRow[2]);
                deliveryType = Convert.ToInt32(dataRow[3]);
                startDate = Convert.ToDateTime(dataRow[4]);
                endDate = Convert.ToDateTime(dataRow[5]);
                locationId = Convert.ToInt32(dataRow[6]);
                areaOfStudy = Convert.ToString(dataRow[7]);
                description = Convert.ToString(dataRow[8]);
                return true;
            }
            else
                return false;
        }
    }
}
