using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Karate.Models
{
    public class SkillLevel
    {
        [HiddenInput(DisplayValue = false)]
        public int SkillLevelID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int LevelID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int SkillID { get; set; }        
        public int SortOrder { get; set; }
        public Level LevelInfo { get; set; }
        public Skill SkillInfo { get; set; }

        public bool Taught { get; set; } = false;
        public bool Practiced { get; set; } = false;
        public bool Stripe { get; set; } = false;
    }

    public class SkillLevelDAL
    {
        /// <summary>
        /// Fetch student collection as per grid criteria
        /// </summary>
        /// <param name="sidx">sorted colum name</param>
        /// <param name="sord">sorting order</param>
        /// <param name="page">page index of grid</param>
        /// <param name="rows">total number of rows of grid</param>
        /// <returns>Collection of Students</returns>
        public List<SkillLevel> GetSkillLevel(int LevelID)
        {
            const string spName = "SP_GetSkillsByLevel";
            List<SkillLevel> studentCollection;

            string connectionString = ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
                return null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(spName, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] sqlParameterCollection = SetParameter(LevelID);
                sqlCommand.Parameters.AddRange(sqlParameterCollection);
                sqlConnection.Open();
                studentCollection = FillSkillLevel(sqlCommand);
            }
            return studentCollection;
        }

        /// <summary>
        /// Fill SQL paramter for Stored Procedure
        /// </summary>
        /// <param name="sidx">sorted colum name</param>
        /// <param name="sord">sorting order</param>
        /// <param name="page">page index of grid</param>
        /// <param name="rows">total number of rows of grid</param>
        /// <returns>Collection of SQL paramters object</returns>
        private static SqlParameter[] SetParameter(int LevelID)
        {
            SqlParameter levelIDParam = new SqlParameter("@LevelID", SqlDbType.Int);
            levelIDParam.Value = LevelID;
            return new SqlParameter[]
            {
                levelIDParam
            };
        }

        /// <summary>
        /// Fill the Studnet Entity by using sql reader of command
        /// </summary>
        /// <param name="sqlCommand">sql command object for excute reader</param>
        /// <returns>colletion of students</returns>
        private static List<SkillLevel> FillSkillLevel(SqlCommand sqlCommand)
        {

            List<Location> loc = new List<Location>();
            loc = new LocationDAL().GetLocations();

            List<SkillLevel> skillLevels = new List<SkillLevel>();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    int skillLevelID = Convert.ToInt32(sqlDataReader["SkillLevelID"]);
                    int levelID = Convert.ToInt32(sqlDataReader["LevelID"]);
                    int skillID = Convert.ToInt32(sqlDataReader["SkillID"]);
                    var levelsList = new LevelDAL().GetLevels();
                    var skillsList = new SkillDAL().GetSkills();
                    
                    //int locationID = Convert.ToInt32(sqlDataReader["LocationID"]);
                    skillLevels.Add(new SkillLevel
                    {                        
                        SkillLevelID = skillLevelID,
                        LevelID = levelID,
                        SkillID = skillID,
                        LevelInfo = levelsList.FirstOrDefault(x => x.LevelID == levelID),
                        SkillInfo = skillsList.FirstOrDefault(x => x.SkillID == skillID),
                        SortOrder = Convert.ToInt32(sqlDataReader["SortOrder"])                        
                    });
                }
            }
            return skillLevels;
        }
    }
}