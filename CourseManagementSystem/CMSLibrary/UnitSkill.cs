using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public class UnitSkill : IBridgingData
    {
        private int unitId;
        private ListBox control;

        public UnitSkill() { }

        public UnitSkill(int unitId, ListBox control)
        {
            this.unitId = unitId;
            this.control = control;
        }

        public int UnitId
        {
            get
            {
                return unitId;
            }

            set
            {
                unitId = value;
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
            return Database.UpdateBridgingTable("Unit_Skills", "unitid", unitId, "skillid", control);
        }

        public bool Delete()
        {
            control.ClearSelected();
            return Update();
        }
    }
}
