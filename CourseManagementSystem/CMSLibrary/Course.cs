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
        private int departmentId;
        private string description;

        public Course() { }

        public Course(int id)
        {
            this.id = id;
        }

        public Course(int id, string name, double cost, int deliveryType, DateTime startDate, DateTime endDate, int locationId, int departmentId, string description)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.deliveryType = deliveryType;
            this.startDate = startDate;
            this.endDate = endDate;
            this.locationId = locationId;
            this.departmentId = departmentId;
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

        public int DepartmentId
        {
            get
            {
                return departmentId;
            }
            set
            {
                departmentId = value;
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
            return Database.Add("courses", out id, departmentId, locationId, name, cost, deliveryType, startDate, endDate, description);
        }

        public bool Update()
        {
            return Database.Update("courses", "courseid", id,
                "departmentId", departmentId,
                "locationId", locationId,
                "courseName", name,
                "coursecost", cost,
                "coursedeliverytype", deliveryType,
                "coursestartdate", startDate,
                "courseenddate", endDate,
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
                id = Convert.ToInt32(dataRow[0]);
                departmentId = Convert.ToInt32(dataRow[1]);
                locationId = Convert.ToInt32(dataRow[2]);
                name = Convert.ToString(dataRow[3]);
                cost = Convert.ToDouble(dataRow[4]);
                deliveryType = Convert.ToInt32(dataRow[5]);
                startDate = Convert.ToDateTime(dataRow[6]);
                endDate = Convert.ToDateTime(dataRow[7]);
                description = Convert.ToString(dataRow[8]);
                return true;
            }
            else
                return false;
        }
    }
}