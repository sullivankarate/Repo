using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Karate.Models;

namespace Karate.Controllers
{
    public class StudentsController : Controller
    {
        
        public ActionResult Index()
        {   
            return View(GetAllStudents());
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection, string LocationID, string LevelID)
        {
            try
            {
                var students = GetAllStudents();
                IEnumerable<Student> res = new List<Student>(); 

                if (string.IsNullOrEmpty(LocationID) && string.IsNullOrEmpty(LevelID))
                {
                    res = students;
                }
                else if (string.IsNullOrEmpty(LocationID) && !string.IsNullOrEmpty(LevelID))
                {
                    res = students.Where(x => x.LevelID == Convert.ToInt32(LevelID));
                }
                else if (!string.IsNullOrEmpty(LocationID) && string.IsNullOrEmpty(LevelID))
                {
                    res = students.Where(x => x.LocationID == Convert.ToInt32(LocationID));
                }
                else
                {
                    res = students.Where(x => x.LocationID == Convert.ToInt32(LocationID) && x.LevelID == Convert.ToInt32(LevelID));
                }

                if (res?.Count() == 0) 
                {
                    res = students;
                }
                return View(res);

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Book(int id)
        { 
            var book = new StudentSkillLevelDAL().GetStudentSkillLevel(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult Book(int id, StudentSkillLevel collection)
        {
            var book = new StudentSkillLevelDAL().GetStudentSkillLevel(id);
            return View(book);
        }


        //[HttpPost]
        //public ActionResult Book(int id, FormCollection collection)
        //{
        //    var book = new StudentSkillLevelDAL().GetStudentSkillLevel(id);
        //    return View(book);
        //}

        public ActionResult Details(int id)
        {            
            return View(GetStudentByID(id));
        }

        // GET: Students/Create
        public ActionResult Create()
        {
      
            return View(new Student());
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    var res = new StudentDAL().InsUpdStudent(student);
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetStudentByID(id));
            //return View();
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                // TODO: Add update logic here
                var res = new StudentDAL().InsUpdStudent(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        private List<Student> GetAllStudents()
        {

            StudentDAL dal = new StudentDAL();
            return dal.GetStudents();
        }

        private Student GetStudentByID(int id)
        {            
            return GetAllStudents().Where(sd => sd.StudentId == id).FirstOrDefault();
        }        //public JsonResult GetStudents(string sidx, string sord, int page, int rows)
        //{
        //    int pageIndex = page;
        //    int pageSize = rows;
        //    int startRow = (pageIndex * pageSize) + 1;
        //    StudentDAL sdal = new StudentDAL();
        //    List<Student> students = sdal.SelectStudnets(sidx, sord, startRow, rows);
        //    int totalRecords = students.Count(); //.Select(x => x.TotalRows).FirstOrDefault();
        //    int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
        //    var jsonData = new
        //    {
        //        total = totalPages,
        //        page,
        //        records = totalRecords,
        //        rows = (
        //            from student in students
        //            select new
        //            {
        //                i = student.StudentId,
        //                cell = new string[] { student.StudentId.ToString(), student.FirstName, student.LastName, student.Email }
        //            }).ToArray()
        //    };
        //    return Json(jsonData);
        //}


        // GET: Students/Details/5

        
    }
}
