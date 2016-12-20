using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Karate.Models
{
    public class StudentSkillLevel
    {
        public Student StudentInfo { get; set; }
        public List<SkillLevel> SkillLevelDetail { get; set; }

    }

    public class StudentSkillLevelDAL
    {
        public StudentSkillLevel GetStudentSkillLevel(int studentID)
        {
            var studentInfo = new StudentDAL().GetStudents().FirstOrDefault(x => x.StudentId == studentID);
            StudentSkillLevel res = new StudentSkillLevel()
            {
                StudentInfo = studentInfo,
                SkillLevelDetail = new SkillLevelDAL().GetSkillLevel(studentInfo.LevelID)
            };
            return res;
        }
    }

}



