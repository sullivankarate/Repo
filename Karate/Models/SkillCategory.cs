using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Karate.Models
{
    public class SkillCategory
    {

        public int SkillCategoryID { get; set; }
        public string SkillCategoryName { get; set; }
        public int SortOrder { get; set; }
        
    }

    public class SkillCategoryDAL
    {
        public List<SkillCategory> GetSkillCategorys()
        {

            const string spName = "SP_GetSkillCategory";
            List<SkillCategory> studentCollection;

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
                studentCollection = FillSkillCategoryEntity(sqlCommand);
            }
            return studentCollection;
        }
   
        private static List<SkillCategory> FillSkillCategoryEntity(SqlCommand sqlCommand)
        {
            List<SkillCategory> skillCategory = new List<SkillCategory>();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    skillCategory.Add(new SkillCategory
                    {
                        SkillCategoryID = Convert.ToInt32(sqlDataReader["SkillCategoryID"]),
                        SkillCategoryName =  sqlDataReader["SkillCategoryName"].ToString(),
                        SortOrder = Convert.ToInt32(sqlDataReader["SortOrder"])
                    });
                }
            }
            return skillCategory;
        }
    }
}