using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public class UnitSkill : IBridgingData
    {
        private string unitCode;
        private ListBox control;

        public UnitSkill() { }

        public UnitSkill(string unitCode)
        {
            this.unitCode = unitCode;
        }

        public UnitSkill(string unitCode, ListBox control)
        {
            this.unitCode = unitCode;
            this.control = control;
        }

        public string UnitCode
        {
            get
            {
                return unitCode;
            }
            set
            {
                unitCode = value;
            }
        }

        public ListBox Control
        {
            get
            {
                return control;
            }

            set
            {
                control = value;
            }
        }

        public bool Update()
        {
            int id = GetId();
            if (id != -1)
                return Database.UpdateBridgingTable("Unit_Skills", "unitid", id, "skillid", control);
            return false;
        }

        public bool Delete()
        {
            int id = GetId();
            if (id != -1)
                return Database.DeleteBridgingTable("Unit_Skills", "unitid", id);
            return false;
        }

        public int GetId()
        {
            foreach (SqlDataReader row in Database.ExecuteQuery($"select unitid from units where unitCode = '{unitCode}'"))
            {
                return Convert.ToInt32(row[0]);
            }
            MessageBox.Show($"Unit code {unitCode} not found.");
            return -1;
        }
    }
}
