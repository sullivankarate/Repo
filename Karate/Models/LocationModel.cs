using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Karate.Models
{

    public class Location
    {
   
        public int LocationID { get; set; }
        public string LocationName { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }

    }
    public class LocationDAL : Location
    {
        /// <summary>
        /// Fetch student collection as per grid criteria
        /// </summary>
        /// <param name="sidx">sorted colum name</param>
        /// <param name="sord">sorting order</param>
        /// <param name="page">page index of grid</param>
        /// <param name="rows">total number of rows of grid</param>
        /// <returns>Collection of Students</returns>
        public List<Location> GetLocations()
        {
            string sidx = string.Empty;
            string sord = string.Empty;
            int page = 0;
            int rows = 0;

            const string spName = "sp_getLocations";
            List<Location> locationCollection;

            string connectionString = ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
                return null;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(spName, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] sqlParameterCollection = SetParameter(sidx, sord, page, rows);
                sqlCommand.Parameters.AddRange(sqlParameterCollection);
                sqlConnection.Open();
                locationCollection = FillLocationEntity(sqlCommand);
            }
            return locationCollection;
        }

        /// <summary>
        /// Fill SQL paramter for Stored Procedure
        /// </summary>
        /// <param name="sidx">sorted colum name</param>
        /// <param name="sord">sorting order</param>
        /// <param name="page">page index of grid</param>
        /// <param name="rows">total number of rows of grid</param>
        /// <returns>Collection of SQL paramters object</returns>
        private static SqlParameter[] SetParameter(string sidx, string sord, int page, int rows)
        {
            SqlParameter sortColNameParam = new SqlParameter("@SortColumnName", SqlDbType.VarChar, 100);
            sortColNameParam.Value = sidx;

            SqlParameter sortOrderParam = new SqlParameter("@SortOrderBy", SqlDbType.VarChar, 4);
            sortOrderParam.Value = sord;

            SqlParameter numberOfRowsParam = new SqlParameter("@NumberOfRows", SqlDbType.Int);
            numberOfRowsParam.Value = rows;

            SqlParameter startRowParam = new SqlParameter("@StartRow", SqlDbType.Int);
            startRowParam.Value = page;

            return new SqlParameter[]
            { 
                //sortColNameParam,sortOrderParam,numberOfRowsParam,startRowParam
            };
        }

        /// <summary>
        /// Fill the Studnet Entity by using sql reader of command
        /// </summary>
        /// <param name="sqlCommand">sql command object for excute reader</param>
        /// <returns>colletion of students</returns>
        private static List<Location> FillLocationEntity(SqlCommand sqlCommand)
        {
            List<Location> locations = new List<Location>();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    locations.Add(new Location
                    {
                        LocationID = Convert.ToInt32(sqlDataReader["LocationID"]),
                        LocationName = sqlDataReader["LocationName"].ToString(),                       
                        Address1 = sqlDataReader["Address1"].ToString(),
                        Address2 = sqlDataReader["Address2"].ToString(),
                        City = sqlDataReader["City"].ToString(),
                        Zip = sqlDataReader["Zip"].ToString(),                       
                        State = sqlDataReader["State"].ToString(),
                    });
                }
            }
            return locations;
        }
    }
}