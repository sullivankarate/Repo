using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Karate.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [DisplayFormat (DataFormatString = "{0: MM-dd-yyyy}")]
        public DateTime DOB { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        public string State { get; set; }
        [DisplayName("Location")]
        public int LocationID { get; set; } = 0;
        public List<Location> Locations { get; set; } = new LocationDAL().GetLocations();

        [DisplayName("Level")]
        public int LevelID { get; set; } = 0;
        public List<Level> Levels { get; set; } = new LevelDAL().GetLevels();
        public bool IsDelted { get; set; }
    }

    /// <summary>
    /// Student Data Access Layer
    /// </summary>
    public class StudentDAL
    {    
        public bool InsUpdStudent(Student stud)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myconnect"].ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
                return false;
            try
            {
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@StudentID", SqlDbType.Int){Value = stud.StudentId},
                    new SqlParameter("@FirstName", SqlDbType.VarChar, 100){Value = stud.FirstName  ?? ""},
                    new SqlParameter("@LastName", SqlDbType.VarChar, 100){Value = stud.LastName  ?? ""},
                    new SqlParameter("@Email", SqlDbType.VarChar, 100){Value = stud.Email  ?? ""},
                    new SqlParameter("@DOB", SqlDbType.DateTime, 100){Value = stud.DOB},
                    new SqlParameter("@Address1", SqlDbType.VarChar, 100){Value = stud.Address1 ?? ""},
                    new SqlParameter("@Address2", SqlDbType.VarChar, 100){Value = stud.Address2 ?? "" },
                    new SqlParameter("@City", SqlDbType.VarChar, 100){Value = stud.City  ?? ""},
                    new SqlParameter("@Zip", SqlDbType.VarChar, 100){Value = stud.Zip  ?? ""},
                    new SqlParameter("@State", SqlDbType.VarChar, 100){Value = stud.State  ?? ""},
                    new SqlParameter("@LocationID", SqlDbType.Int){Value = stud.LocationID},
                    new SqlParameter("@LevelID", SqlDbType.Int){Value = stud.LevelID}
                };

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("SP_InsUpdStudent", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] sqlParameterCollection = param;
                    sqlCommand.Parameters.AddRange(sqlParameterCollection);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }



        }

        public List<Student> GetStudents()
        {
            string sidx = string.Empty;
            string sord = string.Empty;
            int page = 0;
            int rows = 0;

            const string spName = "SP_GetStudents";
            List<Student> studentCollection;

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
                studentCollection = FillStudentEntity(sqlCommand);
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
        private static List<Student> FillStudentEntity(SqlCommand sqlCommand)
        {

            var locationList = new LocationDAL().GetLocations();            
            var levelsList = new LevelDAL().GetLevels();

            List<Student> students = new List<Student>();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    int locationID = Convert.ToInt32(sqlDataReader["LocationID"]);
                    students.Add(new Student
                    {
                        StudentId = Convert.ToInt32(sqlDataReader["StudentID"]),
                        FirstName = sqlDataReader["FirstName"].ToString(),
                        LastName = sqlDataReader["LastName"].ToString(),
                        Email = sqlDataReader["Email"].ToString(),
                        Address1 = sqlDataReader["Address1"].ToString(),
                        Address2 = sqlDataReader["Address2"].ToString(),
                        City = sqlDataReader["City"].ToString(),
                        Zip = sqlDataReader["Zip"].ToString(),
                        DOB = Convert.ToDateTime(sqlDataReader["DOB"]?.ToString()),
                        State = sqlDataReader["State"].ToString(),
                        LocationID = Convert.ToInt32(sqlDataReader["LocationID"]),
                        Locations = locationList,
                        LevelID = Convert.ToInt32(sqlDataReader["LevelID"]),
                        Levels = levelsList,
                        IsDelted = Convert.ToBoolean(sqlDataReader["IsDeleted"])
                    });
                }
            }
            return students;
        }
    }
}