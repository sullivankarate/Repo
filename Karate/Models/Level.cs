using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Karate.Models
{
    public class Level
    {
        public int LevelID { get; set; }
        public string LevelName { get; set; }
        
        public int SortOrder { get; set; }
        
    }

    public class LevelDAL
    {
        public List<Level> GetLevels()
        {

            const string spName = "SP_GetLevels";
            List<Level> levelCollection;

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
                levelCollection = FillLevelEntity(sqlCommand);
            }
            return levelCollection;
        }

        private static List<Level> FillLevelEntity(SqlCommand sqlCommand)
        {
            List<Level> levels = new List<Level>();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    levels.Add(new Level
                    {
                        LevelID = Convert.ToInt32(sqlDataReader["LevelID"]),
                        LevelName = sqlDataReader["LevelName"].ToString(),
                        SortOrder = Convert.ToInt32(sqlDataReader["SortOrder"])
                    });
                }
            }
            return levels;
        }
    }
}