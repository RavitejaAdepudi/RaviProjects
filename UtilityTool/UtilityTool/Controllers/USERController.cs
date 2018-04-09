using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UAT_TESTINGS.Models;
using UAT_TESTINGS.Repository;




namespace UAT_TESTINGS.Controllers
{
    public class USERController : Controller
    {
        // GET: USER
        //public ActionResult ADD_DETAILS()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult ADD_DETAILS(USERDETAILS det )
        //{
        //    try
        //    {
        //       // if (ModelState.IsValid)
        //       // {
        //            UserRepository userRepo = new UserRepository();
        //        ModelState.Clear();

        //            if (userRepo.AddUser(det))
        //             {
        //                ViewBag.Message = "User details added successfully";
        //            }
        //        //}

        //        return View();
        //    }
        //    catch(Exception ex)
        //    {
        //        TempData["message"] = "User details not added";
        //        return View();
        //    }
        //}

        public ActionResult Show_details()
        {
            UserRepository us = new UserRepository();
            USERDETAILS oList = new USERDETAILS();
            oList.oUserList = us.GetAlldetails();
            //   var emp = us.GetAlldetails().ToList();
            //   return (data=emp);


            //if (SearchBy == "BatchName")
            //{
            //Index action method will return a view with a student records based on what a user specify the value in textbox   
            //  return View(us.GetAlldetails.Where(x => BatchNames == search || search == null).ToList());
            return View(oList);
            // else if (option == "Gender")
            //{
            // return View(db.Students.Where(x => x.Gender == search || search == null).ToList());

        }
        // [HttpPost]
        //public ActionResult Show_details(USERDETAILS search)
        // {
        //  UserRepository entities = new UserRepository();
        // return View(entities.GetAlldetails());
        //   }
        //[HttpPost]

        //public ActionResult Show_details(USERDETAILS ud)
        //{
        //    UserRepository us = new UserRepository();
        //    us.GetAlldetails();
        //    return View();
        //}

        public ActionResult EditUserDetails(string Bname)
        {
            UserRepository EmpRepo = new UserRepository();

            return View(EmpRepo.GetAlldetails().Find(det => det.BatchName == Bname));


        }

        // POST: Employee/EditEmpDetails/5    
        [HttpPost]

        public ActionResult EditUserDetails(string Bname, USERDETAILS obj)
        {
            try
            {
                UserRepository EmpRepo = new UserRepository();

                if (
                EmpRepo.UpdateUser(obj))
                {

                    ViewBag.Message = "User details modified successfully";
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        //[HttpGet]
        //public ActionResult SearchRecordByBatchName(string Search)
        //{
        //    UserRepository objRep = new UserRepository();
        //    //string Search = "S";
        //    var res=objRep.search(Search);
        //    return View(res);
        //    //  return (objRep.search(BatchNamefromController));
        //    //if (searchby == "BatchName")
        //    //{
        //    //    return View(objRep.Employees.Where(x => x.BatchName == search || search == null).ToList());
        //    //}
        //    //else
        //    //{
        //    //    return View(db.Employees.Where(x => x.Name.StartsWith(search)).ToList());


        //    //
        //}
        //[HttpGet]
        public ActionResult search()
        {
            USERDETAILS oUser = new USERDETAILS();
            UserRepository EmpRepo = new UserRepository();
            string s = Request["BatchName"];
            var res = EmpRepo.GetAlldetails();
            oUser.oUserList = from d in res
                              where d.BatchName.Contains(s)
                              select d;

            if (oUser == null || oUser.oUserList == null)
            {
                HttpNotFound();
            }

            return View("Show_details", oUser);
        }
    }

    
    }
