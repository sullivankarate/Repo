using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Karate.Models
{
    public class Skill
    {
        public int SkillID { get; set; }
        public string SkillName { get; set; }
        public int SortOrder { get; set; }

        public int SkillCaegoryID { get; set; }
        public SkillCategory SkillCaegory { get; set; }

    }

    public class SkillDAL
    {
        public List<Skill> GetSkills()
        {

            const string spName = "SP_GetSkills";
            List<Skill> skillCollection;

            string connectionString = ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
                return null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(spName, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //SqlParameter[] sqlParameterCollection = SetParameter(sidx, sord, page, rows);
                //sqlCommand.Parameters.AddRange(sqlParameterCollection);
                sqlConnection.Open();
                skillCollection = FillSkillEntity(sqlCommand);
            }
            return skillCollection;
        }

        private static List<Skill> FillSkillEntity(SqlCommand sqlCommand)
        {

            List<SkillCategory> skillCategoryList = new SkillCategoryDAL().GetSkillCategorys();
            List<Skill> skills = new List<Skill>();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    int SkillCaegoryID = Convert.ToInt32(sqlDataReader["SkillCaegoryID"]);
                    skills.Add(new Skill
                    {
                        SkillID = Convert.ToInt32(sqlDataReader["SkillID"]),
                        SkillName = sqlDataReader["SkillName"].ToString(),
                        SkillCaegoryID = Convert.ToInt32(sqlDataReader["SkillCaegoryID"]),
                        SkillCaegory = skillCategoryList.FirstOrDefault(x => x.SkillCategoryID == SkillCaegoryID)
                    });
                }
            }
            return skills;
        }
    }


}