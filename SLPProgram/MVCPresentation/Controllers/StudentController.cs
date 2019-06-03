using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer;
using DataObjects;

namespace MVCPresentation.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private StudentManager _studentManager = new StudentManager();
        private userManager _userManager = new userManager();
        private TeacherUser teacher = new TeacherUser();
        private SLPUser slp = new SLPUser();
        private List<string> slpID = new List<string>();
        private IEnumerable<String> _states;
        private IEnumerable<String> _schoolName;
        private IEnumerable<String> _grade;
        private IEnumerable<String> _iepType;
        private IEnumerable<String> _goalType;



        public StudentController()
        {
            try
            {
                _states = _studentManager.SelectAllStates();
                _schoolName = _studentManager.RetrieveSchools();
                _grade = _studentManager.RetrieveGrades();
                _iepType = _studentManager.SelectAllStudentIEPTypes();
                _goalType = _studentManager.RetrieveGoalTypes();
            }
            catch(Exception)
            {
                throw;
            }

        }

        // GET: Student
        public ActionResult Index(string id, string slpID)
        {
            IEnumerable<Students> _students = null;

            var slps = _userManager.SelectSLPIds();
            foreach (var item in slps)
            {
                if (item.Equals(slpID))
                {
                    _students = _studentManager.GetStudentsBySlpId(slp.SLPID).Where(s => s.Active);
                }
                else
                {
                    _students = _studentManager.GetStudents().Where(s => s.Active);
                }

            }

            return View(_students);
        }

        //[Authorize]
        //// GET: User
        //public ActionResult AuthorizeIndex(string id)
        //{
        //    IEnumerable<Students> _students = null;

        //    var slps = _userManager.SLPId(slp);
        //    foreach (var item in slps)
        //    {
        //        if (item.Equals(id))
        //        {
        //            _students = _studentManager.GetStudentsBySlpId(slp.SLPID).Where(s => s.Active);
        //        }

        //    }
        //    return View(_students);
        //}


        public ActionResult Manage()
        {
            IEnumerable<Students> _students = _studentManager.GetStudents().Where(s => s.Active == false);

            return View(_students);
        }

        // GET: Student/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            /*int newID = Convert.ToInt32(id)*/
            ;
            var student = _studentManager.SelectStudentIEP(id);
            return View(student);
        }

        [Authorize]
        // GET: User/Details/5
        public ActionResult AuthorizeDetails(string id)
        {

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var student = _studentManager.SelectStudentIEP(id);

            return View(student);
        }


        // GET: Student/Details/5
        public ActionResult DetailsSLP(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            /*int newID = Convert.ToInt32(id)*/
            
            var student = _studentManager.GetStudentsBySlpId(id);
            return View(student);
        }

        [Authorize]
        
        [Authorize(Roles = "SLP")]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.States = _states;
            ViewBag.SchoolName = _schoolName;
            ViewBag.Grade = _grade;
            ViewBag.IEPType = _iepType;
            ViewBag.GoalType = _goalType;

            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Students student, SLPUser slp, TeacherUser teacher)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    if (_studentManager.CreateNewStudent(student, slp, teacher))
                    {
                        return RedirectToAction("Index");
                    }
                    
                }
                catch
                {
                    ViewBag.States = _states;
                    ViewBag.SchoolName = _schoolName;
                    ViewBag.Grade = _grade;
                    ViewBag.IEPType = _iepType;
                    ViewBag.GoalType = _goalType;

                    return View();
                }
            }
            ViewBag.States = _states;
            ViewBag.SchoolName = _schoolName;
            ViewBag.Grade = _grade;
            ViewBag.IEPType = _iepType;
            ViewBag.GoalType = _goalType;

            return View(student);
        }


        // GET: Student/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Students student = _studentManager.SelectStudentIEP(id);

            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Students student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Students oldStudent = _studentManager.SelectStudentIEP(id);
                    _studentManager.EditIEP(oldStudent, student);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View(student);
            }
            
        }

        // GET: Student/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            
            Students student = _studentManager.SelectStudentIEP(id);
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Students iep, FormCollection collection)
        {
            iep = _studentManager.SelectStudentIEP(id);

            try
            {
                if (_studentManager.DeactivateIEP(iep))
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Reactivate(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Students student = _studentManager.SelectStudentIEP(id);
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Reactivate(string id, Students iep, FormCollection collection)
        {
            iep = _studentManager.SelectStudentIEP(id);

            try
            {
                if (_studentManager.ActivateIEP(iep))
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Student/Delete/5
        public ActionResult Purge(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Students student = _studentManager.SelectStudentIEP(id);
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Purge(string id, Students student, Students iep, FormCollection collection)
        {
            student = _studentManager.SelectStudentIEP(id);
            iep = _studentManager.SelectStudentIEP(id);

            try
            {
                if (_studentManager.DeleteStudent(student, iep))
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
