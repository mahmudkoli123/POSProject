using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSManagementProject.DAL;


namespace POSManagementProject.Controllers
{
    public class AjaxJsonController : Controller
    {
        DataAccess dataaccess = new DataAccess();
        public List<Department> Departments = new List<Department>()
        {
            new Department(){Id = 1,Name = "CSE",Code = "C001"},
            new Department(){Id = 2,Name = "EEE",Code = "C002"},
            new Department(){Id = 3,Name = "ETE",Code = "C003"}
        };
        public List<Group> Groups = new List<Group>()
        {
            new Group(){Id = 1,Name = "A",Code = "G001",DepartmentId = 1},
            new Group(){Id = 2,Name = "B",Code = "G002",DepartmentId = 2},
            new Group(){Id = 3,Name = "C",Code = "G003",DepartmentId = 1}
        };
        public List<Student> Students = new List<Student>()
        {
            new Student(){Id = 1,Name = "Mahmud",Code = "C001",GrouptId=1},
            new Student(){Id = 2,Name = "Koli",Code = "C002",GrouptId=2},
            new Student(){Id = 3,Name = "Prince",Code = "C003",GrouptId=2}
        };

        // GET: AjaxJson
        public ActionResult Index()
        {
            return View(dataaccess.GetDepartmentSelectList(Departments));
        }

        public JsonResult GetGroups(int id)
        {
            var groupList = Groups.Where(c => c.DepartmentId == id);
            var data = groupList.Select(c => new { c.Id, c.Name });
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStudents(int id)
        {
            var groupList = Students.Where(c => c.GrouptId == id);
            var data = groupList.Select(c => new { c.Id, c.Name });
            return Json(data);
        }

    }

    public class Department
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string Code{ get; set; }

        public List<Group> Groups { get; set; }
    }

    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public List<Student> Students { get; set; }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int GrouptId { get; set; }
        public virtual Group Group { get; set; }
    }

}