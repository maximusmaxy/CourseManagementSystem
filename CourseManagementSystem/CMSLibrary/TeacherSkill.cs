using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public class TeacherSkill : IData
    {
        public static string Table { get; set; } = "Teacher_Skills";

        private int teacherId;
        private int skillId;

        public TeacherSkill() { }

        public TeacherSkill(int teacherId, int skillId)
        {
            this.teacherId = teacherId;
            this.skillId = skillId;
        }

        public int TeacherId
        {
            get
            {
                return teacherId;
            }

            set
            {
                teacherId = value;
            }
        }

        public int SkillId
        {
            get
            {
                return skillId;
            }

            set
            {
                skillId = value;
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
